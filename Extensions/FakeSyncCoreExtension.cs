using Mirror;

namespace LabApiExtensions.Extensions;

internal static class FakeSyncCoreExtension
{
    internal static void SendFakeCore(this Player target, NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled> writeSyncData, Action<NetworkWriterPooled> writeSyncVar)
    {
        if (target.Connection == null)
            return;

        using NetworkWriterPooled writer = NetworkWriterPool.Get();
        
        // We're changing the First NetworkBehaviour of the NetId!
        // Some prefabs have multiple NetworkBehaviour, in that case you are on your own :(
        NetworkBehaviour[] behaviors = networkBehaviour.netIdentity.NetworkBehaviours;
        int index = behaviors == null ? 0 : Array.IndexOf(behaviors, networkBehaviour);
        Compression.CompressVarUInt(writer, 1UL << index);

        // placeholder length
        int headerPosition = writer.Position;
        writer.WriteByte(0);
        int contentPosition = writer.Position;

        // Serialize Object Sync Data.
        writeSyncData.Invoke(writer);

        // Write Object Sync Vars
        writeSyncVar.Invoke(writer);

        // end position safety write
        int endPosition = writer.Position;
        writer.Position = headerPosition;
        int size = endPosition - contentPosition;
        byte safety = (byte)(size & 0xFF);
        writer.WriteByte(safety);
        writer.Position = endPosition;

        // Copy owner to observer
        if (networkBehaviour.syncMode != SyncMode.Observers)
            CL.Warn("Well snyc mode is not observers, sucks to be you I guess.");

        target.Connection.Send(new EntityStateMessage
        {
            netId = networkBehaviour.netId,
            payload = writer.ToArraySegment(),
        });
    }
}
