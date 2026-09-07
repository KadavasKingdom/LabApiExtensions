using AdminToys;
using Mirror;

namespace LabApiExtensions.FakeExtension;

internal static class FakeSyncCoreExtension
{
    internal readonly struct SubWriteInfo(Type classType, ulong dirtybit, int writeCount)
    {
        public readonly Type ClassType = classType;

        /// <summary>
        /// Maximum amount of dirty bit this class has.
        /// </summary>
        public readonly ulong MaxDirtyBit = dirtybit;

        /// <summary>
        /// Amount of times to write empty dirty bit.
        /// </summary>
        public readonly int ExtraWriteCount = writeCount;

        public readonly bool IsSet = classType != null;
    }

    /// <summary>
    /// Provides informations about writing sync data.
    /// </summary>
    private static readonly SubWriteInfo[] SubWriteInfos =
    [
        // IF inherited like MyCapbybara : Capybara : AdminToyBase, we need to write 2 times.
        new(typeof(AdminToyBase), 16, 1),
    ];

    internal static SubWriteInfo GetSubWriteInfo(Type type)
    {
        foreach (SubWriteInfo info in SubWriteInfos)
        {
            if (type.IsSubclassOf(info.ClassType))
                return info;
        }

        return default;
    }

    internal static void WriteExtraDirtyBit(NetworkBehaviour networkBehaviour, NetworkWriterPooled writer, ulong dirtyBit = 0)
    {
        Type networkType = networkBehaviour.GetType();

        WriteExtraDirtyBit(networkType, writer, dirtyBit);
    }

    internal static void WriteExtraDirtyBit(Type networkType, NetworkWriterPooled writer, ulong dirtyBit = 0)
    {
        SubWriteInfo writeInfo = GetSubWriteInfo(networkType);

        WriteExtraDirtyBit(writeInfo, writer, dirtyBit);
    }

    internal static void WriteExtraDirtyBit(SubWriteInfo writeInfo, NetworkWriterPooled writer, ulong dirtyBit = 0)
    {
        if (!writeInfo.IsSet)
            return;

        for (int i = 0; i < writeInfo.ExtraWriteCount; i++)
        {
            writer.WriteULong(dirtyBit);
        }
    }

    internal static EntityStateMessage WriteStateMessage(NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled> writeSyncData, Action<NetworkWriterPooled> writeSyncVar)
    {  
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
        {
            writer.WriteULong(0);
            WriteExtraDirtyBit(networkBehaviour, writer);
        }

        // end position safety write
        int endPosition = writer.Position;
        writer.Position = headerPosition;
        int size = endPosition - contentPosition;
        byte safety = (byte)(size & 0xFF);
        writer.WriteByte(safety);
        writer.Position = endPosition;

        return new()
        {
            netId = networkBehaviour.netId,
            payload = writer.ToArraySegment(),
        };
    }

    internal static void SendFakeCore(this Player target, NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled> writeSyncData, Action<NetworkWriterPooled> writeSyncVar, int channel = 0)
    {
        if (target.Connection == null)
            return;

        SendFakeCore(target.Connection, networkBehaviour, writeSyncData, writeSyncVar, channel);
    }

    internal static void SendFakeCore(this NetworkConnection connection, NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled> writeSyncData, Action<NetworkWriterPooled> writeSyncVar, int channel = 0)
    {
        if (connection == null)
            return;

        EntityStateMessage message = WriteStateMessage(networkBehaviour, writeSyncData, writeSyncVar);

        connection.Send(message, channel);
    }

    internal static void SendFakeCore(this IEnumerable<Player> targets, NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled> writeSyncData, Action<NetworkWriterPooled> writeSyncVar, int channel = 0)
    {
        SendFakeCore(targets.Select(static x => x.Connection), networkBehaviour, writeSyncData, writeSyncVar, channel);
    }

    internal static void SendFakeCore(this IEnumerable<NetworkConnection> connections, NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled> writeSyncData, Action<NetworkWriterPooled> writeSyncVar, int channel = 0)
    {
        EntityStateMessage message = WriteStateMessage(networkBehaviour, writeSyncData, writeSyncVar);

        foreach (NetworkConnection connection in connections)
        {
            if (connection == null)
                continue;

            connection.Send(message, channel);
        }
    }
}
