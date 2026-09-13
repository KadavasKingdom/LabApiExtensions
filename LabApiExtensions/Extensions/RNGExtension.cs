using UnityEngine;

namespace LabApiExtensions.Extensions;

/// <summary>
/// Extension with <see cref="URandom"/>.
/// </summary>
public static class RNGExtension
{
    /// <summary>
    /// Getting a random element from the <paramref name="dic"/>, if could not able to get one use the <paramref name="defaultValue"/>.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    /// <param name="dic">The dictionary to get the weight.</param>
    /// <param name="defaultValue">The default value should return.</param>
    /// <returns>The random value from the <paramref name="dic"/> or <paramref name="defaultValue"/>.</returns>
    public static T? GetRandomWeight<T>(this Dictionary<T, int> dic, T? defaultValue = default)
    {
        if (dic == null)
        {
            throw new ArgumentNullException(nameof(dic));
        }

        var sum = dic.Values.Sum();
        int chance = URandom.Range(1, sum + 1);
        T? return_t = defaultValue;
        foreach (var kv in dic)
        {
            if (chance <= kv.Value)
            {
                return_t = kv.Key;
                break;
            }

            chance -= kv.Value;
        }

        return return_t;
    }

    /// <summary>
    /// Getting a random element from the <paramref name="dic"/> with help of <paramref name="predicate"/> to filter, if could not able to get one use the <paramref name="defaultValue"/>.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    /// <param name="dic">The dictionary to get the weight.</param>
    /// <param name="predicate">The predicate to check before randomizing.</param>
    /// <param name="defaultValue">The default value should return.</param>
    /// <returns>The random value from the <paramref name="dic"/> or <paramref name="defaultValue"/>.</returns>
    public static T? GetRandomWeight<T>(this Dictionary<T, int> dic, Func<KeyValuePair<T, int>, bool> predicate, T? defaultValue = default)
    {
        return dic.Where(predicate).ToDictionary(x => x.Key, x => x.Value).GetRandomWeight(defaultValue);
    }

    /// <summary>
    /// Get random item from <paramref name="enumerator"/>.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    /// <param name="enumerator">The enumerator to get random value from.</param>
    /// <returns>The random value from the <paramref name="enumerator"/> or <see langword="default"/>.</returns>
    public static T? GetRandom<T>(this IEnumerable<T> enumerator)
    {
        if (enumerator.ToList().TryGetRandomItem(out T random))
        {
            return random;
        }

        return default;
    }

    /// <summary>
    /// Gets a random <see cref="Vector3"/>.
    /// </summary>
    /// <param name="min">Minimum value.</param>
    /// <param name="max">Maximum value.</param>
    /// <returns>A new <see cref="Vector3"/>.</returns>
    public static Vector3 GetVector3(float min, float max)
    {
        return new(URandom.Range(min, max), URandom.Range(min, max), URandom.Range(min, max));
    }
}
