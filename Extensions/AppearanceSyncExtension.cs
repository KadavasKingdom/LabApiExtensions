using Interactables.Interobjects;
using MEC;
using PlayerRoles;

namespace LabApiExtensions.Extensions;

public static class AppearanceSyncExtension
{
    static readonly float WaitTime = 10f;
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
        lock (PlayerToSpyRole)
        {
            PlayerToSpyRole.Add(player, (role, []));
        }
    }

    public static void RemovePlayer(Player player)
    {
        lock (PlayerToSpyRole)
        {
            PlayerToSpyRole.Remove(player);
        }
    }

    public static void ForceSync(Player player)
    {
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
                    //Log.Info("Sync to Ids: " + string.Join(", ", playersToSync.Select(x=>x.Id)));
                    byte unit = kv.Key.UnitId == -1 ? (byte)0 : (byte)kv.Key.UnitId;
                    kv.Key.ChangeAppearance(kv.Value.role, playersToSync, false, unit);
                    kv.Value.players.AddRange(playersToSync);
                    PlayerToSpyRole[kv.Key] = kv.Value;
                }
            }
            yield return WaitTime;
        }
    }
}
