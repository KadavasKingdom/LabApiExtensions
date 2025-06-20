using AdminToys;
using Mirror;

namespace LabApiExtensions.Extensions;

// Many stuff Copied from Exiled & Mirror.

// -----------------------------------------------------------------------
// <copyright file="MirrorExtensions.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------


public static class FakeSyncExtension
{
    private static readonly Dictionary<Type, ulong> SubWriteClassToMinULong = new()
    {
        [typeof(AdminToyBase)] = 16,
    };

    // Easier syncVar
    public static void SendFakeSyncVar<T>(this Player target, NetworkBehaviour networkBehaviour, ulong dirtyBit, T syncVar)
    {
        if (target.Connection == null)
            return;

        Type networkType = networkBehaviour.GetType();

        NetworkWriterPooled writer = NetworkWriterPool.Get();
        // always writing 1 because we only change 1 value!
        Compression.CompressVarUInt(writer, 1);

        // placeholder length
        int headerPosition = writer.Position;
        writer.WriteByte(0);
        int contentPosition = writer.Position;

        // Serialize Object Sync Data.
        writer.WriteULong(0);

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
