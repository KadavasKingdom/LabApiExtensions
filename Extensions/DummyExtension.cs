using InventorySystem.Items.Autosync;
using PlayerRoles.Subroutines;

namespace LabApiExtensions.Extensions;

public static class DummyExtension
{
    public static bool TryRunItemAction(AutosyncItem item, ActionName actionName, bool isClick)
    {
        if (item == null)
            return false;
        if (!item.IsEmulatedDummy)
            return false;
        item.DummyEmulator.AddEntry(actionName, isClick);
        return true;
    }

    public static bool TryStopItemAction(AutosyncItem item, ActionName actionName)
    {
        if (item == null)
            return false;
        if (!item.IsEmulatedDummy)
            return false;
        item.DummyEmulator.RemoveEntry(actionName);
        return true;
    }

    public static bool TryRunItemAction<T>(T item, ActionName actionName, bool isClick) where T : AutosyncItem
    {
        if (item == null)
            return false;
        if (!item.IsEmulatedDummy)
            return false;
        item.DummyEmulator.AddEntry(actionName, isClick);
        return true;
    }

    public static bool TryStopItemAction<T>(T item, ActionName actionName) where T : AutosyncItem
    {
        if (item == null)
            return false;
        if (!item.IsEmulatedDummy)
            return false;
        item.DummyEmulator.RemoveEntry(actionName);
        return true;
    }

    public static bool TryRunRoleAction(SubroutineBase subroutine, ActionName actionName, bool isClick)
    {
        if (subroutine == null)
            return false;
        if (!subroutine.Role.IsEmulatedDummy)
            return false;
        subroutine.DummyEmulator.AddEntry(actionName, isClick);
        return true;
    }

    public static bool TryStopRoleAction(SubroutineBase subroutine, ActionName actionName)
    {
        if (subroutine == null)
            return false;
        if (!subroutine.Role.IsEmulatedDummy)
            return false;
        subroutine.DummyEmulator.RemoveEntry(actionName);
        return true;
    }

    public static bool TryRunRoleAction<T>(T subroutine, ActionName actionName, bool isClick) where T : SubroutineBase
    {
        if (subroutine == null)
            return false;
        if (!subroutine.Role.IsEmulatedDummy)
            return false;
        subroutine.DummyEmulator.AddEntry(actionName, isClick);
        return true;
    }

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
