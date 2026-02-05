using InventorySystem.Items;
using PlayerRoles.FirstPersonControl;
using UnityEngine;

namespace LabApiExtensions.FakeExtension;

/// <summary>
/// Collection of sending fake messages/packets.
/// </summary>
public static class PlayerFakeExtension
{
    /// <summary>
    /// Sends a fake gravity message to <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The player whos gravity changes.</param>
    /// <param name="gravity">The new gravity value.</param>
    public static void SetFakeGravity(this Player player, Player target, Vector3 gravity)
    {
        player.Connection.Send<SyncedGravityMessages.GravityMessage>(new(gravity, target.ReferenceHub));
    }

    /// <summary>
    /// Sends a fake gravity message to <paramref name="targets"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="targets">The players whos gravity changes.</param>
    /// <param name="gravity">The new gravity value.</param>
    public static void SetFakeGravity(this Player player, IEnumerable<Player> targets, Vector3 gravity)
    {
        foreach (Player target in targets)
        {
            player.SetFakeGravity(target, gravity);
        }
    }

    /// <summary>
    /// Sends a fake scale message to <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos gravity changes.</param>
    /// <param name="scale">The new gravity value.</param>
    public static void SetFakeScale(this Player player, Player target, Vector3 scale)
    {
        player.Connection.Send<SyncedScaleMessages.ScaleMessage>(new(scale, target.ReferenceHub));
    }

    /// <summary>
    /// Sends a fake scale message to <paramref name="targets"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="targets">The players whos scale changes.</param>
    /// <param name="scale">The new scale value.</param>
    public static void SetFakeScale(this Player player, IEnumerable<Player> targets, Vector3 scale)
    {
        foreach (Player target in targets)
        {
            player.SetFakeScale(target, scale);
        }
    }

    /// <summary>
    /// Sets a fake <paramref name="badgeText"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos badge text changes.</param>
    /// <param name="badgeText">The new badge text value.</param>
    public static void SetFakeBadgeText(this Player player, Player target, string badgeText)
    {
        target.SendFakeSyncVar(player.ReferenceHub.serverRoles, 1, badgeText);
    }

    /// <summary>
    /// Sets a fake <paramref name="color"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos badge color changes.</param>
    /// <param name="color">The new badge color value.</param>
    public static void SetFakeBadgeColor(this Player player, Player target, string color)
    {
        target.SendFakeSyncVar(player.ReferenceHub.serverRoles, 2, color);
    }

    /// <summary>
    /// Sets a fake <paramref name="viewRange"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos view range changes.</param>
    /// <param name="viewRange">The new view range value.</param>
    public static void SetFakeViewRange(this Player player, Player target, float viewRange)
    {
        target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 1, viewRange);
    }

    /// <summary>
    /// Sets a fake <paramref name="customInfo"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos custom info changes.</param>
    /// <param name="customInfo">The new custom info value.</param>
    public static void SetFakeCustomInfo(this Player player, Player target, string customInfo)
    {
        target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 2, customInfo);
    }

    /// <summary>
    /// Sets a fake <paramref name="playerInfoArea"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos info area changes.</param>
    /// <param name="playerInfoArea">The new info area value.</param>
    public static void SetFakeInfoArea(this Player player, Player target, PlayerInfoArea playerInfoArea)
    {
        target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 4, playerInfoArea);
    }

    /// <summary>
    /// Sets a fake <paramref name="nick"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos nickname changes.</param>
    /// <param name="nick">The new nickname value.</param>
    public static void SetFakeNick(this Player player, Player target, string nick)
    {
        target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 8, nick);
    }

    /// <summary>
    /// Sets a fake <paramref name="displayName"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos display name changes.</param>
    /// <param name="displayName">The new display name value.</param>
    public static void SetFakeDisplayName(this Player player, Player target, string displayName)
    {
        target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 16, displayName);
    }

    /// <summary>
    /// Sets a fake <paramref name="maxPlayer"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos max player changes.</param>
    /// <param name="maxPlayer">The new max player value.</param>
    public static void SetFakeMaxPlayers(this Player player, Player target, ushort maxPlayer)
    {
        target.SendFakeSyncVar(player.ReferenceHub.characterClassManager, 2, maxPlayer);
    }

    /// <summary>
    /// Sets a fake <paramref name="item"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos current item changes.</param>
    /// <param name="item">The new current item value.</param>
    public static void SetFakeCurrentItem(this Player player, Player target, ItemIdentifier item)
    {
        target.SendFakeSyncVar(player.ReferenceHub.inventory, 1, item);
    }
}