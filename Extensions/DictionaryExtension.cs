namespace LabApiExtensions.Extensions;

public static class DictionaryExtension
{
    public static Value Get<Key, Value>(this IDictionary<Key, Value> dic, Key key, Value default_t = default)
    {
        if (dic.TryGetValue(key, out Value val))
            return val;
        return default_t;
    }
}
