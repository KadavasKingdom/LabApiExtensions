using Mirror;
using System.Reflection;

namespace LabApiExtensions.Extensions;

public static class MirrorWriterExtension
{
    public static bool Write<T>(T value, NetworkWriterPooled networkWriter)
    {
        return Write(typeof(T), value, networkWriter);
    }

    public static bool Write(Type type, object value, NetworkWriterPooled networkWriter)
    {
        var genericType = typeof(Writer<>).MakeGenericType(type);
        FieldInfo? writeField = genericType.GetField("write", BindingFlags.Static | BindingFlags.Public);
        if (writeField == null)
        {
            CL.Warn($"Tried to write type: {type} but has no NetworkWriter!");
            return false;
        }

        if (writeField.GetValue(null) is not Delegate del)
        {
            CL.Warn($"Writer<{type}>.write is not a delegate!");
            return false;
        }
        del.DynamicInvoke(networkWriter, value);
        return true;
    }
}
