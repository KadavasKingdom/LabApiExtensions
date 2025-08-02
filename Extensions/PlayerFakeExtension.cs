using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using PlayerRoles.FirstPersonControl.NetworkMessages;
using UnityEngine;

namespace LabApiExtensions.Extensions;

// These stuff are highly experimental!
public static class PlayerFakeExtension
{
    public static void SetFakeGravity(this Player player, Player target, Vector3 gravity)
    {
        player.Connection.Send<SyncedGravityMessages.GravityMessage>(new(gravity, target.ReferenceHub));
    }

    public static void SetFakeScale(this Player player, Player target, Vector3 scale)
    {
        player.Connection.Send<SyncedScaleMessages.ScaleMessage>(new(scale, target.ReferenceHub));
    }

    public static void SetFakeRole(this Player player, Player target, RoleTypeId targetRole)
    {
        FpcServerPositionDistributor.SendRole(target.ReferenceHub, player.ReferenceHub, targetRole);
    }
}
