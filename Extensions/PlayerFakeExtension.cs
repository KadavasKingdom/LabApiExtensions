using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using PlayerRoles.FirstPersonControl.NetworkMessages;
using UnityEngine;

namespace LabApiExtensions.Extensions;

public static class PlayerFakeExtension
{
    public static void SetFakeGravity(this Player player, Player target, Vector3 gravity)
    {
        player.Connection.Send<SyncedGravityMessages.GravityMessage>(new(gravity, target.ReferenceHub));
    }

    public static void SetFakeGravity(this Player player, List<Player> targets, Vector3 gravity)
    {
        foreach (Player target in targets)
        {
            SetFakeGravity(player, target, gravity);
        }
    }

    public static void SetFakeScale(this Player player, Player target, Vector3 scale)
    {
        player.Connection.Send<SyncedScaleMessages.ScaleMessage>(new(scale, target.ReferenceHub));
    }

    public static void SetFakeScale(this Player player, List<Player> targets, Vector3 scale)
    {
        foreach (Player target in targets)
        {
            SetFakeScale(player, target, scale);
        }
    }

    // This will highly not work since for some roles it will crash or just not work.
    // NW likely fix it in new update. (Hopium, 14.1.4)
    private static void SetFakeRole(this Player player, Player target, RoleTypeId targetRole)
    {
        FpcServerPositionDistributor.SendRole(target.ReferenceHub, player.ReferenceHub, targetRole);
    }
}