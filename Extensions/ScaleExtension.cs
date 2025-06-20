﻿using Mirror;
using UnityEngine;

namespace LabApiExtensions.Extensions;

/// <summary>
/// All code from here is ported from Exiled & Edited to current version.
/// License: Creative Commons Attribution-ShareAlike 3.0 Unported
/// </summary>
public static class ScaleHelper
{
    public static void SetScale(this Player player, Vector3 value, bool IsFake = false, bool force = false)
    {
        Vector3 original = player.Scale;
        if (value == original && !force)
            return;

        try
        {
            player.ReferenceHub.transform.localScale = value;

            foreach (Player target in Player.ReadyList)
                NetworkServer.SendSpawnMessage(player.ReferenceHub.networkIdentity, target.Connection);

            if (IsFake)
                player.ReferenceHub.transform.localScale = original;
        }
        catch (Exception exception)
        {
            CL.Error($"{nameof(SetScale)} error: {exception}");
        }
    }

    public static Vector3 GetScale(this Player player)
    {
        return player.ReferenceHub.transform.localScale;
    }

    public static void SetScale(this NetworkBehaviour behaviour, Vector3 value, bool IsFake = false, bool force = false)
    {
        Vector3 original = behaviour.transform.localScale;
        if (value == original && !force)
            return;

        try
        {
            behaviour.transform.localScale = value;

            foreach (Player target in Player.ReadyList)
                NetworkServer.SendSpawnMessage(behaviour.netIdentity, target.Connection);

            if (IsFake)
                behaviour.transform.localScale = original;
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