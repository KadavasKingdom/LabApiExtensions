using AdminToys;
using Mirror;

namespace LabApiExtensions.Extensions;

public static class FakeSyncVarExtension
{
    private static readonly Dictionary<Type, ulong> SubWriteClassToMinULong = new()
    {
        [typeof(AdminToyBase)] = 16,
    };

    // Easier syncVar
    public static void SendFakeSyncVar<T>(this Player target, NetworkBehaviour networkBehaviour, ulong dirtyBit, T syncVar)
    {
        Type networkType = networkBehaviour.GetType();

        target.SendFakeCore(networkBehaviour, 
        (writer) => writer.WriteULong(0), // Write No SyncData
        (writer) =>  // Write SyncVar
        {
            // Write DrityBit always
            writer.WriteULong(dirtyBit);

            bool IsWritten = false;

            foreach (KeyValuePair<Type, ulong> kv in SubWriteClassToMinULong)
            {
                if (networkType.IsSubclassOf(kv.Key))
                {
                    if (kv.Value >= dirtyBit)
                        writer.Write(syncVar);

                    // Write always
                    writer.WriteULong(dirtyBit);

                    if (kv.Value <= dirtyBit)
                        writer.Write(syncVar);

                    IsWritten = true;
                }
            }

            if (!IsWritten)
                // we can just write normally
                writer.Write(syncVar);
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
        (writer) =>  // Write SyncVar
        {
            ulong dirtyBit = 0;
            foreach (ulong dirty in syncVars.Select(x => x.DirtyBit).ToArray())
            {
                dirtyBit |= dirty;
            }

            // Write DrityBit always
            writer.WriteULong(dirtyBit);

            bool IsWritten = false;

            foreach (var (DirtyBit, SyncVar) in syncVars.OrderBy(x => x.DirtyBit))
            {

                foreach (KeyValuePair<Type, ulong> kv in SubWriteClassToMinULong)
                {
                    if (networkType.IsSubclassOf(kv.Key))
                    {
                        if (kv.Value >= DirtyBit)
                        {
                            if (!MirrorWriterExtension.Write(SyncVar.GetType(), SyncVar, writer))
                            {
                                CL.Error($"Not found NetworkWriter for type {SyncVar.GetType()}");
                                return;
                            }
                        }

                        // Write always
                        writer.WriteULong(dirtyBit);

                        if (kv.Value <= DirtyBit)
                        {
                            if (!MirrorWriterExtension.Write(SyncVar.GetType(), SyncVar, writer))
                            {
                                CL.Error($"Not found NetworkWriter for type {SyncVar.GetType()}");
                                return;
                            }
                        }

                        IsWritten = true;
                    }
                }

                if (!IsWritten && !MirrorWriterExtension.Write(SyncVar.GetType(), SyncVar, writer))
                {
                    CL.Error($"Not found NetworkWriter for type {SyncVar.GetType()}");
                    return;
                }
            }
        });
    }
}
