namespace LabApiExtensions.Extensions;

/// <summary>
/// Extension for <see cref="IDictionary{TKey, TValue}"/>.
/// </summary>
public static class DictionaryExtension
{
    /// <summary>
    /// Get value from a dictionary.
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    /// <param name="dic">The dictionary to get values from.</param>
    /// <param name="key">The key whose value to get.</param>
    /// <param name="default_t">The default value if <paramref name="key"/> not found.</param>
    /// <returns>The value from the <paramref name="dic"/> or <paramref name="default_t"/>. </returns>
    public static Value Get<Key, Value>(this IDictionary<Key, Value> dic, Key key, Value default_t = default)
    {
        if (dic.TryGetValue(key, out Value val))
            return val;
        return default_t;
    }
}
