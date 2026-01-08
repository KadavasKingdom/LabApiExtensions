using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using LabApi.Features.Extensions;
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
    struct FakeRole
    {
        public RoleTypeId Role;
        public Dictionary<ReferenceHub, RoleTypeId> RoleToViewer;
    }

    static readonly Dictionary<ReferenceHub, FakeRole> FakeRoles = [];

    static FakeRoleManager()
    {
        PlayerEvents.ChangingRole += PlayerEvents_ChangingRole;
        FpcServerPositionDistributor.RoleSyncEvent += FpcServerPositionDistributor_RoleSyncEvent;
    }

    private static void PlayerEvents_ChangingRole(PlayerChangingRoleEventArgs ev)
    {
        if (ev.Player is null)
            return;

        if (ev.IsAllowed)
            RemoveFakeRole(ev.Player);
    }

    public static void AddFakeRole(this Player player, RoleTypeId roleType)
    {
        if (roleType is RoleTypeId.None or RoleTypeId.Destroyed)
            return;

        AddFakeRole(player, roleType, null);
    }

    public static void AddFakeRole(this Player player, RoleTypeId roleType, Player viewer)
    {
        if (roleType is RoleTypeId.None or RoleTypeId.Destroyed)
            return;

        if (player.Connection != null || !player.IsReady)
        {
            if (!FakeRoles.TryGetValue(player.ReferenceHub, out FakeRole value))
            {
                value = FakeRoles[player.ReferenceHub] = new()
                { 
                    Role = RoleTypeId.None,
                    RoleToViewer = []
                };
            }

            if (viewer != null)
                value.RoleToViewer[viewer.ReferenceHub] = roleType;
            else
                value.Role = roleType;
        }
    }

    public static void RemoveViewer(this Player player, Player viewer)
    {
        if (FakeRoles.TryGetValue(player.ReferenceHub, out FakeRole value))
        {
            value.RoleToViewer.Remove(viewer.ReferenceHub);
        }
    }

    public static void RemoveFakeRole(this Player player)
    {
        FakeRoles.Remove(player.ReferenceHub);
    }

    private static RoleTypeId FpcServerPositionDistributor_RoleSyncEvent(ReferenceHub hub, ReferenceHub receiver, RoleTypeId roleType, NetworkWriter writer)
    {
        RoleTypeId returnRole = roleType;
        if (FakeRoles.TryGetValue(hub, out FakeRole fakeRole))
        {
            if (fakeRole.RoleToViewer.TryGetValue(receiver, out RoleTypeId roleToViewer))
                returnRole = roleToViewer;

            if (returnRole == RoleTypeId.None)
                returnRole = fakeRole.Role;

            if (returnRole != roleType)
                WriteExtraForRole(hub, returnRole, writer);
        }

        return returnRole;
    }

    private static void WriteExtraForRole(ReferenceHub hub, RoleTypeId roleType, NetworkWriter writer)
    {
        PlayerRoleBase roleBase = roleType.GetRoleBase();

        if (roleBase is HumanRole { UsesUnitNames: true })
        {
            // UnitNameId
            writer.WriteByte(0);
        }

        if (roleBase is ZombieRole)
        {
            // _syncMaxHealth
            writer.WriteUShort((ushort)Mathf.Clamp(Mathf.CeilToInt(hub.playerStats.GetModule<HealthStat>().MaxValue), 0, 65535));
            // _showConfirmationBox
            writer.WriteBool(true);
        }

        if (roleBase is Scp1507Role)
        {
            // ServerSpawnReason
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
            // RelativePosition
            writer.WriteRelativePosition(new(hub));
            // syncH
            writer.WriteUShort(syncH);
        }
    }
}
