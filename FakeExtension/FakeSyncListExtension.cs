using LabApiExtensions.Enums;
using Mirror;

namespace LabApiExtensions.FakeExtension;

public static class FakeSyncListExtension
{
    /// <summary>
    /// Public representation of <see cref="SyncList{T}.Change"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListChanger<T>
    {
        public T value;
        public int index;
        public ListOperation operation;
    }

    /// <summary>
    /// Sending fake add to the list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target">The target to send to.</param>
    /// <param name="networkBehaviour">The behaviour to change.</param>
    /// <param name="listIndex">The index of the list.</param>
    /// <param name="value"></param>
    public static void SendFakeSyncListAdd<T>(this Player target, NetworkBehaviour networkBehaviour, ulong listIndex, T value)
        => target.SendFakeSyncList<T>(networkBehaviour, listIndex, new()
        {
            operation = ListOperation.Add,
            value = value
        });

    /// <summary>
    /// Sending fake clear to the list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target">The target to send to.</param>
    /// <param name="networkBehaviour">The behaviour to change.</param>
    /// <param name="listIndex">The index of the list.</param>
    public static void SendFakeSyncListClear<T>(this Player target, NetworkBehaviour networkBehaviour, ulong listIndex)
        => target.SendFakeSyncList<T>(networkBehaviour, listIndex, new()
        {
            operation = ListOperation.Clear,
        });

    /// <summary>
    /// Sending fake remove at to the list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target">The target to send to.</param>
    /// <param name="networkBehaviour">The behaviour to change.</param>
    /// <param name="listIndex">The index of the list.</param>
    /// <param name="index">The index to remove.</param>
    public static void SendFakeSyncListRemoveAt<T>(this Player target, NetworkBehaviour networkBehaviour, ulong listIndex, int index)
        => target.SendFakeSyncList<T>(networkBehaviour, listIndex, new()
        {
            operation = ListOperation.RemoveAt,
            index = index
        });

    /// <summary>
    /// Sending fake insert to the list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target">The target to send to.</param>
    /// <param name="networkBehaviour">The behaviour to change.</param>
    /// <param name="listIndex">The index of the list.</param>
    /// <param name="index">The index to insert.</param>
    /// <param name="value">The value to insert.</param>
    public static void SendFakeSyncListInsert<T>(this Player target, NetworkBehaviour networkBehaviour, ulong listIndex, int index, T value)
        => target.SendFakeSyncList<T>(networkBehaviour, listIndex, new()
        {
            operation = ListOperation.Insert,
            index = index,
            value = value
        });

    /// <summary>
    /// Sending fake set to the list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target">The target to send to.</param>
    /// <param name="networkBehaviour">The behaviour to change.</param>
    /// <param name="listIndex">The index of the list.</param>
    /// <param name="index">The index to set.</param>
    /// <param name="value">The value to set.</param>
    public static void SendFakeSyncListSet<T>(this Player target, NetworkBehaviour networkBehaviour, ulong listIndex, int index, T value)
        => target.SendFakeSyncList<T>(networkBehaviour, listIndex, new()
        {
            operation = ListOperation.Set,
            index = index,
            value = value
        });


    /// <summary>
    /// Sending fake sync for list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="target">The target to send to.</param>
    /// <param name="networkBehaviour">The behaviour to change.</param>
    /// <param name="listIndex">The index of the list.</param>
    /// <param name="changer">Change related action.</param>
    /// <remarks>
    /// The <paramref name="listIndex"/> stats at 1.
    /// </remarks>
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
