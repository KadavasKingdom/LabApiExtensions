using PlayerStatsSystem;

namespace LabApiExtensions.Extensions;

public static class PlayerExtension
{
    /// <summary>
    /// Throw <paramref name="item"/> from the <paramref name="player"/>.
    /// </summary>
    /// <param name="player">The player.</param>
    /// <param name="item">The item to throw.</param>
    public static void ThrewItem(this Player player, Item item)
    {
        player.Inventory.UserCode_CmdDropItem__UInt16__Boolean(item.Serial, true);
    }

    /// <summary>
    /// Add AHP to <paramref name="player"/>.
    /// </summary>
    /// <param name="player">The player.</param>
    /// <param name="amount"></param>
    /// <param name="decay"></param>
    /// <param name="efficacy"></param>
    /// <param name="sustain"></param>
    /// <param name="persistant"></param>
    public static void AddAhp(this Player player, float amount, float decay = 1.2f, float efficacy = 0.7f, float sustain = 0f, bool persistant = false)
    {
        if (amount < 0f)
            return;
        player.ReferenceHub.playerStats.GetModule<AhpStat>().ServerAddProcess(amount, player.MaxArtificialHealth, decay, efficacy, sustain, persistant);
    }
}
