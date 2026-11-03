using LabApiExtensions.Enums;
using LabApiExtensions.Extensions;

namespace LabApiExtensions.Configs;

/// <summary>
/// Option to specify math operation and value for it.
/// </summary>
/// <param name="Math">The mathematical operation to associate with the value.</param>
/// <param name="Value">The numeric value to be used with the specified mathematical operation.</param>
public record class MathValueByte(MathOption Math = MathOption.None, byte Value = byte.MinValue)
{
	/// <summary>
	/// Calculate math with a given input.
	/// </summary>
	/// <param name="inValue">The input value.</param>
	/// <returns>The new value.</returns>
	public byte MathCalculation(byte inValue)
	{
		return Math.MathCalculation(inValue, Value);
	}

	/// <summary>
	/// Calculate math with a given input.
	/// </summary>
	/// <param name="inValue">The reference for value to change with.</param>
	public void MathCalculation(ref byte inValue)
	{
		inValue = Math.MathCalculation(inValue, Value);
	}
}
