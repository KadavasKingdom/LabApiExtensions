using Interactables.Interobjects;
using MEC;
using PlayerRoles;

namespace LabApiExtensions.Extensions;

public static class AppearanceSyncExtension
{
    public static float WaitTime = 5f;
    public static bool DebugAppearanceSyncEnabled = false;
    static bool IsChaning = false;
    static readonly Dictionary<Player, (RoleTypeId role, List<Player> players)> PlayerToAppearanceRole = [];
    static CoroutineHandle? handle;

    public static void Start()
    {
        if (!handle.HasValue)
            handle = Timing.RunCoroutine(Sync());
    }

    public static void Stop()
    {
        if (handle.HasValue)
            Timing.KillCoroutines(handle.Value);
    }

    public static void AddPlayer(Player player, RoleTypeId role)
    {
        Start();
        player.ChangeAppearance(role);
        if (PlayerToAppearanceRole.ContainsKey(player))
            RemovePlayer(player, false);
        IsChaning = true;
        lock (PlayerToAppearanceRole)
        {
            PlayerToAppearanceRole.Add(player, (role, []));
        }
        IsChaning = false;
    }

    public static void RemovePlayer(Player player, bool ChangeAppearance = true)
    {
        if (ChangeAppearance)
            player.ChangeAppearance(player.Role);
        IsChaning = true;
        lock (PlayerToAppearanceRole)
        {
            PlayerToAppearanceRole.Remove(player);
        }
        IsChaning = false;
    }

    public static void ForceSync(Player player)
    {
        Start();
        IsChaning = true;
        lock (PlayerToAppearanceRole)
        {
            for (int i = 0; i < PlayerToAppearanceRole.Count; i++)
            {
                var kv = PlayerToAppearanceRole.ElementAt(i);
                if (kv.Key == player)
                    continue;
                if (!kv.Key.IsAlive)
                    continue;
                kv.Key.ChangeAppearance(kv.Value.role, [player], false);
                if (!kv.Value.players.Contains(player))
                {
                    kv.Value.players.Add(player);
                    PlayerToAppearanceRole[kv.Key] = kv.Value;
                }
            }
        }
        IsChaning = false;
    }

    static IEnumerator<float> Sync()
    {
        yield return 1f;
        while (true)
        {
            if (IsChaning)
                yield return WaitTime;
            lock (PlayerToAppearanceRole)
            {
                for (int i = 0; i < PlayerToAppearanceRole.Count; i++)
                {
                    var kv = PlayerToAppearanceRole.ElementAt(i);
                    // skip in elevator
                    if (ElevatorChamber.AllChambers.Any(x => x.WorldspaceBounds.Contains(kv.Key.Position)))
                        continue;
                    List<Player> playersToSync = [.. Player.ReadyList.Where(x => x != kv.Key)];
                    if (kv.Value.players.Count != 0)
                        playersToSync = [.. playersToSync.Except(kv.Value.players)];
                    if (playersToSync.Count == 0)
                        continue;
                    if (!kv.Key.IsAlive)
                        continue;
                    CL.Debug($"Sync to Ids: {string.Join(", ", playersToSync.Select(x => x.PlayerId))}", DebugAppearanceSyncEnabled);
                    kv.Key.ChangeAppearance(kv.Value.role, playersToSync, false);
                    kv.Value.players.AddRange(playersToSync);
                    PlayerToAppearanceRole[kv.Key] = kv.Value;
                }
            }
            yield return WaitTime;
        }
    }
}
