namespace LabApiExtensions.Enums;

/// <summary>
/// List operation for <see cref="FakeExtension.FakeSyncListExtension"/>.
/// </summary>
public enum ListOperation : byte
{
    /// <summary>
    /// Add value opertion.
    /// </summary>
    Add,
    /// <summary>
    /// Clear list operation.
    /// </summary>
    Clear,
    /// <summary>
    /// Insert value operation.
    /// </summary>
    Insert,
    /// <summary>
    /// Remove at index operation.
    /// </summary>
    RemoveAt,
    /// <summary>
    /// Set value operation.
    /// </summary>
    Set,
}
