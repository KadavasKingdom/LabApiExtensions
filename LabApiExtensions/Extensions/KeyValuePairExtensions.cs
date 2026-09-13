namespace LabApiExtensions.Extensions;

/// <summary>
/// Extensions for <see cref="KeyValuePair{TKey, TValue}"/>.
/// </summary>
public static class KeyValuePairExtensions
{
    /// <summary>
    /// Deconstructs <paramref name="kvp"/> into <paramref name="key"/> and <paramref name="value"/>.
    /// </summary>
    /// <typeparam name="TKey">Any key type.</typeparam>
    /// <typeparam name="TValue">Any value type.</typeparam>
    /// <param name="kvp">The key value pair.</param>
    /// <param name="key">The deconstructed key.</param>
    /// <param name="value">The deconstructed value.</param>
    public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, out TKey key, out TValue value)
    {
        key = kvp.Key;
        value = kvp.Value;
    }
}
