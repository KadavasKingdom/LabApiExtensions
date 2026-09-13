namespace LabApiExtensions.Extensions;

/// <summary>
/// Extension for <see cref="IDictionary{TKey, TValue}"/>.
/// </summary>
public static class DictionaryExtension
{
    /// <summary>
    /// Get value from a dictionary.
    /// </summary>
    /// <typeparam name="TKey">Any type for key.</typeparam>
    /// <typeparam name="TValue">Any type for value.</typeparam>
    /// <param name="dic">The dictionary to get values from.</param>
    /// <param name="key">The key whose value to get.</param>
    /// <param name="defaultT">The default value if <paramref name="key"/> not found.</param>
    /// <returns>The value from the <paramref name="dic"/> or <paramref name="defaultT"/>.</returns>
    public static TValue? Get<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue? defaultT = default)
    {
        if (dic == null)
        {
            throw new ArgumentNullException(nameof(dic));
        }

        if (dic.TryGetValue(key, out TValue val))
        {
            return val;
        }

        return defaultT;
    }
}
