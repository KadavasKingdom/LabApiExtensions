namespace LabApiExtensions.Enums;

/// <summary>
/// Damage types until NW adds into BaseGame/LabApi.
/// </summary>
public enum DamageType
{
    /// <summary>
    /// Not a real Damage type. Use for 3rd party damage related stuff.
    /// </summary>
    Any = -1,
    /// <summary>
    /// No damage found.
    /// </summary>
    None = 0,
    /// <summary>
    /// Damage done by recontainment.
    /// </summary>
    Recontainment,
    /// <summary>
    /// Damage done by a firearm.
    /// </summary>
    Firearm,
    /// <summary>
    /// Damage done by warhead.
    /// </summary>
    Warhead,
    /// <summary>
    /// Damage done by <see cref="DamageUniversalType"/>.
    /// </summary>
    Universal,
    /// <summary>
    /// Damage done by an SCP.
    /// </summary>
    Scp,
    /// <summary>
    /// Damage done by Scp-096.
    /// </summary>
    Scp096,
    /// <summary>
    /// Damage done by Scp-049.
    /// </summary>
    Scp049,
    /// <summary>
    /// Damage done by MicroHID.
    /// </summary>
    MicroHid,
    /// <summary>
    /// Damage is by a custom reason.
    /// </summary>
    Custom,
    /// <summary>
    /// Damage done by an explosion.
    /// </summary>
    Explosion,
    /// <summary>
    /// Damage done by Scp-018.
    /// </summary>
    Scp018,
    /// <summary>
    /// Damage done by a distruptor.
    /// </summary>
    Disruptor,
    /// <summary>
    /// Damage done by a jailbird.
    /// </summary>
    Jailbird,
    /// <summary>
    /// Damage done by Scp-939.
    /// </summary>
    Scp939,
    /// <summary>
    /// Damage done by Scp-3114.
    /// </summary>
    Scp3114,
    /// <summary>
    /// Damage done by Scp-1507.
    /// </summary>
    Scp1507,
    /// <summary>
    /// Damage done by Scp-956.
    /// </summary>
    Scp956,
    /// <summary>
    /// Damage done by a snowball.
    /// </summary>
    Snowball,
    /// <summary>
    /// Damage done by Scp-173.
    /// </summary>
    Scp173,
    /// <summary>
    /// Damage is silent.
    /// </summary>
    /// <remarks>
    /// No items or ragdoll will spawn.
    /// </remarks>
    Silent,
    /// <summary>
    /// Damage done by Scp-1509.
    /// </summary>
    Scp1509,
    /// <summary>
    /// Damage done by a gray candy.
    /// </summary>
    GrayCandy,
}