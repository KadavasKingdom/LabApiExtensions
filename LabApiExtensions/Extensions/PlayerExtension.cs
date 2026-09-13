using PlayerStatsSystem;

namespace LabApiExtensions.Extensions;

/// <summary>
/// Extension for <see cref="Player"/>.
/// </summary>
public static class PlayerExtension
{
	/// <summary>
	/// Throw <paramref name="item"/> from the <paramref name="player"/>.
	/// </summary>
	/// <param name="player">The player.</param>
	/// <param name="item">The item to throw.</param>
	public static void ThrewItem(this Player player, Item item)
	{
		if (player == null)
		{
			throw new ArgumentNullException(nameof(player));
		}

		if (item == null)
		{
			throw new ArgumentNullException(nameof(item));
		}

		player.Inventory.UserCode_CmdDropItem__UInt16__Boolean(item.Serial, true);
	}

	/// <summary>
	/// Add AHP to <paramref name="player"/>.
	/// </summary>
	/// <param name="player">The player.</param>
	/// <param name="amount">The amount to set.</param>
	/// <param name="decay">Decay rate of the AHP (per second).</param>
	/// <param name="efficacy">Defines what % of damage will be absorbed.</param>
	/// <param name="sustain">Disables <paramref name="sustain"/> for set amount of time.</param>
	/// <param name="persistant">If <see langword="true"/>, process won't be killed when amount reaches 0.</param>
	public static void AddAhp(this Player player, float amount, float decay = 1.2f, float efficacy = 0.7f, float sustain = 0f, bool persistant = false)
	{
		if (player == null)
		{
			throw new ArgumentNullException(nameof(player));
		}

		if (amount < 0f)
		{
			return;
		}

		player.ReferenceHub.playerStats.GetModule<AhpStat>().ServerAddProcess(amount, player.MaxArtificialHealth, decay, efficacy, sustain, persistant);
	}
}
