using UnityEngine;

namespace LabApiExtensions.Extensions;

public static class RNGExtension
{
    /// <summary>
    /// Getting a random element from the <paramref name="dic"/>, if could not able to get one use the <paramref name="default_val"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dic"></param>
    /// <param name="default_val"></param>
    /// <returns></returns>
    public static T GetRandomWeight<T>(this Dictionary<T, int> dic, T default_val = default)
    {
        var sum = dic.Values.Sum();
        int chance = URandom.Range(1, sum + 1);
        T return_t = default_val;
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
    /// Getting a random element from the <paramref name="dic"/> with help of <paramref name="predicate"/> to filter, if could not able to get one use the <paramref name="default_val"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dic"></param>
    /// <param name="predicate"></param>
    /// <param name="default_val"></param>
    /// <returns></returns>
    public static T GetRandomWeight<T>(this Dictionary<T, int> dic, Func<KeyValuePair<T, int>, bool> predicate, T default_val = default)
    {
        return dic.Where(predicate).ToDictionary(x => x.Key, x => x.Value).GetRandomWeight(default_val);
    }

    public static T GetRandom<T>(this IEnumerable<T> enumerator)
    {
        return enumerator.ToList().RandomItem();
    }

    /// <summary>
    /// Gets a random <see cref="Vector3"/>.
    /// </summary>
    /// <param name="min">Minimum value.</param>
    /// <param name="max">Maximum value.</param>
    /// <returns>A new <see cref="Vector3"/></returns>
    public static Vector3 GetVector3(float min, float max)
    {
        return new(URandom.Range(min, max), RandomGenerator.GetFloat(min, max), RandomGenerator.GetFloat(min, max));
    }
}
