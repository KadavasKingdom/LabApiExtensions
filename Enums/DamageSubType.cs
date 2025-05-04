using PlayerRoles.PlayableScps.Scp3114;
using PlayerRoles.PlayableScps.Scp939;
using PlayerStatsSystem;

namespace LabApiExtensions.Enums;

public enum DamageSubType
{
    None = 0,
    /// <summary>
    /// Check <see cref="DamageUniversalType"/>.
    /// </summary>
    UniversalSubType,
    /// <summary>
    /// Weapons inside the <see cref="ItemType"/>.
    /// </summary>
    WeaponType,
    /// <summary>
    /// Ammos inside the <see cref="ItemType"/>.
    /// </summary>
    AmmoType,
    /// <summary>
    /// Check <see cref="Scp096DamageHandler.AttackType"/>.
    /// </summary>
    Scp069_AttackType,
    /// <summary>
    /// Check <see cref="Scp049DamageHandler.AttackType"/>.
    /// </summary>
    Scp049_AttackType,
    /// <summary>
    /// Check <see cref="InventorySystem.Items.MicroHID.Modules.MicroHidFiringMode"/>.
    /// </summary>
    MicroHidFiringMode,
    /// <summary>
    /// Check <see cref="global::ExplosionType"/>.
    /// </summary>
    ExplosionType,
    /// <summary>
    /// Check <see cref="InventorySystem.Items.Firearms.Modules.DisruptorActionModule.FiringState"/>.
    /// </summary>
    Disruptor_FiringState,
    /// <summary>
    /// Check <see cref="Scp939DamageType"/>.
    /// </summary>
    Scp939_AttackType,
    /// <summary>
    /// Check <see cref="Scp3114DamageHandler.HandlerType"/>.
    /// </summary>
    Scp3114_AttackType,
}