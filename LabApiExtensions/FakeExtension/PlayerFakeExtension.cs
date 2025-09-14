using InventorySystem.Items;
using PlayerRoles.FirstPersonControl;
using UnityEngine;

namespace LabApiExtensions.FakeExtension;

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
            player.SetFakeGravity(target, gravity);
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
            player.SetFakeScale(target, scale);
        }
    }

    public static void SetFakeBadgeText(this Player player, Player target, string badgeText)
    {
        target.SendFakeSyncVar(player.ReferenceHub.serverRoles, 1, badgeText);
    }

    public static void SetFakeBadgeColor(this Player player, Player target, string color)
    {
        target.SendFakeSyncVar(player.ReferenceHub.serverRoles, 2, color);
    }

    public static void SetFakeViewRange(this Player player, Player target, float viewRange)
    {
        target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 1, viewRange);
    }

    public static void SetFakeCustomInfo(this Player player, Player target, string customInfo)
    {
        target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 2, customInfo);
    }

    public static void SetFakeInfoArea(this Player player, Player target, PlayerInfoArea playerInfoArea)
    {
        target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 4, playerInfoArea);
    }

    public static void SetFakeNick(this Player player, Player target, string nick)
    {
        target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 8, nick);
    }

    public static void SetFakeDisplayName(this Player player, Player target, string displayName)
    {
        target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 16, displayName);
    }

    public static void SetFakeMaxPlayers(this Player player, Player target, ushort maxPlayer)
    {
        target.SendFakeSyncVar(player.ReferenceHub.characterClassManager, 2, maxPlayer);
    }

    public static void SetFakeCurrentItem(this Player player, Player target, ItemIdentifier item)
    {
        target.SendFakeSyncVar(player.ReferenceHub.inventory, 1, item);
    }
}