namespace LabApiExtensions.Helpers;

/// <summary>
/// Type wrapper to not need to use <see langword="ref"/> or <see langword="out"/> as parameter.
/// </summary>
/// <typeparam name="T">Any <see langword="type"/>.</typeparam>
/// <remarks>
/// Create a new <see cref="TypeWrapper{T}"/> with <see cref="DefaultValue"/> as <paramref name="value"/>.
/// </remarks>
/// <param name="value">The initial value.</param>
public class TypeWrapper<T>(T value) where T : notnull
{
    /// <summary>
    /// The default value.
    /// </summary>
    public readonly T DefaultValue = value;
    /// <summary>
    /// The Value of the Type.
    /// </summary>
    public T Value { get; set; } = value;

    /// <inheritdoc/>
    public override string ToString()
    {
        return Value.ToString();
    }

    /// <inheritdoc/>
    public static implicit operator T(TypeWrapper<T> wrapper)
    {
        return wrapper.Value;
    }

    /// <inheritdoc/>
    public static implicit operator TypeWrapper<T>(T value)
    {
        return new(value);
    }
}
