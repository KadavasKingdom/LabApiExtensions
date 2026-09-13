namespace LabApiExtensions.Configs;

/// <summary>
/// Easy access for effect related methods.
/// </summary>
public sealed class EffectConfig
{
    /// <inheritdoc cref="EffectConfig"/>
    /// <param name="effectName">The effect name.</param>
    /// <param name="intensity">The effect intensity.</param>
    /// <param name="duration">The effect duration.</param>
    public EffectConfig(string effectName, byte intensity = 1, float duration = 0f)
    {
        EffectName = effectName;
        Intensity = intensity;
        Duration = duration;
    }

    /// <inheritdoc cref="EffectConfig"/>
    internal EffectConfig()
    {
        EffectName = string.Empty;
    }

    /// <summary>
    /// Gets or sets the name of the effect.
    /// </summary>
    public string EffectName { get; set; }

    /// <summary>
    /// Gets or sets the duration of the effect.
    /// </summary>
    public float Duration { get; set; }

    /// <summary>
    /// Gets or sets the intensity of the effect.
    /// </summary>
    public byte Intensity { get; set; }
}
