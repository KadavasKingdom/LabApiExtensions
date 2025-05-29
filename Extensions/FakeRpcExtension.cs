using Mirror;
using System.Reflection;

namespace LabApiExtensions.Extensions;

public static class FakeRpcExtension
{
    public static void SendFakeRPC(this Player player, NetworkBehaviour networkBehaviour, int functionHash, params object[] objects)
    {
        NetworkWriterPooled networkWriterPooled = NetworkWriterPool.Get();
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
        NetworkWriterPool.Return(networkWriterPooled);
    }

    public static void SendFakeRPC(this Player player, NetworkBehaviour networkBehaviour, string functionName, params object[] objects)
    {
        var type = networkBehaviour.GetType();
        var method = type.GetMethod(functionName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        string longName = GetLongFuncName(type, method);
        int funcHash = Mirror.Extensions.GetStableHashCode(longName);
        SendFakeRPC(player, networkBehaviour, funcHash, objects);
    }

    public static string GetLongFuncName(Type type, MethodInfo method)
    {
        return $"{method.ReturnType.FullName} {type.FullName}::{method.Name}({string.Join(",", method.GetParameters().Select(x => x.ParameterType.FullName))})";
    }
}
