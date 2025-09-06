using LabApiExtensions.Configs;
using CustomPlayerEffects;

namespace LabApiExtensions.Extensions;

public static class EffectExtension
{
    /// <summary>
    /// Gets the <see cref="StatusEffectBase"/> from the <paramref name="name"/>.
    /// </summary>
    /// <param name="player">The Player.</param>
    /// <param name="name">Name of the effect.</param>
    /// <returns>Existing <see cref="StatusEffectBase"/> or <see langword="null"/></returns>
    public static StatusEffectBase GetEffectFromName(this Player player, string name)
    {
        player.TryGetEffect(name, out StatusEffectBase statusEffect);
        return statusEffect;
    }

    /// <summary>
    /// Trying to enable effect for <paramref name="player"/> with parameters via <paramref name="effectConfig"/>.
    /// </summary>
    /// <param name="player">The Player.</param>
    /// <param name="effectConfig">Effect related config.</param>
    /// <param name="addDuration">Add to previous duration.</param>
    /// <returns><see langword="true"/> on success otherwise <see langword="false"/></returns>
    public static bool EnableEffect(this Player player, EffectConfig effectConfig, bool addDuration = false)
    {
        return player.EnableEffect(effectConfig.EffectName, effectConfig.Intensity, effectConfig.Duration, addDuration);
    }

    /// <summary>
    /// Trying to enable effect for <paramref name="player"/> via parameters.
    /// </summary>
    /// <param name="player">The Player.</param>
    /// <param name="name">Name of the effect.</param>
    /// <param name="intensity">Intensity of the effect.</param>
    /// <param name="duration">Duration of the effect.</param>
    /// <param name="addDuration">Add to previous duration.</param>
    /// <returns><see langword="true"/> on success otherwise <see langword="false"/></returns>
    /// <remarks>
    /// A <paramref name="duration"/> of 0 means that it will not expire.
    /// </remarks>
    public static bool EnableEffect(this Player player, string name, byte intensity = 1, float duration = 0, bool addDuration = false)
    {
        var effect = GetEffectFromName(player, name);
        if (effect == null)
            return false;
        player.EnableEffect(effect, intensity, duration, addDuration);
        return true;
    }

    /// <summary>
    /// Trying to enable effect for <paramref name="player"/> if the effect hasnt been enabled yet via parameters.
    /// </summary>
    /// <param name="player">The Player.</param>
    /// <param name="name">Name of the effect.</param>
    /// <param name="intensity">Intensity of the effect.</param>
    /// <param name="duration">Duration of the effect.</param>
    /// <param name="addDuration">Add to previous duration.</param>
    /// <returns><see langword="true"/> on success and effect has not been enabled otherwise <see langword="false"/></returns>
    /// <remarks>
    /// A <paramref name="duration"/> of 0 means that it will not expire.
    /// </remarks>
    public static bool EnableEffectIfNotExists(this Player player, string name, byte intensity = 1, float duration = 0, bool addDuration = false)
    {
        var effect = GetEffectFromName(player, name);
        if (effect == null)
            return false;
        if (effect.IsEnabled)
            return false;
        player.EnableEffect(effect, intensity, duration, addDuration);
        return true;
    }

    /// <summary>
    /// Trying to disable effect for <paramref name="player"/>.
    /// </summary>
    /// <param name="player">The Player.</param>
    /// <param name="name">Name of the effect.</param>
    /// <returns><see langword="true"/> on success and effect has not been enabled otherwise <see langword="false"/></returns>
    public static bool DisableEffect(this Player player, string name)
    {
        var effect = GetEffectFromName(player, name);
        if (effect == null)
            return false;
        player.DisableEffect(effect);
        return true;
    }
}
