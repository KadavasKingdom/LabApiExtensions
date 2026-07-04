namespace LabApiExtensions.Extensions;

/// <summary>
/// Extensions for <see cref="KeyValuePair{TKey, TValue}"/>.
/// </summary>
public static class KeyValuePairExtensions {
  public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, out TKey key, out TValue value)
  {
      key = kvp.Key;
      value = kvp.Value;
  }
}
