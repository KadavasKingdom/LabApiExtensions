using Mirror;
using System.Reflection;

namespace LabApiExtensions.Extensions;

/// <summary>
/// Extension for writing with mirror.
/// </summary>
public static class MirrorWriterExtension
{
    /// <summary>
    /// Writes the <paramref name="value"/> of <see langword="type"/> <typeparamref name="T"/> into <paramref name="networkWriter"/>. 
    /// </summary>
    /// <typeparam name="T">Any type that is registered as a Writer.</typeparam>
    /// <param name="value">The Value.</param>
    /// <param name="networkWriter">The network writer.</param>
    /// <returns><see langword="true"/> on success otherwise <see langword="false"/></returns>
    public static bool Write<T>(T value, NetworkWriterPooled networkWriter)
    {
        return Write(typeof(T), value, networkWriter);
    }

    /// <summary>
    /// Writes the <paramref name="value"/> of <paramref name="type"/> into <paramref name="networkWriter"/>. 
    /// </summary>
    /// <param name="type">The registerd writer type of <paramref name="value"/>.</param>
    /// <param name="value">The Value.</param>
    /// <param name="networkWriter">The network writer.</param>
    /// <returns><see langword="true"/> on success otherwise <see langword="false"/></returns>
    public static bool Write(Type type, object value, NetworkWriterPooled networkWriter)
    {
        Type genericType = typeof(Writer<>).MakeGenericType(type);
        FieldInfo writeField = genericType.GetField("write", BindingFlags.Static | BindingFlags.Public);
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
