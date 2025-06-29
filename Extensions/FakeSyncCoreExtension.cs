using Mirror;

namespace LabApiExtensions.Extensions;

internal static class FakeSyncCoreExtension
{
    internal static void SendFakeCore(this Player target, NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled>? writeSyncData = null, Action<NetworkWriterPooled>? writeSyncVar = null)
    {
        if (target.Connection == null)
            return;

        if (writeSyncData == null || writeSyncVar == null)
        {
            CL.Error("You have not made a SyncData or a SyncVar writer!");
            return;
        }

        Type networkType = networkBehaviour.GetType();

        NetworkWriterPooled writer = NetworkWriterPool.Get();

        // We changing the First NetworkBehaviour of the NetId!
        // Some prefabs have multiple NetworkBehaviour, in that case you are on your own :(
        Compression.CompressVarUInt(writer, 1);

        // placeholder length
        int headerPosition = writer.Position;
        writer.WriteByte(0);
        int contentPosition = writer.Position;

        // Serialize Object Sync Data.
        writeSyncData?.Invoke(writer);

        // Write Object Sync Vars
        writeSyncVar?.Invoke(writer);

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
