using Mirror;
using UnityEngine;
using PlayerRoles.FirstPersonControl;
using LabApiExtensions.FakeExtension;

namespace LabApiExtensions.Extensions;

/// <summary>
/// 
/// </summary>
public static class ScaleExtension
{
    /// <summary>
    /// Setting the scale of <paramref name="player"/> with value of <paramref name="value"/>.
    /// </summary>
    /// <param name="player">The player.</param>
    /// <param name="value">The scale value.</param>
    /// <param name="IsFake">Is the scale is to be faked.</param>
    /// <remarks>
    /// The <paramref name="player"/> will be teleported in place to not fall under the map.
    /// </remarks>
    public static void SetScale(this Player player, Vector3 value, bool IsFake = false)
    {
        Vector3 original = player.Scale;
        if (value == original && !IsFake)
            return;

        if (IsFake)
        {
            PlayerFakeExtension.SetFakeScale(player, Player.ReadyList.Where(x => x != player), value);
            return;
        }

        player.Scale = value;
        if (value == Vector3.one)
            return;
        if (player.ReferenceHub.roleManager.CurrentRole is not IFpcRole fpcRole)
            return;
        float halfHeight = fpcRole.FpcModule.CharController.height / 2;
        float tpY = value.y < -0.1f ? value.y * -1f : value.y - halfHeight;
        player.Position += new Vector3(0f, tpY, 0f);
    }

    /// <summary>
    /// Set the scale of the <paramref name="behaviour"/>.
    /// </summary>
    /// <param name="behaviour">The network object.</param>
    /// <param name="value">The new scale.</param>
    public static void SetScale(this NetworkBehaviour behaviour, Vector3 value)
    {
        Vector3 original = behaviour.transform.localScale;
        if (value == original)
            return;

        try
        {
            behaviour.transform.localScale = value;

            foreach (Player target in Player.ReadyList)
                NetworkServer.SendSpawnMessage(behaviour.netIdentity, target.Connection);
        }
        catch (Exception exception)
        {
            CL.Error($"{nameof(SetScale)} error: {exception}");
        }
    }
}