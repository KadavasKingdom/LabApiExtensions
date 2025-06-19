using LabApiExtensions.Configs;
using CustomPlayerEffects;

namespace LabApiExtensions.Extensions;

public static class EffectExtension
{
    public static StatusEffectBase? GetEffectFromName(this Player player, string name)
    {
        player.TryGetEffect(name, out StatusEffectBase statusEffect);
        return statusEffect;
    }

    public static bool EnableEffect(this Player player, EffectConfig effectConfig, bool addDuration = false)
    {
        var effect = GetEffectFromName(player, effectConfig.EffectName);
        if (effect == null)
            return false;
        player.EnableEffect(effect, effectConfig.Intensity, effectConfig.Duration, addDuration);
        return true;
    }

    public static bool EnableEffect(this Player player, string name, byte intensity = 1, float duration = 0, bool addDuration = false)
    {
        var effect = GetEffectFromName(player, name);
        if (effect == null)
            return false;
        player.EnableEffect(effect, intensity, duration, addDuration);
        return true;
    }

    public static bool EnableEffectIfNotExists(this Player player, string name, byte intensity = 1, float duration = 0, bool addDuration = false)
    {
        var effect = GetEffectFromName(player, name);
        if (effect == null)
            return false;
        if (!effect.IsEnabled)
            player.EnableEffect(effect, intensity, duration, addDuration);
        return true;
    }

    public static bool DisableEffect(this Player player, string name)
    {
        var effect = GetEffectFromName(player, name);
        if (effect == null)
            return false;
        player.DisableEffect(effect);
        return true;
    }
}
