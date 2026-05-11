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
    #region RoundSummary
    public static void SetFakeSummaryDimScreen(this Player player)
    {
        if (!RoundSummary._singletonSet || RoundSummary.singleton == null)
            return;

        player.SendFakeRPC(RoundSummary.singleton, nameof(RoundSummary.singleton.RpcDimScreen));
    }

    public static void SetFakeSummaryUnDimScreen(this Player player)
    {
        if (!RoundSummary._singletonSet || RoundSummary.singleton == null)
            return;

        player.SendFakeRPC(RoundSummary.singleton, nameof(RoundSummary.singleton.RpcUndimScreen));
    }

    public static void SetFakeHideRoundSummary(this Player player)
    {
        if (!RoundSummary._singletonSet || RoundSummary.singleton == null)
            return;

        player.SendFakeRPC(RoundSummary.singleton, nameof(RoundSummary.singleton.RpcHideRoundSummary));
    }

    public static void SetFakeShowRoundSummary(this Player player, RoundSummary.SumInfo_ClassList listStart, RoundSummary.SumInfo_ClassList listFinish, RoundSummary.LeadingTeam leadingTeam, int eDS, int eSc, int scpKills, int roundCd, int seconds)
    {
        if (!RoundSummary._singletonSet || RoundSummary.singleton == null)
            return;

        player.SendFakeRPC(RoundSummary.singleton, nameof(RoundSummary.singleton.RpcHideRoundSummary), [listStart, listFinish, leadingTeam, eDS, eSc, scpKills, roundCd, seconds]);
    }
    #endregion
    #region Scp914
    public static void SetFakeScp914Sound(this Player player, Scp914Sound scp914Sound)
    {
        if (Scp914Controller.Singleton == null)
            return;

        player.SendFakeRPC(Scp914Controller.Singleton, nameof(Scp914Controller.Singleton.RpcPlaySound), [(byte)scp914Sound]);
    }
    #endregion
    #region Warhead
    public static void SetFakeWarheadActivationPanelGranted(this Player player)
    {
        if (AlphaWarheadActivationPanel.Instance == null)
            return;

        player.SendFakeRPC(AlphaWarheadActivationPanel.Instance, nameof(AlphaWarheadActivationPanel.Instance.RpcGranted));
    }

    public static void SetFakeWarheadActivationPanelReset(this Player player)
    {
        if (AlphaWarheadActivationPanel.Instance == null)
            return;

        player.SendFakeRPC(AlphaWarheadActivationPanel.Instance, nameof(AlphaWarheadActivationPanel.Instance.RpcReset));
    }

    public static void SetFakeWarheadActivationPanelDenied(this Player player, Interactables.Interobjects.DoorUtils.DoorPermissionFlags permissionFlags)
    {
        if (AlphaWarheadActivationPanel.Instance == null)
            return;

        player.SendFakeRPC(AlphaWarheadActivationPanel.Instance, nameof(AlphaWarheadActivationPanel.Instance.RpcDenied), [permissionFlags]);
    }

    public static void SetFakeWarheadShake(this Player player, bool earnAchievement = false)
    {
        if (AlphaWarheadController.Singleton == null)
            return;

        player.SendFakeRPC(AlphaWarheadController.Singleton, nameof(AlphaWarheadController.Singleton.RpcShake), [earnAchievement]);
    }

    public static void SetFakeWarheadPanelLeverSound(this Player player)
    {
        if (AlphaWarheadNukesitePanel.Singleton == null)
            return;

        player.SendFakeRPC(AlphaWarheadNukesitePanel.Singleton, nameof(AlphaWarheadNukesitePanel.Singleton.RpcLeverSound));
    }

    #endregion
    #region Hazard
    public static void SetFakeDespawn(this Player player, PrismaticCloud prismaticCloud)
    {
        if (prismaticCloud == null)
            return;

        player.SendFakeRPC(prismaticCloud, nameof(PrismaticCloud.RpcDespawn));
    }

    public static void SetFakeDespawn(this Player player, TantrumEnvironmentalHazard hazard, bool playSizzle)
    {
        if (hazard == null)
            return;

        player.SendFakeRPC(hazard, nameof(TantrumEnvironmentalHazard.RpcDespawn), [playSizzle]);
    }
    #endregion
    #region Fake Denied or Alarm sounds
    public static void SetFakeLockerDenied(this Player player, MapGeneration.Distributors.Locker locker, byte chamberId, DoorPermissionFlags perms)
    {
        if (locker == null)
            return;

        player.SendFakeRPC(locker, nameof(MapGeneration.Distributors.Locker.RpcPlayDenied), [chamberId, perms]);
    }

    public static void SetFakeLockerDenied(this Player player, MapGeneration.Distributors.Scp079Generator generator, DoorPermissionFlags perms)
    {
        if (generator == null)
            return;

        player.SendFakeRPC(generator, nameof(MapGeneration.Distributors.Scp079Generator.RpcDenied), [perms]);
    }

    public static void SetFakeAirlockAlarm(this Player player, AirlockController airlockController)
    {
        if (airlockController == null)
            return;

        player.SendFakeRPC(airlockController, nameof(AirlockController.RpcAlarm));
    }

    public static void SetFakeDoorDenied(this Player player, BasicDoor door)
    {
        if (door == null)
            return;

        player.SendFakeRPC(door, nameof(BasicDoor.RpcPlayBeepSound));
    }

    public static void SetFakeDoorDeniedButtonAnimation(this Player player, BasicDoor door, DoorPermissionFlags permissionFlags)
    {
        if (door == null)
            return;

        player.SendFakeRPC(door, nameof(BasicDoor.PlayDeniedButtonAnims), [permissionFlags]);
    }

    public static void SetFakeDoorWarningSound(this Player player, Interactables.Interobjects.CheckpointDoor door)
    {
        if (door == null)
            return;

        player.SendFakeRPC(door, nameof(Interactables.Interobjects.CheckpointDoor.RpcPlayWarningSound));
    }

    public static void SetFakeDoorDenied(this Player player, Interactables.Interobjects.CheckpointDoor door)
    {
        if (door == null)
            return;

        player.SendFakeRPC(door, nameof(Interactables.Interobjects.CheckpointDoor.RpcPlayDeniedBeep));
    }

    public static void SetFakeDoorDeniedButtonAnimation(this Player player, Interactables.Interobjects.CheckpointDoor door, DoorPermissionFlags permissionFlags)
    {
        if (door == null)
            return;

        player.SendFakeRPC(door, nameof(Interactables.Interobjects.CheckpointDoor.PlayDeniedButtonAnims), [permissionFlags]);
    }

    public static void SetFakeSquishSound(this Player player, ElevatorSquish elevatorSquish, Vector3 position)
    {
        if (elevatorSquish == null)
            return;

        player.SendFakeRPC(elevatorSquish, nameof(ElevatorSquish.PlaySquishSound), [position]);
    }

    public static void SetFakeTakeSound(this Player player, Scp330Interobject scp330Interobject)
    {
        if (scp330Interobject == null)
            return;

        player.SendFakeRPC(scp330Interobject, nameof(Scp330Interobject.RpcMakeSound));
    }

    public static void SetFakeCreateSound(this Player player, Scp939AmnesticCloudInstance scp939AmnesticCloud)
    {
        if (scp939AmnesticCloud == null)
            return;

        player.SendFakeRPC(scp939AmnesticCloud, nameof(Scp939AmnesticCloudInstance.RpcPlayCreateSound));
    }
    #endregion
    #region Broadcast
    public static void SetFakeShowBroadcast(this Player player, string data, ushort time, Broadcast.BroadcastFlags flags)
    {
        if (Broadcast.Singleton == null)
            return;

        player.SendFakeRPC(Broadcast.Singleton, nameof(Broadcast.RpcAddElement), [data, time, flags]);
    }

    public static void SetFakeClearBroadcast(this Player player)
    {
        if (Broadcast.Singleton == null)
            return;

        player.SendFakeRPC(Broadcast.Singleton, nameof(Broadcast.RpcClearElements));
    }
    #endregion

    public static void SetFakePryGate(this Player player, PryableDoor pryableDoor)
    {
        if (pryableDoor == null)
            return;

        player.SendFakeRPC(pryableDoor, nameof(PryableDoor.RpcPryGate));
    }
}