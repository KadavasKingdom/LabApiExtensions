using LabApiExtensions.Configs;
using CustomPlayerEffects;

namespace LabApiExtensions.Extensions;

public static class EffectExtension
{
    public static StatusEffectBase GetEffectFromName(this Player player, string name)
    {
        player.TryGetEffect(name, out StatusEffectBase statusEffect);
        return statusEffect;
    }

    public static void EnableEffect(this Player player, EffectConfig effectConfig, bool addDuration = false)
    {
        var effect = GetEffectFromName(player, effectConfig.EffectName);
        player.EnableEffect(effect, effectConfig.Intensity, effectConfig.Duration, addDuration);
    }

    public static void EnableEffect(this Player player, string name, byte intensity = 1, float duration = 0, bool addDuration = false)
    {
        var effect = GetEffectFromName(player, name);
        player.EnableEffect(effect, intensity, duration, addDuration);
    }

    public static void DisableEffect(this Player player, string name)
    {
        var effect = GetEffectFromName(player, name);
        player.DisableEffect(effect);
    }
}
