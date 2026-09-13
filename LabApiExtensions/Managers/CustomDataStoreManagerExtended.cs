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
    public static void EnsureExists<TStore>()
        where TStore : CustomDataStore
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
    /// Checks if the <paramref name="type"/> is came from <see cref="CustomDataStore"/>.
    /// </summary>
    /// <param name="type">The type to check.</param>
    /// <returns><see langword="true"/> is the type is valid <see cref="CustomDataStore"/>; otherwise <see langword="false"/>.</returns>
    public static bool IsRightType(Type type)
    {
        return typeof(CustomDataStore).IsAssignableFrom(type);
    }

    /// <summary>
    /// Tries to register <paramref name="dataStoreType"/>.
    /// </summary>
    /// <param name="dataStoreType">The data store type to register.</param>
    /// <returns><see langword="true"/> is the type is registered; otherwise <see langword="false"/>.</returns>
    public static bool RegisterStore(Type dataStoreType)
    {
        if (!IsRightType(dataStoreType))
        {
            return false;
        }

        if (CustomDataStoreManager.RegisteredStores.Contains(dataStoreType))
        {
            return false;
        }

        MethodInfo method = typeof(CustomDataStore).GetMethod(nameof(CustomDataStore.GetOrAdd), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (method == null)
        {
            return false;
        }

        method = method.MakeGenericMethod(dataStoreType);
        CustomDataStoreManager.GetOrAddMethods.Add(dataStoreType, method);
        MethodInfo method2 = typeof(CustomDataStore).GetMethod(nameof(CustomDataStore.Destroy), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (method2 == null)
        {
            return false;
        }

        method2 = method2.MakeGenericMethod(dataStoreType);
        CustomDataStoreManager.DestroyMethods.Add(dataStoreType, method2);
        MethodInfo method3 = typeof(CustomDataStore).GetMethod(nameof(CustomDataStore.DestroyAll), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (method3 == null)
        {
            return false;
        }

        method3 = method3.MakeGenericMethod(dataStoreType);
        CustomDataStoreManager.DestroyAllMethods.Add(dataStoreType, method3);
        CustomDataStoreManager.RegisteredStores.Add(dataStoreType);
        return true;
    }

    /// <summary>
    /// Get all players of the <typeparamref name="TStore"/>.
    /// </summary>
    /// <typeparam name="TStore">Any <see cref="CustomDataStore"/>.</typeparam>
    /// <returns>The <see cref="Player"/>'s this data store has.</returns>
    public static IReadOnlyCollection<Player> GetPlayers<TStore>()
        where TStore : CustomDataStore
    {
        Type typeFromHandle = typeof(TStore);
        return GetPlayers(typeFromHandle);
    }

    /// <summary>
    /// Get all players from the type <paramref name="dataStoreType"/>.
    /// </summary>
    /// <param name="dataStoreType">The data store type.</param>
    /// <returns>The <see cref="Player"/>'s this data store has.</returns>
    public static IReadOnlyCollection<Player> GetPlayers(Type dataStoreType)
    {
        if (!IsRightType(dataStoreType))
        {
            return [];
        }

        if (!CustomDataStoreManager.IsRegistered(dataStoreType))
        {
            return [];
        }

        if (!CustomDataStore.StoreInstances.TryGetValue(dataStoreType, out Dictionary<Player, CustomDataStore>? value))
        {
            return [];
        }

        return value.Keys;
    }

    /// <summary>
    /// Get all instance of <typeparamref name="TStore"/>.
    /// </summary>
    /// <typeparam name="TStore">Any <see cref="CustomDataStore"/>.</typeparam>
    /// <returns>The instances of the <typeparamref name="TStore"/> type.</returns>
    public static Dictionary<Player, CustomDataStore> GetAll<TStore>()
        where TStore : CustomDataStore
    {
        Type dataStoreType = typeof(TStore);
        if (!CustomDataStoreManager.IsRegistered<TStore>())
        {
            return [];
        }

        if (!CustomDataStore.StoreInstances.TryGetValue(dataStoreType, out Dictionary<Player, CustomDataStore>? value))
        {
            return [];
        }

        return value;
    }

    /// <summary>
    /// Get all instance of type <paramref name="dataStoreType"/>.
    /// </summary>
    /// <param name="dataStoreType">The data store type.</param>
    /// <returns>The instances of the <paramref name="dataStoreType"/> type.</returns>
    public static Dictionary<Player, CustomDataStore> GetAll(Type dataStoreType)
    {
        if (!IsRightType(dataStoreType))
        {
            return [];
        }

        if (!CustomDataStoreManager.IsRegistered(dataStoreType))
        {
            return [];
        }

        if (!CustomDataStore.StoreInstances.TryGetValue(dataStoreType, out Dictionary<Player, CustomDataStore>? value))
        {
            return [];
        }

        return value;
    }

    /// <summary>
    /// Gets or add <paramref name="dataStoreType"/> for <paramref name="player"/>.
    /// </summary>
    /// <param name="player">The player to get or add the data store to.</param>
    /// <param name="dataStoreType">The data store type.</param>
    /// <returns>The data store or <see langword="null"/>.</returns>
    public static CustomDataStore? GetOrAdd(Player player, Type dataStoreType)
    {
        if (!IsRightType(dataStoreType))
        {
            return null;
        }

        if (!CustomDataStoreManager.IsRegistered(dataStoreType))
        {
            RegisterStore(dataStoreType);
        }

        if (!CustomDataStore.StoreInstances.TryGetValue(dataStoreType, out Dictionary<Player, CustomDataStore> value))
        {
            value = [];
            CustomDataStore.StoreInstances[dataStoreType] = value;
        }

        if (value.TryGetValue(player, out CustomDataStore value2))
        {
            return value2;
        }

        value2 = value[player] = (CustomDataStore)Activator.CreateInstance(dataStoreType, [player]);
        return value2;
    }

    /// <summary>
    /// Checks if <paramref name="dataStoreType"/> exists on <paramref name="player"/>.
    /// </summary>
    /// <param name="player">The player to check.</param>
    /// <param name="dataStoreType">The data store type.</param>
    /// <returns><see langword="true"/> is the type is registered and contains a player; otherwise <see langword="false"/>.</returns>
    public static bool Exists(Player player, Type dataStoreType)
    {
        if (!IsRightType(dataStoreType))
        {
            return false;
        }

        if (!CustomDataStoreManager.IsRegistered(dataStoreType))
        {
            RegisterStore(dataStoreType);
        }

        if (!CustomDataStore.StoreInstances.TryGetValue(dataStoreType, out Dictionary<Player, CustomDataStore> value))
        {
            return false;
        }

        return value.ContainsKey(player);
    }

    /// <summary>
    /// Destroys <paramref name="player"/>'s <paramref name="dataStoreType"/>.
    /// </summary>
    /// <param name="player">The player to remove the type of.</param>
    /// <param name="dataStoreType">The data store type.</param>
    public static void Destroy(Player player, Type dataStoreType)
    {
        if (!IsRightType(dataStoreType))
        {
            return;
        }

        if (CustomDataStore.StoreInstances.TryGetValue(dataStoreType, out Dictionary<Player, CustomDataStore> value) && value.TryGetValue(player, out CustomDataStore value2))
        {
            value2.Destroy();
        }
    }
}
