﻿using Mirror;
using UnityEngine;

namespace LabApiExtensions.Extensions;

/// <summary>
/// All code from here is ported from Exiled & Edited to current version.
/// License: Creative Commons Attribution-ShareAlike 3.0 Unported
/// </summary>
public static class ScaleHelper
{
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