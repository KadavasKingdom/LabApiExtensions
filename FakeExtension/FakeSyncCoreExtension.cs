using Mirror;

namespace LabApiExtensions.FakeExtension;

internal static class FakeSyncCoreExtension
{
    internal static void SendFakeCore(this Player target, NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled> writeSyncData, Action<NetworkWriterPooled> writeSyncVar)
    {
        if (target.Connection == null)
            return;

        using NetworkWriterPooled writer = NetworkWriterPool.Get();
        
        // gets the dirty mask based on the changed behavior's index
        ulong mask = 0;
        mask |= 1UL << networkBehaviour.netIdentity.NetworkBehaviours.IndexOf(networkBehaviour);
        Compression.CompressVarUInt(writer, mask);

        // placeholder length
        int headerPosition = writer.Position;
        writer.WriteByte(0);
        int contentPosition = writer.Position;

        // Serialize Object Sync Data.
        if (writeSyncData != null)
            writeSyncData.Invoke(writer);
        else
            writer.WriteULong(0);

        // Write Object Sync Vars
        if (writeSyncVar != null)
            writeSyncVar.Invoke(writer);
        else
            writer.WriteULong(0);

        // end position safety write
        int endPosition = writer.Position;
        writer.Position = headerPosition;
        int size = endPosition - contentPosition;
        byte safety = (byte)(size & 0xFF);
        writer.WriteByte(safety);
        writer.Position = endPosition;

        target.Connection.Send(new EntityStateMessage
        {
            netId = networkBehaviour.netId,
            payload = writer.ToArraySegment(),
        });
    }
}
