using InventorySystem.Items.Autosync;
using PlayerRoles.Subroutines;

namespace LabApiExtensions.Extensions;

public static class DummyExtension
{
    /// <summary>
    /// Try run <see cref="AutosyncItem"/> dummy action with <paramref name="actionName"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item">Item to run action to.</param>
    /// <param name="actionName">The <see cref="ActionName"/>.</param>
    /// <param name="isClick">Is click action.</param>
    /// <returns><see langword="true"/> on success otherwise <see langword="false"/></returns>
    public static bool TryRunItemAction<T>(T item, ActionName actionName, bool isClick) where T : AutosyncItem
    {
        if (item == null)
            return false;
        if (!item.IsEmulatedDummy)
            return false;
        item.DummyEmulator.AddEntry(actionName, isClick);
        return true;
    }

    /// <summary>
    /// Try stop <see cref="AutosyncItem"/> dummy action with <paramref name="actionName"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item">Item to stop action to.</param>
    /// <param name="actionName">The <see cref="ActionName"/>.</param>
    /// <returns><see langword="true"/> on success otherwise <see langword="false"/></returns>
    public static bool TryStopItemAction<T>(T item, ActionName actionName) where T : AutosyncItem
    {
        if (item == null)
            return false;
        if (!item.IsEmulatedDummy)
            return false;
        item.DummyEmulator.RemoveEntry(actionName);
        return true;
    }

    /// <summary>
    /// Try run <see cref="SubroutineBase"/> dummy action with <paramref name="actionName"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="subroutine">The subroutine to run action to.</param>
    /// <param name="actionName">The <see cref="ActionName"/>.</param>
    /// <param name="isClick">Is click action.</param>
    /// <returns><see langword="true"/> on success otherwise <see langword="false"/></returns>
    public static bool TryRunRoleAction<T>(T subroutine, ActionName actionName, bool isClick) where T : SubroutineBase
    {
        if (subroutine == null)
            return false;
        if (!subroutine.Role.IsEmulatedDummy)
            return false;
        subroutine.DummyEmulator.AddEntry(actionName, isClick);
        return true;
    }

    /// <summary>
    /// Try stop <see cref="SubroutineBase"/> dummy action with <paramref name="actionName"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="subroutine">The subroutine to stop action to.</param>
    /// <param name="actionName">The <see cref="ActionName"/>.</param>
    /// <returns><see langword="true"/> on success otherwise <see langword="false"/></returns>
    public static bool TryStopRoleAction<T>(T subroutine, ActionName actionName) where T : SubroutineBase
    {
        if (subroutine == null)
            return false;
        if (!subroutine.Role.IsEmulatedDummy)
            return false;
        subroutine.DummyEmulator.RemoveEntry(actionName);
        return true;
    }
}
