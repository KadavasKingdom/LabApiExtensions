using Hazards;
using Interactables.Interobjects;
using Interactables.Interobjects.DoorUtils;
using PlayerRoles.PlayableScps.Scp939;
using Scp914;
using UnityEngine;

namespace LabApiExtensions.FakeExtension;

/// <summary>
/// Collection of sending fake Rpc.
/// </summary>
public static class PlayerFakeRpcExtension
{
    /// <inheritdoc cref="RoundSummary.RpcDimScreen" />
    public static void SetFakeSummaryDimScreen(this Player player)
    {
        if (!RoundSummary._singletonSet || RoundSummary.singleton == null)
        {
            return;
        }

        player.SendFakeRPC(RoundSummary.singleton, nameof(RoundSummary.singleton.RpcDimScreen));
    }

    /// <inheritdoc cref="RoundSummary.RpcUndimScreen" />
    public static void SetFakeSummaryUnDimScreen(this Player player)
    {
        if (!RoundSummary._singletonSet || RoundSummary.singleton == null)
        {
            return;
        }

        player.SendFakeRPC(RoundSummary.singleton, nameof(RoundSummary.singleton.RpcUndimScreen));
    }

    /// <inheritdoc cref="RoundSummary.RpcHideRoundSummary" />
    public static void SetFakeHideRoundSummary(this Player player)
    {
        if (!RoundSummary._singletonSet || RoundSummary.singleton == null)
        {
            return;
        }

        player.SendFakeRPC(RoundSummary.singleton, nameof(RoundSummary.singleton.RpcHideRoundSummary));
    }

    /// <inheritdoc cref="RoundSummary.RpcShowRoundSummary" />
    public static void SetFakeShowRoundSummary(this Player player, RoundSummary.SumInfo_ClassList listStart, RoundSummary.SumInfo_ClassList listFinish, RoundSummary.LeadingTeam leadingTeam, int eDS, int eSc, int scpKills, int roundCd, int seconds)
    {
        if (!RoundSummary._singletonSet || RoundSummary.singleton == null)
        {
            return;
        }

        player.SendFakeRPC(RoundSummary.singleton, nameof(RoundSummary.singleton.RpcShowRoundSummary), [listStart, listFinish, leadingTeam, eDS, eSc, scpKills, roundCd, seconds]);
    }

    /// <inheritdoc cref="Scp914Controller.RpcPlaySound" />
    public static void SetFakeScp914Sound(this Player player, Scp914Sound scp914Sound)
    {
        if (Scp914Controller.Singleton == null)
        {
            return;
        }

        player.SendFakeRPC(Scp914Controller.Singleton, nameof(Scp914Controller.Singleton.RpcPlaySound), [(byte)scp914Sound]);
    }

    /// <inheritdoc cref="AlphaWarheadActivationPanel.RpcGranted" />
    public static void SetFakeWarheadActivationPanelGranted(this Player player)
    {
        if (AlphaWarheadActivationPanel.Instance == null)
        {
            return;
        }

        player.SendFakeRPC(AlphaWarheadActivationPanel.Instance, nameof(AlphaWarheadActivationPanel.Instance.RpcGranted));
    }

    /// <inheritdoc cref="AlphaWarheadActivationPanel.RpcReset" />
    public static void SetFakeWarheadActivationPanelReset(this Player player)
    {
        if (AlphaWarheadActivationPanel.Instance == null)
        {
            return;
        }

        player.SendFakeRPC(AlphaWarheadActivationPanel.Instance, nameof(AlphaWarheadActivationPanel.Instance.RpcReset));
    }

    /// <inheritdoc cref="AlphaWarheadActivationPanel.RpcDenied(DoorPermissionFlags)" />
    public static void SetFakeWarheadActivationPanelDenied(this Player player, Interactables.Interobjects.DoorUtils.DoorPermissionFlags permissionFlags)
    {
        if (AlphaWarheadActivationPanel.Instance == null)
        {
            return;
        }

        player.SendFakeRPC(AlphaWarheadActivationPanel.Instance, nameof(AlphaWarheadActivationPanel.Instance.RpcDenied), [permissionFlags]);
    }

    /// <inheritdoc cref="AlphaWarheadController.RpcShake(bool)" />
    public static void SetFakeWarheadShake(this Player player, bool earnAchievement = false)
    {
        if (AlphaWarheadController.Singleton == null)
        {
            return;
        }

        player.SendFakeRPC(AlphaWarheadController.Singleton, nameof(AlphaWarheadController.Singleton.RpcShake), [earnAchievement]);
    }

    /// <inheritdoc cref="AlphaWarheadNukesitePanel.RpcLeverSound" />
    public static void SetFakeWarheadPanelLeverSound(this Player player)
    {
        if (AlphaWarheadNukesitePanel.Singleton == null)
        {
            return;
        }

        player.SendFakeRPC(AlphaWarheadNukesitePanel.Singleton, nameof(AlphaWarheadNukesitePanel.Singleton.RpcLeverSound));
    }

    /// <inheritdoc cref="PrismaticCloud.RpcDespawn" />
    public static void SetFakeDespawn(this Player player, PrismaticCloud prismaticCloud)
    {
        if (prismaticCloud == null)
        {
            return;
        }

        player.SendFakeRPC(prismaticCloud, nameof(PrismaticCloud.RpcDespawn));
    }

    /// <inheritdoc cref="TantrumEnvironmentalHazard.RpcDespawn(bool)" />
    public static void SetFakeDespawn(this Player player, TantrumEnvironmentalHazard hazard, bool playSizzle)
    {
        if (hazard == null)
        {
            return;
        }

        player.SendFakeRPC(hazard, nameof(TantrumEnvironmentalHazard.RpcDespawn), [playSizzle]);
    }

