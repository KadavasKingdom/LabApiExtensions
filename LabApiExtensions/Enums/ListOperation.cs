namespace LabApiExtensions.Enums;

/// <summary>
/// List operation for <see cref="FakeExtension.FakeSyncListExtension"/>.
/// </summary>
#pragma warning disable CA1028 // Enum Storage should be Int32
public enum ListOperation : byte
#pragma warning restore CA1028 // Enum Storage should be Int32
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
