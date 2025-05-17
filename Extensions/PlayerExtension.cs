using PlayerStatsSystem;

namespace LabApiExtensions.Extensions;

public static class PlayerExtension
{
    public static void ThrewItem(this Player player, Item item)
    {
        player.Inventory.ClientDropItem(item.Serial, true);
    }

    public static void AddAhp(this Player player, float amount, float decay = 1.2f, float efficacy = 0.7f, float sustain = 0f, bool persistant = false)
    {
        player.ReferenceHub.playerStats.GetModule<AhpStat>().ServerAddProcess(amount, player.MaxArtificialHealth, decay, efficacy, sustain, persistant);
    }
}
