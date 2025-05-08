using AdminToys;
using Mirror;
using PlayerRoles;
using System.Collections.ObjectModel;
using System.Reflection;

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
    private static readonly Dictionary<Type, MethodInfo> WriterExtensionsValue = [];
    private static readonly ReadOnlyDictionary<Type, MethodInfo> ReadOnlyWriterExtensionsValue = new(WriterExtensionsValue);
    private static readonly List<Type> SubClassWriteExtra = [typeof(AdminToyBase)];


    /// <summary>
    /// Gets <see cref="MethodInfo"/> corresponding to <see cref="Type"/>.
    /// </summary>
    public static ReadOnlyDictionary<Type, MethodInfo> WriterExtensions
    {
        get
        {
            if (WriterExtensionsValue.Count == 0)
            {
                foreach (MethodInfo method in typeof(NetworkWriterExtensions).GetMethods().Where(x => !x.IsGenericMethod && x.GetCustomAttribute(typeof(ObsoleteAttribute)) == null && (x.GetParameters()?.Length == 2)))
                    WriterExtensionsValue.Add(method.GetParameters().First(x => x.ParameterType != typeof(NetworkWriter)).ParameterType, method);

                Type fuckNorthwood = Assembly.GetAssembly(typeof(RoleTypeId)).GetType("Mirror.GeneratedNetworkCode");
                foreach (MethodInfo method in fuckNorthwood.GetMethods().Where(x => !x.IsGenericMethod && (x.GetParameters()?.Length == 2) && (x.ReturnType == typeof(void))))
                    WriterExtensionsValue.Add(method.GetParameters().First(x => x.ParameterType != typeof(NetworkWriter)).ParameterType, method);

                foreach (Type serializer in typeof(ServerConsole).Assembly.GetTypes().Where(x => x.Name.EndsWith("Serializer")))
                {
                    foreach (MethodInfo method in serializer.GetMethods().Where(x => (x.ReturnType == typeof(void)) && x.Name.StartsWith("Write")))
                        WriterExtensionsValue.Add(method.GetParameters().First(x => x.ParameterType != typeof(NetworkWriter)).ParameterType, method);
                }
            }

            return ReadOnlyWriterExtensionsValue;
        }
    }

    // Easier syncVar
    public static void SendFakeSyncVar<T>(this Player target, NetworkBehaviour networkBehaviour, ulong dirtyBit, T syncVar)
    {
        if (target.Connection == null)
            return;
        NetworkWriterPooled writer = NetworkWriterPool.Get();
        // always writing 1?
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

        if (WriterExtensions.TryGetValue(typeof(T), out var method))
        {
            method.Invoke(null, [writer, syncVar]);
        }
        else
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
