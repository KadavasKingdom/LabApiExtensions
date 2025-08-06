using Mirror;
using UnityEngine;

namespace LabApiExtensions.Extensions;

public static class ScaleHelper
{
    public static void SetScale(this Player player, Vector3 value, bool IsFake = false)
    {
        Vector3 original = player.Scale;
        if (value == original && !IsFake)
            return;

        if (IsFake)
        {
            PlayerFakeExtension.SetFakeScale(player, Player.ReadyList, value);
            return;
        }

        player.Scale = value;
        if (value == Vector3.one)
            return;
        if (player.ReferenceHub.roleManager.CurrentRole is not IFpcRole fpcRole)
            return;
        float halfHeight = fpcRole.FpcModule.CharController.height / 2;
        float tpY = value.y - halfHeight;
        player.Position += new Vector3(0f, tpY, 0f);
    }

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

    public static Vector3 GetScale(this NetworkBehaviour behaviour)
    {
        return behaviour.transform.localScale;
    }
}