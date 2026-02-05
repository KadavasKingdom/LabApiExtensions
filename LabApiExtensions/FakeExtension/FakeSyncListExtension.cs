using LabApiExtensions.Enums;
using Mirror;

namespace LabApiExtensions.FakeExtension;

/// <summary>
/// Extension for sending fake SyncList with <see cref="Player"/>.
/// </summary>
public static class FakeSyncListExtension
{
    /// <summary>
    /// Public representation of <see cref="SyncList{T}.Change"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListChanger<T>
    {
        /// <summary>
        /// The value to use.
        /// </summary>
        public T Value;
        /// <summary>
        /// The index to use.
        /// </summary>
        public int Index;
        /// <summary>
        /// The list operation.
        /// </summary>
        public ListOperation Operation;
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
            Operation = ListOperation.Add,
            Value = value
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
            Operation = ListOperation.Clear,
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
            Operation = ListOperation.RemoveAt,
            Index = index
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
            Operation = ListOperation.Insert,
            Index = index,
            Value = value
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
            Operation = ListOperation.Set,
            Index = index,
            Value = value
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
    /// The <paramref name="listIndex"/> starts at 1.
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
            writer.WriteByte((byte)changer.Operation);
            switch (changer.Operation)
            {
                case ListOperation.Add:
                    writer.Write(changer.Value);
                    break;
                case ListOperation.Insert:
                case ListOperation.Set:
                    writer.WriteUInt((uint)changer.Index);
                    writer.Write(changer.Value);
                    break;
                case ListOperation.RemoveAt:
                    writer.WriteUInt((uint)changer.Index);
                    break;
            }
        }, null);
    }
}
