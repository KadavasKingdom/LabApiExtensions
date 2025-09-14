using LabApi.Features.Extensions;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using Mirror;
using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using PlayerRoles.FirstPersonControl.NetworkMessages;
using PlayerRoles.PlayableScps.Scp049.Zombies;
using PlayerRoles.PlayableScps.Scp1507;
using PlayerStatsSystem;
using RelativePositioning;
using UnityEngine;

namespace LabApiExtensions.Managers;

public static class FakeRoleManager
{
    static readonly Dictionary<ReferenceHub, RoleTypeId> FakeRoles = [];

    static FakeRoleManager()
    {
        PlayerEvents.ChangingRole += PlayerEvents_ChangingRole;
        PlayerEvents.Left += PlayerEvents_Left;
        FpcServerPositionDistributor.RoleSyncEvent += FpcServerPositionDistributor_RoleSyncEvent;
    }

    private static void PlayerEvents_ChangingRole(PlayerChangingRoleEventArgs ev)
    {
        if (ev.IsAllowed)
            RemoveFakeRole(ev.Player);
    }

    private static void PlayerEvents_Left(PlayerLeftEventArgs ev)
    {
        RemoveFakeRole(ev.Player);
    }

    public static void AddFakeRole(this Player player, RoleTypeId roleType)
    {
        if (roleType is RoleTypeId.None or RoleTypeId.Destroyed)
            return;
        if (player.Connection != null)
            FakeRoles[player.ReferenceHub] = roleType;
    }

    public static void RemoveFakeRole(this Player player)
    {
        FakeRoles.Remove(player.ReferenceHub);
    }

    private static RoleTypeId FpcServerPositionDistributor_RoleSyncEvent(ReferenceHub hub, ReferenceHub receiver, RoleTypeId roleType, Mirror.NetworkWriter writer)
    {
        if (FakeRoles.TryGetValue(hub, out var value))
        {
            if (value == roleType)
                return value;
            WriteExtraForRole(hub, value, writer);
            return value;
        }
        return roleType;
    }

    private static void WriteExtraForRole(ReferenceHub hub, RoleTypeId roleType, NetworkWriter writer)
    {
        PlayerRoleBase roleBase = roleType.GetRoleBase();

        if (roleBase is HumanRole { UsesUnitNames: not false })
        {
            writer.WriteByte(0);
        }

        if (roleBase is ZombieRole)
        {
            writer.WriteUShort((ushort)Mathf.Clamp(Mathf.CeilToInt(hub.playerStats.GetModule<HealthStat>().MaxValue), 0, 65535));
            writer.WriteBool(true);
        }

        if (roleBase is Scp1507Role)
        {
            writer.WriteByte((byte)hub.roleManager.CurrentRole.ServerSpawnReason);
        }

        FpcStandardRoleBase fpcStandardRoleBase = roleBase as FpcStandardRoleBase;
        if (fpcStandardRoleBase != null)
        {
            if (hub.roleManager.CurrentRole is FpcStandardRoleBase fpcStandardRoleBase2)
            {
                fpcStandardRoleBase = fpcStandardRoleBase2;
            }

            ushort syncH = 0;
            fpcStandardRoleBase?.FpcModule.MouseLook.GetSyncValues(0, out syncH, out var _);
            writer.WriteRelativePosition(new(hub));
            writer.WriteUShort(syncH);
        }
    }
}
