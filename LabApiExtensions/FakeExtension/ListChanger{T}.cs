using LabApiExtensions.Enums;
using Mirror;

namespace LabApiExtensions.FakeExtension;

/// <summary>
/// Public representation of <see cref="SyncList{T}.Change"/>.
/// </summary>
/// <typeparam name="T">Any type.</typeparam>
public class ListChanger<T>
{
    /// <summary>
    /// Gets or sets the value to use.
    /// </summary>
    public T Value { get; set; } = default!;

    /// <summary>
    /// Gets or sets the index to use.
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// Gets or sets the list operation.
    /// </summary>
    public ListOperation Operation { get; set; }
}
