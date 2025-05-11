using Interactables.Interobjects;
using MEC;
using PlayerRoles;

namespace LabApiExtensions.Extensions;

public static class AppearanceSyncExtension
{
    static float WaitTime = 5f;
    static readonly Dictionary<Player, (RoleTypeId role, List<Player> players)> PlayerToSpyRole = [];
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
        if (PlayerToSpyRole.ContainsKey(player))
            RemovePlayer(player, false);
        lock (PlayerToSpyRole)
        {
            PlayerToSpyRole.Add(player, (role, []));
        }
    }

    public static void RemovePlayer(Player player, bool ChangeAppearance = true)
    {
        if (ChangeAppearance)
            player.ChangeAppearance(player.Role);
        lock (PlayerToSpyRole)
        {
            PlayerToSpyRole.Remove(player);
        }
    }

    public static void ForceSync(Player player)
    {
        Start();
        lock (PlayerToSpyRole)
        {
            for (int i = 0; i < PlayerToSpyRole.Count; i++)
            {
                var kv = PlayerToSpyRole.ElementAt(i);
                if (kv.Key == player)
                    continue;
                kv.Value.players.Remove(player);
                PlayerToSpyRole[kv.Key] = kv.Value;
            }
        }
    }

    static IEnumerator<float> Sync()
    {
        yield return 1f;
        while (true)
        {
            lock (PlayerToSpyRole)
            {
                for (int i = 0; i < PlayerToSpyRole.Count; i++)
                {
                    var kv = PlayerToSpyRole.ElementAt(i);
                    // skip in elevator
                    if (ElevatorChamber.AllChambers.Any(x => x.WorldspaceBounds.Contains(kv.Key.Position)))
                        continue;
                    List<Player> playersToSync = [.. Player.ReadyList.Where(x => x != kv.Key)];
                    if (kv.Value.players.Count != 0)
                        playersToSync = [.. playersToSync.Except(kv.Value.players)];
                    if (playersToSync.Count == 0)
                        continue;
                    //CL.Info("Sync to Ids: " + string.Join(", ", playersToSync.Select(x=>x.PlayerId)));
                    kv.Key.ChangeAppearance(kv.Value.role, playersToSync, false);
                    kv.Value.players.AddRange(playersToSync);
                    PlayerToSpyRole[kv.Key] = kv.Value;
                }
            }
            yield return WaitTime;
        }
    }
}
