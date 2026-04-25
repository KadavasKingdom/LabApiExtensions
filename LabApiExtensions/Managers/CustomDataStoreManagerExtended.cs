using LabApi.Features.Stores;
using System.Reflection;

namespace LabApiExtensions.Managers;

/// <summary>
/// Extendend manager of <see cref="CustomDataStoreManager"/>.
/// </summary>
public static class CustomDataStoreManagerExtended
{
    /// <summary>
    /// Ensures the <typeparamref name="TStore"/> exists.
    /// </summary>
    /// <typeparam name="TStore">Any <see cref="CustomDataStore"/>.</typeparam>
    public static void EnsureExists<TStore>() where TStore : CustomDataStore
    {
        if (!CustomDataStoreManager.IsRegistered<TStore>())
        {
            CustomDataStoreManager.RegisterStore<TStore>();
        }
    }

    /// <summary>
    /// Ensures the <paramref name="type"/> exists.
    /// </summary>
    /// <param name="type">The type to register.</param>
    public static void EnsureExists(Type type)
    {
        if (!CustomDataStoreManager.IsRegistered(type))
        {
            RegisterStore(type);
        }
    }

    /// <summary>
    /// Ensures if the <paramref name="type"/> is came from <see cref="CustomDataStore"/>.
    /// </summary>
    /// <param name="type">The type to check.</param>
    /// <returns></returns>
    public static bool EnsureRightType(Type type)
    {
        return typeof(CustomDataStore).IsAssignableFrom(type);
    }

    /// <summary>
    /// Tries to register <paramref name="typeFromHandle"/>.
    /// </summary>
    /// <param name="typeFromHandle">The type to register.</param>
    /// <returns></returns>
    public static bool RegisterStore(Type typeFromHandle)
    {
        if (!EnsureRightType(typeFromHandle))
            return false;

        if (CustomDataStoreManager.RegisteredStores.Contains(typeFromHandle))
        {
            return false;
        }

        MethodInfo method = typeof(CustomDataStore).GetMethod(nameof(CustomDataStore.GetOrAdd), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (method == null)
        {
            return false;
        }

        method = method.MakeGenericMethod(typeFromHandle);
        CustomDataStoreManager.GetOrAddMethods.Add(typeFromHandle, method);
        MethodInfo method2 = typeof(CustomDataStore).GetMethod(nameof(CustomDataStore.Destroy), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (method2 == null)
        {
            return false;
        }

        method2 = method2.MakeGenericMethod(typeFromHandle);
        CustomDataStoreManager.DestroyMethods.Add(typeFromHandle, method2);
        MethodInfo method3 = typeof(CustomDataStore).GetMethod(nameof(CustomDataStore.DestroyAll), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (method3 == null)
        {
            return false;
        }

        method3 = method3.MakeGenericMethod(typeFromHandle);
        CustomDataStoreManager.DestroyAllMethods.Add(typeFromHandle, method3);
        CustomDataStoreManager.RegisteredStores.Add(typeFromHandle);
        return true;
    }

    /// <summary>
    /// Get all players of the <typeparamref name="TStore"/>.
    /// </summary>
    /// <typeparam name="TStore"></typeparam>
    /// <returns></returns>
    public static IReadOnlyCollection<Player> GetPlayers<TStore>() where TStore : CustomDataStore
    {
        Type typeFromHandle = typeof(TStore);
        return GetPlayers(typeFromHandle);
    }

    /// <summary>
    /// Get all players from the type <paramref name="typeFromHandle"/>.
    /// </summary>
    /// <param name="typeFromHandle"></param>
    /// <returns></returns>
    public static IReadOnlyCollection<Player> GetPlayers(Type typeFromHandle)
    {
        if (!EnsureRightType(typeFromHandle))
            return [];

        if (!CustomDataStoreManager.IsRegistered(typeFromHandle))
        {
            return [];
        }

        if (!CustomDataStore.StoreInstances.ContainsKey(typeFromHandle))
        {
            return [];
        }

        return CustomDataStore.StoreInstances[typeFromHandle].Keys;
    }

    /// <summary>
    /// Get all instance of <typeparamref name="TStore"/>.
    /// </summary>
    /// <typeparam name="TStore"></typeparam>
    /// <returns></returns>
    public static Dictionary<Player, CustomDataStore> GetAll<TStore>() where TStore : CustomDataStore
    {
        Type typeFromHandle = typeof(TStore);
        if (!CustomDataStoreManager.IsRegistered<TStore>())
        {
            return [];
        }

        if (!CustomDataStore.StoreInstances.ContainsKey(typeFromHandle))
        {            
            return [];
        }

        return CustomDataStore.StoreInstances[typeFromHandle];
    }

    /// <summary>
    /// Get all instance of type <paramref name="typeFromHandle"/>.
    /// </summary>
    /// <param name="typeFromHandle"></param>
    /// <returns></returns>
    public static Dictionary<Player, CustomDataStore> GetAll(Type typeFromHandle) 
    {
        if (!EnsureRightType(typeFromHandle))
            return [];

        if (!CustomDataStoreManager.IsRegistered(typeFromHandle))
        {
            return [];
        }

        if (!CustomDataStore.StoreInstances.ContainsKey(typeFromHandle))
        {
            return [];
        }

        return CustomDataStore.StoreInstances[typeFromHandle];
    }

    /// <summary>
    /// Gets or add <paramref name="typeFromHandle"/> for <paramref name="player"/>.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="typeFromHandle"></param>
    /// <returns></returns>
    public static CustomDataStore GetOrAdd(Player player, Type typeFromHandle)
    {
        if (!EnsureRightType(typeFromHandle))
            return null;

        if (!CustomDataStoreManager.IsRegistered(typeFromHandle))
        {
            RegisterStore(typeFromHandle);
        }

        if (!CustomDataStore.StoreInstances.TryGetValue(typeFromHandle, out Dictionary<Player, CustomDataStore> value))
        {
            value = [];
            CustomDataStore.StoreInstances[typeFromHandle] = value;
        }

        if (value.TryGetValue(player, out CustomDataStore value2))
        {
            return value2;
        }

        value2 = value[player] = (CustomDataStore)Activator.CreateInstance(typeFromHandle, [player]);
        return value2;
    }

    /// <summary>
    /// Checks if <paramref name="typeFromHandle"/> exists on <paramref name="player"/>.
    /// </summary>
    /// <param name="player">The player to check.</param>
    /// <param name="typeFromHandle"></param>
    /// <returns></returns>
    public static bool Exists(Player player, Type typeFromHandle)
    {
        if (!EnsureRightType(typeFromHandle))
            return false;

        if (!CustomDataStoreManager.IsRegistered(typeFromHandle))
        {
            RegisterStore(typeFromHandle);
        }

        if (!CustomDataStore.StoreInstances.TryGetValue(typeFromHandle, out Dictionary<Player, CustomDataStore> value))
            return false;

        return value.ContainsKey(player);
    }

    /// <summary>
    /// Destroys <paramref name="player"/>'s <paramref name="typeFromHandle"/>.
    /// </summary>
    /// <param name="player">The player to remove the type of.</param>
    /// <param name="typeFromHandle"></param>
    public static void Destroy(Player player, Type typeFromHandle)
    {
        if (!EnsureRightType(typeFromHandle))
            return;

        if (CustomDataStore.StoreInstances.TryGetValue(typeFromHandle, out Dictionary<Player, CustomDataStore> value) && value.TryGetValue(player, out CustomDataStore value2))
        {
            value2.Destroy();
        }
    }
}
