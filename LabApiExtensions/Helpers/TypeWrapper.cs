namespace LabApiExtensions.Helpers;

/// <summary>
/// Type wrapper to not need to use <see langword="ref"/> or <see langword="out"/> as parameter.
/// </summary>
/// <typeparam name="T">Any <see langword="type"/>.</typeparam>
/// <remarks>
/// Create a new <see cref="TypeWrapper{T}"/> with <see cref="DefaultValue"/> as <paramref name="value"/>.
/// </remarks>
/// <param name="value">The initial value.</param>
public class TypeWrapper<T>(T value)
	where T : notnull
{
	/// <summary>
	/// Converts the <paramref name="wrapper"/> to <typeparamref name="T"/>.
	/// </summary>
	/// <param name="wrapper">The wrapper.</param>
	public static implicit operator T(TypeWrapper<T> wrapper)
	{
		if (wrapper == null)
		{
			return default!;
		}

		return wrapper.Value;
	}

	/// <summary>
	/// Converts the <paramref name="value"/> to <typeparamref name="T"/> wrapper.
	/// </summary>
	/// <param name="value">The value.</param>
	public static implicit operator TypeWrapper<T>(T value)
	{
		return new(value);
	}

	/// <summary>
	/// Gets the default value.
	/// </summary>
	public T DefaultValue { get; } = value;

	/// <summary>
	/// Gets or sets the Value of the Type.
	/// </summary>
	public T Value { get; set; } = value;

	/// <inheritdoc/>
	public override string ToString()
	{
		return Value.ToString();
	}

	/// <summary>
	/// Parse to a new type wrapper.
	/// </summary>
	/// <returns>The new <see cref="TypeWrapper{T}"/>.</returns>
	public TypeWrapper<T> ToTypeWrapper()
	{
		return new(Value);
	}

	/// <summary>
	/// Parse to a <typeparamref name="T"/> value.
	/// </summary>
	/// <returns>The <see cref="Value"/>.</returns>
	public T ToT()
	{
		return Value;
	}
}
