namespace LabApiExtensions.Extensions;

/// <summary>
/// Extensions for <see cref="KeyValuePair{TKey, TValue}"/>.
/// </summary>
public static class KeyValuePairExtensions {
    /// <summary>
    /// Deconstructs <paramref name="kvp"/> into <paramref name="key"/> and <paramref name="value"/>.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="kvp"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, out TKey key, out TValue value)
    {
          key = kvp.Key;
          value = kvp.Value;
    }
}
