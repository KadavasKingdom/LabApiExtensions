namespace LabApiExtensions.Enums;

/// <summary>
/// Universal damage type.
/// </summary>
public enum DamageUniversalType : byte
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Recontained,
    Warhead,
    Scp049,
    Unknown,
    Asphyxiated,
    Bleeding,
    Falldown,
    PocketDecay,
    Decontamination,
    Poisoned,
    Scp207,
    SeveredHands,
    MicroHID,
    Tesla,
    Explosion,
    Scp096,
    Scp173,
    Scp939Lunge,
    Zombie,
    BulletWounds,
    Crushed,
    UsedAs106Bait,
    FriendlyFireDetector,
    Hypothermia,
    CardiacArrest,
    Scp939Other,
    Scp3114Slap,
    MarshmallowMan,
    Scp1344,
    Scp1507Peck,
    Scp127Bullets,
    Scp1509,
    None = 255,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}