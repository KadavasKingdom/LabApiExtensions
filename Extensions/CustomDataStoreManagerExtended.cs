using LabApi.Features.Stores;
using System.Reflection;

namespace LabApiExtensions.Extensions;

public static class CustomDataStoreManagerExtended
{
    public static void EnsureExists<TStore>() where TStore : CustomDataStore
    {
        if (!CustomDataStoreManager.IsRegistered<TStore>())
        {
            CustomDataStoreManager.RegisterStore<TStore>();
        }
    }

    public static void EnsureExists(Type type)
    {
        if (!CustomDataStoreManager.IsRegistered(type))
        {
            RegisterStore(type);
        }
    }

    public static bool EnsureRightType(Type type)
    {
        return typeof(CustomDataStore).IsAssignableFrom(type);
    }

    public static bool RegisterStore(Type typeFromHandle)
    {
        if (!EnsureRightType(typeFromHandle))
            return false;

        if (CustomDataStoreManager.RegisteredStores.Contains(typeFromHandle))
        {
            return false;
        }

        MethodInfo method = typeof(CustomDataStore).GetMethod("GetOrAdd", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (method == null)
        {
            return false;
        }

        method = method.MakeGenericMethod(typeFromHandle);
        CustomDataStoreManager.GetOrAddMethods.Add(typeFromHandle, method);
        MethodInfo method2 = typeof(CustomDataStore).GetMethod("Destroy", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (method2 == null)
        {
            return false;
        }

        method2 = method2.MakeGenericMethod(typeFromHandle);
        CustomDataStoreManager.DestroyMethods.Add(typeFromHandle, method2);
        MethodInfo method3 = typeof(CustomDataStore).GetMethod("DestroyAll", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        if (method3 == null)
        {
            return false;
        }

        method3 = method3.MakeGenericMethod(typeFromHandle);
        CustomDataStoreManager.DestroyAllMethods.Add(typeFromHandle, method3);
        CustomDataStoreManager.RegisteredStores.Add(typeFromHandle);
        return true;
    }

    public static IReadOnlyCollection<Player> GetPlayers<TStore>() where TStore : CustomDataStore
    {
        Type typeFromHandle = typeof(TStore);
        return GetPlayers(typeFromHandle);
    }

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

    public static Dictionary<Player, CustomDataStore> GetAll<TStore>() where TStore : CustomDataStore
    {
        Type typeFromHandle = typeof(TStore);
        if (!CustomDataStoreManager.IsRegistered<TStore>())
        {
            return new Dictionary<Player, CustomDataStore>();
        }

        if (!CustomDataStore.StoreInstances.ContainsKey(typeFromHandle))
        {
            return new Dictionary<Player, CustomDataStore>();
        }

        return CustomDataStore.StoreInstances[typeFromHandle];
    }

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

    public static CustomDataStore? GetOrAdd(Player player, Type typeFromHandle)
    {
        if (!EnsureRightType(typeFromHandle))
            return null;

        if (!CustomDataStoreManager.IsRegistered(typeFromHandle))
        {
            RegisterStore(typeFromHandle);
        }

        if (!CustomDataStore.StoreInstances.TryGetValue(typeFromHandle, out Dictionary<Player, CustomDataStore> value))
        {
            value = new Dictionary<Player, CustomDataStore>();
            CustomDataStore.StoreInstances[typeFromHandle] = value;
        }

        if (value.TryGetValue(player, out var value2))
        {
            return value2;
        }

        value2 = value[player] = (CustomDataStore)Activator.CreateInstance(typeFromHandle, [player]);
        return value2;
    }

    public static void Destroy(Player player, Type typeFromHandle)
    {
        if (!EnsureRightType(typeFromHandle))
            return;

        if (CustomDataStore.StoreInstances.TryGetValue(typeFromHandle, out Dictionary<Player, CustomDataStore> value) && value.TryGetValue(player, out var value2))
        {
            value2.Destroy();
        }
    }
}
