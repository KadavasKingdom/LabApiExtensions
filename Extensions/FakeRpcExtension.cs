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
            var genericType = typeof(Writer<>).MakeGenericType(obj.GetType());
            FieldInfo? writeField = genericType.GetField("write", BindingFlags.Static | BindingFlags.Public);
            if (writeField == null)
            {
                CL.Warn($"Tried to write type: {obj.GetType()} but has no NetworkWriter!");
                return;
            }

            object? writeDelegate = writeField.GetValue(null);
            if (writeDelegate is Delegate del)
            {
                del.DynamicInvoke(networkWriterPooled, obj);
            }
            else
            {
                CL.Warn($"Writer<{obj.GetType()}>.write is not a delegate!");
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
