using AdminToys;
using Mirror;

namespace LabApiExtensions.Extensions;

public static class FakeSyncVarExtension
{
    private static readonly Dictionary<Type, ulong> SubWriteClassToMinULong = new()
    {
        [typeof(AdminToyBase)] = 32,
    };

    private static ulong GetSubclassMinDirtyBit(Type type)
    {
        foreach (KeyValuePair<Type, ulong> kvp in SubWriteClassToMinULong)
        {
            if (type.IsSubclassOf(kvp.Key))
                return kvp.Value;
        }

        return ulong.MaxValue;
    }

    // Easier syncVar
    public static void SendFakeSyncVar<T>(this Player target, NetworkBehaviour networkBehaviour, ulong dirtyBit, T syncVar)
    {
        Type networkType = networkBehaviour.GetType();

        target.SendFakeCore(networkBehaviour,
        (writer) => writer.WriteULong(0), // Write No SyncData
        (writer) => // Write SyncVar
        {
            // Write DrityBit always
            writer.WriteULong(dirtyBit);

            ulong minDirtyBit = GetSubclassMinDirtyBit(networkType);
            bool isWritten = false;

            if (dirtyBit >= minDirtyBit)
            {
                writer.WriteULong(dirtyBit);
                isWritten = true;
            }

            writer.Write(syncVar);

            if (!isWritten)
                writer.WriteULong(dirtyBit);

        });
    }

    // Sending mulitple Sync Vars to the player. (Not Tested)
    public static void SendFakeSyncVars(this Player target, NetworkBehaviour networkBehaviour, params (ulong DirtyBit, object SyncVar)[] syncVars)
    {
        if (syncVars.Length == 0)
            return;

        Type networkType = networkBehaviour.GetType();

        target.SendFakeCore(networkBehaviour,
        (writer) => writer.WriteULong(0), // Write No SyncData
        (writer) => // Write SyncVar
        {
            ulong allDirtyBits = syncVars.Aggregate(0UL, (previous, tuple) => previous | tuple.DirtyBit);

            // Write DrityBit always
            writer.WriteULong(allDirtyBits);

            ulong minDirtyBit = GetSubclassMinDirtyBit(networkType);
            bool isWritten = false;

            foreach ((ulong dirtyBit, object syncVar) in syncVars.OrderBy(x => x.DirtyBit))
            {
                if (dirtyBit >= minDirtyBit && !isWritten)
                {
                    writer.WriteULong(allDirtyBits);
                    isWritten = true;
                }

                if (!MirrorWriterExtension.Write(syncVar.GetType(), syncVar, writer))
                {
                    CL.Error($"No NetworkWriter found for type {syncVar.GetType()}");
                    return;
                }
            }

            if (!isWritten)
                writer.WriteULong(allDirtyBits);
        });
    }
}