    /// <inheritdoc cref="MapGeneration.Distributors.Locker.RpcPlayDenied(byte, DoorPermissionFlags)" />
    public static void SetFakeLockerDenied(this Player player, MapGeneration.Distributors.Locker locker, byte chamberId, DoorPermissionFlags perms)
    {
        if (locker == null)
        {
            return;
        }

        player.SendFakeRPC(locker, nameof(MapGeneration.Distributors.Locker.RpcPlayDenied), [chamberId, perms]);
    }

    /// <inheritdoc cref="MapGeneration.Distributors.Scp079Generator.RpcDenied(DoorPermissionFlags)" />
    public static void SetFakeLockerDenied(this Player player, MapGeneration.Distributors.Scp079Generator generator, DoorPermissionFlags perms)
    {
        if (generator == null)
        {
            return;
        }

        player.SendFakeRPC(generator, nameof(MapGeneration.Distributors.Scp079Generator.RpcDenied), [perms]);
    }

    /// <inheritdoc cref="AirlockController.RpcAlarm" />
    public static void SetFakeAirlockAlarm(this Player player, AirlockController airlockController)
    {
        if (airlockController == null)
        {
            return;
        }

        player.SendFakeRPC(airlockController, nameof(AirlockController.RpcAlarm));
    }

    /// <inheritdoc cref="BasicDoor.RpcPlayBeepSound" />
    public static void SetFakeDoorDenied(this Player player, BasicDoor door)
    {
        if (door == null)
        {
            return;
        }

        player.SendFakeRPC(door, nameof(BasicDoor.RpcPlayBeepSound));
    }

    /// <inheritdoc cref="BasicDoor.PlayDeniedButtonAnims(DoorPermissionFlags)" />
    public static void SetFakeDoorDeniedButtonAnimation(this Player player, BasicDoor door, DoorPermissionFlags permissionFlags)
    {
        if (door == null)
        {
            return;
        }

        player.SendFakeRPC(door, nameof(BasicDoor.PlayDeniedButtonAnims), [permissionFlags]);
    }

    /// <inheritdoc cref="Interactables.Interobjects.CheckpointDoor.RpcPlayWarningSound" />
    public static void SetFakeDoorWarningSound(this Player player, Interactables.Interobjects.CheckpointDoor door)
    {
        if (door == null)
        {
            return;
        }

        player.SendFakeRPC(door, nameof(Interactables.Interobjects.CheckpointDoor.RpcPlayWarningSound));
    }

    /// <inheritdoc cref="Interactables.Interobjects.CheckpointDoor.RpcPlayDeniedBeep" />
    public static void SetFakeDoorDenied(this Player player, Interactables.Interobjects.CheckpointDoor door)
    {
        if (door == null)
        {
            return;
        }

        player.SendFakeRPC(door, nameof(Interactables.Interobjects.CheckpointDoor.RpcPlayDeniedBeep));
    }

    /// <inheritdoc cref="Interactables.Interobjects.CheckpointDoor.PlayDeniedButtonAnims(DoorPermissionFlags)" />
    public static void SetFakeDoorDeniedButtonAnimation(this Player player, Interactables.Interobjects.CheckpointDoor door, DoorPermissionFlags permissionFlags)
    {
        if (door == null)
        {
            return;
        }

        player.SendFakeRPC(door, nameof(Interactables.Interobjects.CheckpointDoor.PlayDeniedButtonAnims), [permissionFlags]);
    }

    /// <inheritdoc cref="ElevatorSquish.PlaySquishSound(Vector3)" />
    public static void SetFakeSquishSound(this Player player, ElevatorSquish elevatorSquish, Vector3 position)
    {
        if (elevatorSquish == null)
        {
            return;
        }

        player.SendFakeRPC(elevatorSquish, nameof(ElevatorSquish.PlaySquishSound), [position]);
    }

    /// <inheritdoc cref="Scp330Interobject.RpcMakeSound" />
    public static void SetFakeTakeSound(this Player player, Scp330Interobject scp330Interobject)
    {
        if (scp330Interobject == null)
        {
            return;
        }

        player.SendFakeRPC(scp330Interobject, nameof(Scp330Interobject.RpcMakeSound));
    }

    /// <inheritdoc cref="Scp939AmnesticCloudInstance.RpcPlayCreateSound" />
    public static void SetFakeCreateSound(this Player player, Scp939AmnesticCloudInstance scp939AmnesticCloud)
    {
        if (scp939AmnesticCloud == null)
        {
            return;
        }

        player.SendFakeRPC(scp939AmnesticCloud, nameof(Scp939AmnesticCloudInstance.RpcPlayCreateSound));
    }

    /// <inheritdoc cref="Broadcast.RpcAddElement(string, ushort, Broadcast.BroadcastFlags)" />
    public static void SetFakeShowBroadcast(this Player player, string data, ushort time, Broadcast.BroadcastFlags flags)
    {
        if (Broadcast.Singleton == null)
        {
            return;
        }

        player.SendFakeRPC(Broadcast.Singleton, nameof(Broadcast.RpcAddElement), [data, time, flags]);
    }

    /// <inheritdoc cref="Broadcast.RpcClearElements" />
    public static void SetFakeClearBroadcast(this Player player)
    {
        if (Broadcast.Singleton == null)
        {
            return;
        }

        player.SendFakeRPC(Broadcast.Singleton, nameof(Broadcast.RpcClearElements));
    }

    /// <inheritdoc cref="PryableDoor.RpcPryGate" />
    public static void SetFakePryGate(this Player player, PryableDoor pryableDoor)
    {
        if (pryableDoor == null)
        {
            return;
        }

        player.SendFakeRPC(pryableDoor, nameof(PryableDoor.RpcPryGate));
    }
}