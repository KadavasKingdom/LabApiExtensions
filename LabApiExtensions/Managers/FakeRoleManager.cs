using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using Mirror;
using PlayerRoles;
using PlayerRoles.FirstPersonControl.NetworkMessages;

namespace LabApiExtensions.Managers;

public static class FakeRoleManager
{
    static readonly Dictionary<ReferenceHub, RoleTypeId> FakeRoles = [];

    static FakeRoleManager()
    {
        PlayerEvents.ChangingRole += PlayerEvents_ChangingRole;
        FpcServerPositionDistributor.RoleSyncEvent += FpcServerPositionDistributor_RoleSyncEvent;
    }

    private static void PlayerEvents_ChangingRole(PlayerChangingRoleEventArgs ev)
    {
        if (ev.IsAllowed)
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

    private static RoleTypeId FpcServerPositionDistributor_RoleSyncEvent(ReferenceHub hub, ReferenceHub receiver, RoleTypeId roleType, NetworkWriter writer)
    {
        if (FakeRoles.TryGetValue(hub, out var value))
            return value;
        return roleType;
    }
}
