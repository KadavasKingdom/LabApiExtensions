using AdminToys;
using Mirror;
namespace LabApiExtensions.Extensions;

// Many stuff Copied from Exiled.

// -----------------------------------------------------------------------
// <copyright file="MirrorExtensions.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------


public static class FakeSyncExtension
{
    private static readonly List<Type> SubClassWriteExtra = [typeof(AdminToyBase)];

    // Easier syncVar
    public static void SendFakeSyncVar<T>(this Player target, NetworkBehaviour networkBehaviour, ulong dirtyBit, T syncVar)
    {
        if (target.Connection == null)
            return;
        NetworkWriterPooled writer = NetworkWriterPool.Get();
        // always writing 1 because we only change 1 value!
        Compression.CompressVarUInt(writer, 1);

        // placeholder length
        int headerPosition = writer.Position;
        writer.WriteByte(0);
        int contentPosition = writer.Position;

        // Serialize stuff. we dont want to ser objects only sync data
        writer.WriteULong(0);
        
        // some class write this stuff twice.
        foreach (var item in SubClassWriteExtra)
        {
            if (networkBehaviour.GetType().IsSubclassOf(item))
            {
                writer.WriteULong(0);
            }
        }

        writer.WriteULong(dirtyBit);

        if (!MirrorWriterExtension.Write(syncVar, writer))
        {
            CL.Error($"Not found NetworkWriter for type {typeof(T)}");
            return;
        }

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
