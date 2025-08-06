using InventorySystem.Items;
using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using PlayerRoles.FirstPersonControl.NetworkMessages;
using UnityEngine;

namespace LabApiExtensions.Extensions;

/// <summary>
/// Collection of sending fake messages/packets.
/// </summary>
public static class PlayerFakeExtension
{
    public static void SetFakeGravity(this Player player, Player target, Vector3 gravity)
    {
        player.Connection.Send<SyncedGravityMessages.GravityMessage>(new(gravity, target.ReferenceHub));
    }

    public static void SetFakeGravity(this Player player, IEnumerable<Player> targets, Vector3 gravity)
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

    public static void SetFakeScale(this Player player, IEnumerable<Player> targets, Vector3 scale)
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

    public static void SetFakeBadgeText(this Player player, Player target, string badgeText)
    {
        FakeSyncVarExtension.SendFakeSyncVar(target, player.ReferenceHub.serverRoles, 1, badgeText);
    }

    public static void SetFakeBadgeColor(this Player player, Player target, string color)
    {
        FakeSyncVarExtension.SendFakeSyncVar(target, player.ReferenceHub.serverRoles, 2, color);
    }
    public static void SetFakeNick(this Player player, Player target, string nick)
    {
        FakeSyncVarExtension.SendFakeSyncVar(target, player.ReferenceHub.nicknameSync, 8, nick);
    }

    public static void SetFakeDisplayName(this Player player, Player target, string displayName)
    {
        FakeSyncVarExtension.SendFakeSyncVar(target, player.ReferenceHub.nicknameSync, 16, displayName);
    }

    public static void SetFakeMaxPlayers(this Player player, Player target, ushort maxPlayer)
    {
        FakeSyncVarExtension.SendFakeSyncVar(target, player.ReferenceHub.characterClassManager, 2, maxPlayer);
    }

    public static void SetFakeCurrentItem(this Player player, Player target, ItemIdentifier item)
    {
        FakeSyncVarExtension.SendFakeSyncVar(target, player.ReferenceHub.inventory, 1, item);
    }
}