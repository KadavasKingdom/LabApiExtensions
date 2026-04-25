using LabApiExtensions.Extensions;
using Mirror;
using System.Reflection;

namespace LabApiExtensions.FakeExtension;

/// <summary>
/// Extension for sending fake RPC with <see cref="Player"/>.
/// </summary>
public static class FakeRpcExtension
{
    /// <summary>
    /// Send a fake RPC to <paramref name="player"/>.
    /// </summary>
    /// <param name="player">The target player to send to.</param>
    /// <param name="networkBehaviour">The networking component.</param>
    /// <param name="functionHash">The RPC function hash.</param>
    /// <param name="objects">Parameters for the <paramref name="functionHash"/>.</param>
    public static void SendFakeRPC(this Player player, NetworkBehaviour networkBehaviour, int functionHash, params object[] objects)
    {
        using NetworkWriterPooled networkWriterPooled = NetworkWriterPool.Get();
        foreach (object obj in objects)
        {
            if (!MirrorWriterExtension.Write(obj.GetType(), obj, networkWriterPooled))
            {
                CL.Error($"Not found NetworkWriter for type {obj.GetType()}");
                return;
            }
        }
        player.Connection.Send(new RpcMessage()
        {
            netId = networkBehaviour.netId,
            componentIndex = networkBehaviour.ComponentIndex,
            functionHash = (ushort)functionHash,
            payload = networkWriterPooled.ToArraySegment()
        });
    }

    /// <summary>
    /// Send a fake RPC to <paramref name="player"/>.
    /// </summary>
    /// <param name="player">The target player to send to.</param>
    /// <param name="networkBehaviour">The networking component.</param>
    /// <param name="functionName">The plain function name.</param>
    /// <param name="objects">Parameters for the <paramref name="functionName"/>.</param>
    /// <remarks>
    /// In <paramref name="functionName"/> use <see langword="nameof"/>.
    /// </remarks>
    public static void SendFakeRPC(this Player player, NetworkBehaviour networkBehaviour, string functionName, params object[] objects)
    {
        Type type = networkBehaviour.GetType();
        MethodInfo method = type.GetMethod(functionName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        string longName = GetLongFuncName(type, method);
        int funcHash = longName.GetStableHashCode();
        player.SendFakeRPC(networkBehaviour, funcHash, objects);
    }

    /// <summary>
    /// Gets the mirror compatible long function name from the <paramref name="type"/> and <paramref name="method"/>.
    /// </summary>
    /// <param name="type">The Type.</param>
    /// <param name="method">The Method.</param>
    /// <returns>The long function name.</returns>
    public static string GetLongFuncName(Type type, MethodInfo method)
    {
        return $"{method.ReturnType.FullName} {type.FullName}::{method.Name}({string.Join(",", method.GetParameters().Select(x => x.ParameterType.FullName))})";
    }
}
