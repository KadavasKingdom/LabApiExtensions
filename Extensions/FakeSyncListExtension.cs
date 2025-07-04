using LabApiExtensions.Enums;
using Mirror;

namespace LabApiExtensions.Extensions;

public static class FakeSyncListExtension
{
    public class ListChanger<T>
    {
        public T value;
        public int index;
        public ListOperation operation;
    }

    public static void SendFakeSyncListAdd<T>(this Player target, NetworkBehaviour networkBehaviour, ulong listIndex, T value)
        => SendFakeSyncList<T>(target, networkBehaviour, listIndex, new()
        {
            operation = ListOperation.Add,
            value = value
        });

    public static void SendFakeSyncListClear<T>(this Player target, NetworkBehaviour networkBehaviour, ulong listIndex)
        => SendFakeSyncList<T>(target, networkBehaviour, listIndex, new()
        {
            operation = ListOperation.Clear,
        });

    public static void SendFakeSyncListRemoveAt<T>(this Player target, NetworkBehaviour networkBehaviour, ulong listIndex, int index)
        => SendFakeSyncList<T>(target, networkBehaviour, listIndex, new()
        {
            operation = ListOperation.RemoveAt,
            index = index
        });

    public static void SendFakeSyncListInsert<T>(this Player target, NetworkBehaviour networkBehaviour, ulong listIndex, int index, T value)
        => SendFakeSyncList<T>(target, networkBehaviour, listIndex, new()
        {
            operation = ListOperation.Insert,
            index = index,
            value = value
        });

    public static void SendFakeSyncListSet<T>(this Player target, NetworkBehaviour networkBehaviour, ulong listIndex, int index, T value)
        => SendFakeSyncList<T>(target, networkBehaviour, listIndex, new()
        {
            operation = ListOperation.Set,
            index = index,
            value = value
        });


    public static void SendFakeSyncList<T>(this Player target, NetworkBehaviour networkBehaviour, ulong listIndex, ListChanger<T> changer)
    {
        target.SendFakeCore(networkBehaviour,
        (writer) => 
        {
            // Serialize Object Sync Data.
            writer.WriteULong(listIndex);

            // Copy from OnSerializeDelta
            writer.WriteUInt(1);
            writer.WriteByte((byte)changer.operation);
            switch (changer.operation)
            {
                case ListOperation.Add:
                    writer.Write(changer.value);
                    break;
                case ListOperation.Insert:
                case ListOperation.Set:
                    writer.WriteUInt((uint)changer.index);
                    writer.Write(changer.value);
                    break;
                case ListOperation.RemoveAt:
                    writer.WriteUInt((uint)changer.index);
                    break;
            }
        },
        (writer) => writer.WriteULong(0) // Write No SyncData
        );
    }
}
