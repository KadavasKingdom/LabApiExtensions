namespace LabApiExtensions.Configs;

public sealed class EffectConfig
{
    public string EffectName { get; set; }
    public float Duration { get; set; }
    public byte Intensity { get; set; }

    public EffectConfig() { }
    public EffectConfig(string effectName, byte intensity = 1, float duration = 0f)
    {
        EffectName = effectName;
        Intensity = intensity;
        Duration = duration;
    }

}
