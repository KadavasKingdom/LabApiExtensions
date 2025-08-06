using UnityEngine;

namespace LabApiExtensions.Helpers;

/// <summary>
/// Helper class to print Game Objects.
/// </summary>
public static class GameObjectPritnHelper
{
    /// <summary>
    /// Print the <see cref="GameObject"/>'s <see cref="Component"/>.
    /// </summary>
    /// <param name="object">The current <see cref="GameObject"/>.</param>
    /// <returns>The <see cref="GameObject"/>'s <see cref="Component"/> tree to print.</returns>
    public static string PrintComponentTree(this GameObject @object, int maxLevel = -1)
    {
        return "\n" + @object.DeepLayersPrint(0, maxLevel);
    }

    private static string DeepLayersPrint(this GameObject @object, int level, int maxLevel)
    {
        if (level == maxLevel)
            return string.Empty;
        string log = string.Empty;
        foreach (var item in @object.GetComponents(typeof(Component)))
        {
            log += $"{string.Join(" ", Enumerable.Repeat("\t", level))}{item}\n";
        }
        for (int i = 0; i < @object.transform.childCount; i++)
        {
            var child = @object.transform.GetChild(i);
            log += $"{string.Join(" ", Enumerable.Repeat("\t", level))}{child}\n";
            log += child.gameObject.DeepLayersPrint(level + 1, maxLevel);
        }
        return log;
    }
}
