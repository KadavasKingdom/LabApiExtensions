using PlayerRoles.FirstPersonControl;
using UnityEngine;

namespace LabApiExtensions.FakeExtension;

/// <summary>
/// Collection of sending fake messages.
/// </summary>
public static class PlayerFakeMessageExtension
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
}