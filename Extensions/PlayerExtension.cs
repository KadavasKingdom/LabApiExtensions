using PlayerStatsSystem;

namespace LabApiExtensions.Extensions;

public static class PlayerExtension
{
    public static void ThrewItem(this Player player, Item item)
    {
        player.Inventory.UserCode_CmdDropItem__UInt16__Boolean(item.Serial, true);
    }

    public static void AddAhp(this Player player, float amount, float decay = 1.2f, float efficacy = 0.7f, float sustain = 0f, bool persistant = false)
    {
        AhpStat module = player.ReferenceHub.playerStats.GetModule<AhpStat>();
        module.ServerKillAllProcesses();
        if (amount > 0f)
        {
            module.ServerAddProcess(amount, player.MaxArtificialHealth, decay, efficacy, sustain, persistant);
        }
    }
}
