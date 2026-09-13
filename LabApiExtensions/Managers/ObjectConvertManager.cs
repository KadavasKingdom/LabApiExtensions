using LabApiExtensions.Configs;

namespace LabApiExtensions.Managers;

/// <summary>
/// Object parser manager.
/// </summary>
public static class ObjectConvertManager
{
    /// <summary>
    /// Parse a config <paramref name="obj"/> to <see cref="EffectConfig"/>, if not able to convert use the <paramref name="defaultValue"/>.
    /// </summary>
    /// <param name="obj">The config object.</param>
    /// <param name="defaultValue">A default value.</param>
    /// <returns>The parsed <see cref="EffectConfig"/> or <see langword="default"/>.</returns>
    public static EffectConfig? ParseToEffectConfig(object obj, EffectConfig? defaultValue = default)
    {
        if (obj == null)
        {
            return defaultValue;
        }

        if (typeof(EffectConfig) == obj.GetType())
        {
            return (EffectConfig)obj;
        }

        if (typeof(Dictionary<object, object>) == obj.GetType())
        {
            if (obj is not Dictionary<object, object> dict)
            {
                return defaultValue;
            }

            EffectConfig effectConfig = new();
            foreach (var item in dict)
            {
                string kstr = (string)item.Key;
                string vstr = (string)item.Value;
                if (kstr.Contains("effect_name"))
                {
                    effectConfig.EffectName = vstr;
                }

                if (kstr.Contains("duration"))
                {
                    if (!float.TryParse(vstr, out var result))
                    {
                        continue;
                    }

                    effectConfig.Duration = result;
                }

                if (kstr.Contains("intensity"))
                {
                    if (!byte.TryParse(vstr, out var result))
                    {
                        continue;
                    }

                    effectConfig.Intensity = result;
                }
            }

            return effectConfig;
        }

        return defaultValue;
    }

    /// <summary>
    /// Parse a config <paramref name="obj"/> to <see cref="int"/>, if not able to convert use the <paramref name="defaultValue"/>.
    /// </summary>
    /// <param name="obj">The config object.</param>
    /// <param name="defaultValue">A default value.</param>
    /// <returns>The parsed <see langword="int"/> or <see langword="default"/>.</returns>
    public static int ParseToInt(object obj, int defaultValue = default)
    {
        if (obj == null)
        {
           return defaultValue;
        }

        if (typeof(int) == obj.GetType())
        {
            return (int)obj;
        }

        if (typeof(string) == obj.GetType())
        {
            string str_obj = (string)obj;
            if (int.TryParse(str_obj, out int res))
            {
                return res;
            }
        }

        return defaultValue;
    }

    /// <summary>
    /// Parse a config <paramref name="obj"/> to <see cref="bool"/>, if not able to convert use the <paramref name="defaultValue"/>.
    /// </summary>
    /// <param name="obj">The config object.</param>
    /// <param name="defaultValue">A default value.</param>
    /// <returns>The parsed <see langword="bool"/> or <see langword="default"/>.</returns>
    public static bool ParseToBool(object obj, bool defaultValue = default)
    {
        if (obj == null)
        {
            return defaultValue;
        }

        if (typeof(bool) == obj.GetType())
        {
            return (bool)obj;
        }

        if (typeof(string) == obj.GetType())
        {
            string str_obj = (string)obj;
            if (bool.TryParse(str_obj, out bool res))
            {
                return res;
            }
        }

        return defaultValue;
    }

    /// <summary>
    /// Parse a config <paramref name="obj"/> to enum as <typeparamref name="T"/>, if not able to convert use the <paramref name="defaultValue"/>.
    /// </summary>
    /// <typeparam name="T">Any enum type.</typeparam>
    /// <param name="obj">The config object.</param>
    /// <param name="defaultValue">A default value.</param>
    /// <returns>The parsed <typeparamref name="T"/> or <see langword="default"/>.</returns>
    public static T ParseToEnum<T>(object obj, T defaultValue = default)
        where T : struct
    {
        if (obj == null)
        {
            return defaultValue;
        }

        if (typeof(T) == obj.GetType())
        {
            return (T)obj;
        }

        if (typeof(string) == obj.GetType())
        {
            string str_obj = (string)obj;
            if (Enum.TryParse(str_obj, true, out T result))
            {
                return result;
            }
        }

        return defaultValue;
    }
}
