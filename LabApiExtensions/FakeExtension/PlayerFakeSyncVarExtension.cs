using InventorySystem.Items;

namespace LabApiExtensions.FakeExtension;

/// <summary>
/// Collection of sending fake sync vars.
/// </summary>
public static class PlayerFakeSyncVarExtension
{
    /// <summary>
    /// Sets a fake <paramref name="badgeText"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos badge text changes.</param>
    /// <param name="badgeText">The new badge text value.</param>
    public static void SetFakeBadgeText(this Player player, Player target, string badgeText)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        player.SendFakeSyncVar(target.ReferenceHub.serverRoles, 1, badgeText);
    }

    /// <summary>
    /// Resyncs <paramref name="player"/> badge text from the server.
    /// </summary>
    /// <param name="player">The player to resync.</param>
    public static void ResyncFakeBadgeText(this Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        player.ReferenceHub.serverRoles.SetSyncVarDirtyBit(1);
    }

    /// <summary>
    /// Sets a fake <paramref name="color"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos badge color changes.</param>
    /// <param name="color">The new badge color value.</param>
    public static void SetFakeBadgeColor(this Player player, Player target, string color)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        player.SendFakeSyncVar(target.ReferenceHub.serverRoles, 2, color);
    }

    /// <summary>
    /// Resyncs <paramref name="player"/> badge color from the server.
    /// </summary>
    /// <param name="player">The player to resync.</param>
    public static void ResyncFakeBadgeColor(this Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        player.ReferenceHub.serverRoles.SetSyncVarDirtyBit(2);
    }

    /// <summary>
    /// Sets a fake <paramref name="viewRange"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos view range changes.</param>
    /// <param name="viewRange">The new view range value.</param>
    public static void SetFakeViewRange(this Player player, Player target, float viewRange)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        player.SendFakeSyncVar(target.ReferenceHub.nicknameSync, 1, viewRange);
    }

    /// <summary>
    /// Resyncs <paramref name="player"/> view range from the server.
    /// </summary>
    /// <param name="player">The player to resync.</param>
    public static void ResyncFakeViewRange(this Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        player.ReferenceHub.nicknameSync.SetSyncVarDirtyBit(1);
    }

    /// <summary>
    /// Sets a fake <paramref name="customInfo"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos custom info changes.</param>
    /// <param name="customInfo">The new custom info value.</param>
    public static void SetFakeCustomInfo(this Player player, Player target, string customInfo)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        player.SendFakeSyncVar(target.ReferenceHub.nicknameSync, 2, customInfo);
    }

    /// <summary>
    /// Resyncs <paramref name="player"/> custom info from the server.
    /// </summary>
    /// <param name="player">The player to resync.</param>
    public static void ResyncFakeCustomInfo(this Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        player.ReferenceHub.nicknameSync.SetSyncVarDirtyBit(2);
    }

    /// <summary>
    /// Sets a fake <paramref name="playerInfoArea"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos info area changes.</param>
    /// <param name="playerInfoArea">The new info area value.</param>
    public static void SetFakeInfoArea(this Player player, Player target, PlayerInfoArea playerInfoArea)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        player.SendFakeSyncVar(target.ReferenceHub.nicknameSync, 4, playerInfoArea);
    }

    /// <summary>
    /// Resyncs <paramref name="player"/> info area from the server.
    /// </summary>
    /// <param name="player">The player to resync.</param>
    public static void ResyncFakeInfoArea(this Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        player.ReferenceHub.nicknameSync.SetSyncVarDirtyBit(4);
    }

    /// <summary>
    /// Sets a fake <paramref name="nick"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos nickname changes.</param>
    /// <param name="nick">The new nickname value.</param>
    public static void SetFakeNick(this Player player, Player target, string nick)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        player.SendFakeSyncVar(target.ReferenceHub.nicknameSync, 8, nick);
    }

    /// <summary>
    /// Resyncs <paramref name="player"/> nickname from the server.
    /// </summary>
    /// <param name="player">The player to resync.</param>
    public static void ResyncFakeNick(this Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        player.ReferenceHub.nicknameSync.SetSyncVarDirtyBit(8);
    }

    /// <summary>
    /// Sets a fake <paramref name="displayName"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos display name changes.</param>
    /// <param name="displayName">The new display name value.</param>
    public static void SetFakeDisplayName(this Player player, Player target, string displayName)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        player.SendFakeSyncVar(target.ReferenceHub.nicknameSync, 16, displayName);
    }

    /// <summary>
    /// Resyncs <paramref name="player"/> display name from the server.
    /// </summary>
    /// <param name="player">The player to resync.</param>
    public static void ResyncFakeDisplayName(this Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        player.ReferenceHub.nicknameSync.SetSyncVarDirtyBit(16);
    }

    /// <summary>
    /// Sets a fake <paramref name="maxPlayer"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos max player changes.</param>
    /// <param name="maxPlayer">The new max player value.</param>
    public static void SetFakeMaxPlayers(this Player player, Player target, ushort maxPlayer)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        player.SendFakeSyncVar(target.ReferenceHub.characterClassManager, 2, maxPlayer);
    }

    /// <summary>
    /// Resyncs <paramref name="player"/> max player from the server.
    /// </summary>
    /// <param name="player">The player to resync.</param>
    public static void ResyncFakeMaxPlayers(this Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        player.ReferenceHub.characterClassManager.SetSyncVarDirtyBit(2);
    }

    /// <summary>
    /// Sets a fake <paramref name="item"/> of <paramref name="target"/>.
    /// </summary>
    /// <param name="player">The player whos receives it.</param>
    /// <param name="target">The players whos current item changes.</param>
    /// <param name="item">The new current item value.</param>
    public static void SetFakeCurrentItem(this Player player, Player target, ItemIdentifier item)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        player.SendFakeSyncVar(target.ReferenceHub.inventory, 1, item);
    }

    /// <summary>
    /// Resyncs <paramref name="player"/> current item from the server.
    /// </summary>
    /// <param name="player">The player to resync.</param>
    public static void ResyncFakeCurrentItem(this Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        player.ReferenceHub.characterClassManager.SetSyncVarDirtyBit(1);
    }
}