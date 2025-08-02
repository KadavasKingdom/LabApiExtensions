﻿using LabApiExtensions.Enums;
using PlayerRoles.PlayableScps.Scp1507;
using PlayerRoles.PlayableScps.Scp3114;
using PlayerRoles.PlayableScps.Scp939;
using PlayerStatsSystem;

namespace LabApiExtensions.Extensions;

public static class DamageExtensions
{
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
            default:
                return DamageType.None;
        }
    }

    public static float GetDamageValue(this DamageHandlerBase handlerBase)
    {
        if (handlerBase is StandardDamageHandler standardDamage)
            return standardDamage.Damage;
        return -1;
    }

    public static void SetDamageValue(this DamageHandlerBase handlerBase, float damage)
    {
        if (handlerBase is StandardDamageHandler standardDamage)
            standardDamage.Damage = damage;
    }

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
            case Scp096DamageHandler scp096Damage:
                {
                    if (subType == DamageSubType.Scp069_AttackType)
                        return scp096Damage._attackType;
                }
                return null;
            case Scp049DamageHandler scp049Damage:
                {
                    if (subType == DamageSubType.Scp049_AttackType)
                        return scp049Damage.DamageSubType;
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
