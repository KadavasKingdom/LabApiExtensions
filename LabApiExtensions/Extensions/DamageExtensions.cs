using InventorySystem.Items.Scp1509;
using LabApiExtensions.Enums;
using PlayerRoles.PlayableScps.Scp1507;
using PlayerRoles.PlayableScps.Scp3114;
using PlayerRoles.PlayableScps.Scp939;
using PlayerStatsSystem;

namespace LabApiExtensions.Extensions;

/// <summary>
/// Extension for <see cref="DamageHandlerBase"/>.
/// </summary>
public static class DamageExtensions
{
    /// <summary>
    /// Get the <see cref="DamageType"/> from the <paramref name="handlerBase"/>.
    /// </summary>
    /// <param name="handlerBase">The Handler.</param>
    /// <returns>A <see cref="DamageType"/>.</returns>
    public static DamageType GetDamageType(this DamageHandlerBase handlerBase)
    {
        switch (handlerBase)
        {
            case RecontainmentDamageHandler:
                return DamageType.Recontainment;
            case FirearmDamageHandler:
                return DamageType.Firearm;
            case WarheadDamageHandler:
                return DamageType.Warhead;
            case UniversalDamageHandler:
                return DamageType.Universal;
            case ScpDamageHandler scpDamage:
                {
                    if (scpDamage.Attacker.IsSet && scpDamage.Attacker.Role == PlayerRoles.RoleTypeId.Scp173)
                        return DamageType.Scp173;
                    return scpDamage switch
                    {
                        Scp096DamageHandler => DamageType.Scp096,
                        Scp049DamageHandler => DamageType.Scp049,
                        _ => DamageType.Scp,
                    };
                }
            case MicroHidDamageHandler:
                return DamageType.MicroHid;
            case CustomReasonDamageHandler:
                return DamageType.Custom;
            case ExplosionDamageHandler:
                return DamageType.Explosion;
            case Scp018DamageHandler:
                return DamageType.Scp018;
            case DisruptorDamageHandler:
                return DamageType.Disruptor;
            case JailbirdDamageHandler:
                return DamageType.Jailbird;
            case Scp939DamageHandler:
                return DamageType.Scp939;
            case Scp3114DamageHandler:
                return DamageType.Scp3114;
            case Scp1507DamageHandler:
                return DamageType.Scp1507;
            case Scp956DamageHandler:
                return DamageType.Scp956;
            case SnowballDamageHandler:
                return DamageType.Snowball;
            case SilentDamageHandler:
                return DamageType.Silent;
            case Scp1509DamageHandler:
                return DamageType.Scp1509;
            case GrayCandyDamageHandler:
                return DamageType.GrayCandy;
            default:
                CL.Warn($"Damage not found! Please report this! Handler: {handlerBase}");
                return DamageType.None;
        }
    }

    /// <summary>
    /// Get the <see cref="StandardDamageHandler.Damage"/> of <paramref name="handlerBase"/>.
    /// </summary>
    /// <param name="handlerBase">The Handler.</param>
    /// <returns>-1 or the actual damage.</returns>
    public static float GetDamageValue(this DamageHandlerBase handlerBase)
    {
        if (handlerBase is StandardDamageHandler standardDamage)
            return standardDamage.Damage;
        return -1;
    }

    /// <summary>
    /// Set <see cref="StandardDamageHandler.Damage"/> with value of <paramref name="damage"/>.
    /// </summary>
    /// <param name="handlerBase">The Handler.</param>
    /// <param name="damage">The damage amount.</param>
    public static void SetDamageValue(this DamageHandlerBase handlerBase, float damage)
    {
        if (handlerBase is StandardDamageHandler standardDamage)
            standardDamage.Damage = damage;
    }

    /// <summary>
    /// Gets the value of <see cref="DamageSubType"/> in the <paramref name="handlerBase"/>.
    /// </summary>
    /// <param name="handlerBase">The Handler.</param>
    /// <param name="subType">The <see cref="DamageSubType"/> of the requested damage.</param>
    /// <returns><see langword="null"/> or the <see cref="DamageSubType"/>'s value.</returns>
    public static object GetObjectBySubType(this DamageHandlerBase handlerBase, DamageSubType subType)
    {
        if (subType == DamageSubType.Attacker_Role && handlerBase is AttackerDamageHandler attacker)
            return attacker.Attacker.Role;

        switch (handlerBase)
        {
            case FirearmDamageHandler firearm:
                {
                    if (subType == DamageSubType.AmmoType)
                        return firearm.AmmoType;
                    if (subType == DamageSubType.WeaponType)
                        return firearm.WeaponType;
                }
                return null;
            case Scp049DamageHandler scp049Damage:
                {
                    if (subType == DamageSubType.Scp049_AttackType)
                        return scp049Damage.DamageSubType;
                }
                return null;
            case Scp096DamageHandler scp096Damage:
                {
                    if (subType == DamageSubType.Scp069_AttackType)
                        return scp096Damage._attackType;
                }
                return null;
            case Scp939DamageHandler scp939Damage:
                {
                    if (subType == DamageSubType.Scp939_AttackType)
                        return scp939Damage.Scp939DamageType;
                }
                return null;
            case Scp3114DamageHandler scp3114Damage:
                {
                    if (subType == DamageSubType.Scp3114_AttackType)
                        return scp3114Damage.Subtype;
                }
                return null;
            case MicroHidDamageHandler microHidDamage:
                {
                    if (subType == DamageSubType.MicroHidFiringMode)
                        return microHidDamage.FiringMode;
                }
                return null;
            case ExplosionDamageHandler explosionDamage:
                {
                    if (subType == DamageSubType.ExplosionType)
                        return explosionDamage.ExplosionType;
                }
                return null;
            case DisruptorDamageHandler disruptorDamage:
                {
                    if (subType == DamageSubType.Disruptor_FiringState)
                        return disruptorDamage.FiringState;
                }
                return null;
            case UniversalDamageHandler universalDamage:
                {
                    if (subType == DamageSubType.UniversalSubType)
                        return (DamageUniversalType)universalDamage.TranslationId;
                }
                return null;
            default:
                return null;
        }
    }

}
