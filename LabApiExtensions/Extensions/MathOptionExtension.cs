using LabApiExtensions.Enums;

namespace LabApiExtensions.Extensions;

/// <summary>
/// Provides an extensions for <see cref="MathOption"/>.
/// </summary>
public static class MathOptionExtension
{
	/// <summary>
	/// Calculate math with a given input.
	/// </summary>
	/// <param name="mathOption">The math option to calculate with.</param>
	/// <param name="inValue">The input value to use.</param>
	/// <param name="myValue">The value to calculate.</param>
	/// <returns>The new value.</returns>
	public static double MathCalculation(this MathOption mathOption, double inValue, double myValue)
	{
		return mathOption switch
		{
			MathOption.None => inValue,
			MathOption.Set => myValue,
			MathOption.Add => inValue + myValue,
			MathOption.Subtract => inValue - myValue,
			MathOption.Multiply => inValue * myValue,
			MathOption.Divide => inValue / myValue,
			MathOption.Modulus => inValue % myValue,
			MathOption.SubtractMyWithIn => myValue - inValue,
			MathOption.DivideMyWithIn => myValue / inValue,
			MathOption.ModulusMyWithIn => myValue % inValue,
			_ => inValue,
		};
	}

	/// <inheritdoc cref="MathCalculation(MathOption, double, double)"/>
	public static float MathCalculation(this MathOption mathOption, float inValue, float myValue)
	{
		return mathOption switch
		{
			MathOption.None => inValue,
			MathOption.Set => myValue,
			MathOption.Add => inValue + myValue,
			MathOption.Subtract => inValue - myValue,
			MathOption.Multiply => inValue * myValue,
			MathOption.Divide => inValue / myValue,
			MathOption.Modulus => inValue % myValue,
			MathOption.SubtractMyWithIn => myValue - inValue,
			MathOption.DivideMyWithIn => myValue / inValue,
			MathOption.ModulusMyWithIn => myValue % inValue,
			_ => inValue,
		};
	}

	/// <inheritdoc cref="MathCalculation(MathOption, float, float)"/>
	public static ulong MathCalculation(this MathOption mathOption, ulong inValue, ulong myValue)
	{
		return mathOption switch
		{
			MathOption.None => inValue,
			MathOption.Set => myValue,
			MathOption.Add => inValue + myValue,
			MathOption.Subtract => inValue - myValue,
			MathOption.Multiply => inValue * myValue,
			MathOption.Divide => inValue / myValue,
			MathOption.Modulus => inValue % myValue,
			MathOption.SubtractMyWithIn => myValue - inValue,
			MathOption.DivideMyWithIn => myValue / inValue,
			MathOption.ModulusMyWithIn => myValue % inValue,
			_ => inValue,
		};
	}

	/// <inheritdoc cref="MathCalculation(MathOption, float, float)"/>
	public static long MathCalculation(this MathOption mathOption, long inValue, long myValue)
	{
		return mathOption switch
		{
			MathOption.None => inValue,
			MathOption.Set => myValue,
			MathOption.Add => inValue + myValue,
			MathOption.Subtract => inValue - myValue,
			MathOption.Multiply => inValue * myValue,
			MathOption.Divide => inValue / myValue,
			MathOption.Modulus => inValue % myValue,
			MathOption.SubtractMyWithIn => myValue - inValue,
			MathOption.DivideMyWithIn => myValue / inValue,
			MathOption.ModulusMyWithIn => myValue % inValue,
			_ => inValue,
		};
	}

	/// <inheritdoc cref="MathCalculation(MathOption, float, float)"/>
	public static uint MathCalculation(this MathOption mathOption, uint inValue, uint myValue)
	{
		return mathOption switch
		{
			MathOption.None => inValue,
			MathOption.Set => myValue,
			MathOption.Add => inValue + myValue,
			MathOption.Subtract => inValue - myValue,
			MathOption.Multiply => inValue * myValue,
			MathOption.Divide => inValue / myValue,
			MathOption.Modulus => inValue % myValue,
			MathOption.SubtractMyWithIn => myValue - inValue,
			MathOption.DivideMyWithIn => myValue / inValue,
			MathOption.ModulusMyWithIn => myValue % inValue,
			_ => inValue,
		};
	}

	/// <inheritdoc cref="MathCalculation(MathOption, float, float)"/>
	public static int MathCalculation(this MathOption mathOption, int inValue, int myValue)
	{
		return mathOption switch
		{
			MathOption.None => inValue,
			MathOption.Set => myValue,
			MathOption.Add => inValue + myValue,
			MathOption.Subtract => inValue - myValue,
			MathOption.Multiply => inValue * myValue,
			MathOption.Divide => inValue / myValue,
			MathOption.Modulus => inValue % myValue,
			MathOption.SubtractMyWithIn => myValue - inValue,
			MathOption.DivideMyWithIn => myValue / inValue,
			MathOption.ModulusMyWithIn => myValue % inValue,
			_ => inValue,
		};
	}

	/// <inheritdoc cref="MathCalculation(MathOption, float, float)"/>
	public static short MathCalculation(this MathOption mathOption, short inValue, short myValue)
	{
		return mathOption switch
		{
			MathOption.None => inValue,
			MathOption.Set => myValue,
			MathOption.Add => (short)(inValue + myValue),
			MathOption.Subtract => (short)(inValue - myValue),
			MathOption.Multiply => (short)(inValue * myValue),
			MathOption.Divide => (short)(inValue / myValue),
			MathOption.Modulus => (short)(inValue % myValue),
			MathOption.SubtractMyWithIn => (short)(myValue - inValue),
			MathOption.DivideMyWithIn => (short)(myValue / inValue),
			MathOption.ModulusMyWithIn => (short)(myValue % inValue),
			_ => inValue,
		};
	}

	/// <inheritdoc cref="MathCalculation(MathOption, float, float)"/>
	public static ushort MathCalculation(this MathOption mathOption, ushort inValue, ushort myValue)
	{
		return mathOption switch
		{
			MathOption.None => inValue,
			MathOption.Set => myValue,
			MathOption.Add => (ushort)(inValue + myValue),
			MathOption.Subtract => (ushort)(inValue - myValue),
			MathOption.Multiply => (ushort)(inValue * myValue),
			MathOption.Divide => (ushort)(inValue / myValue),
			MathOption.Modulus => (ushort)(inValue % myValue),
			MathOption.SubtractMyWithIn => (ushort)(myValue - inValue),
			MathOption.DivideMyWithIn => (ushort)(myValue / inValue),
			MathOption.ModulusMyWithIn => (ushort)(myValue % inValue),
			_ => inValue,
		};
	}

	/// <inheritdoc cref="MathCalculation(MathOption, float, float)"/>
	public static byte MathCalculation(this MathOption mathOption, byte inValue, byte myValue)
	{
		return mathOption switch
		{
			MathOption.None => inValue,
			MathOption.Set => myValue,
			MathOption.Add => (byte)(inValue + myValue),
			MathOption.Subtract => (byte)(inValue - myValue),
			MathOption.Multiply => (byte)(inValue * myValue),
			MathOption.Divide => (byte)(inValue / myValue),
			MathOption.SubtractMyWithIn => (byte)(myValue - inValue),
			MathOption.DivideMyWithIn => (byte)(myValue / inValue),
			MathOption.ModulusMyWithIn => (byte)(myValue % inValue),
			_ => inValue,
		};
	}

	/// <inheritdoc cref="MathCalculation(MathOption, float, float)"/>
	public static sbyte MathCalculation(this MathOption mathOption, sbyte inValue, sbyte myValue)
	{
		return mathOption switch
		{
			MathOption.None => inValue,
			MathOption.Set => myValue,
			MathOption.Add => (sbyte)(inValue + myValue),
			MathOption.Subtract => (sbyte)(inValue - myValue),
			MathOption.Multiply => (sbyte)(inValue * myValue),
			MathOption.Divide => (sbyte)(inValue / myValue),
			MathOption.SubtractMyWithIn => (sbyte)(myValue - inValue),
			MathOption.DivideMyWithIn => (sbyte)(myValue / inValue),
			MathOption.ModulusMyWithIn => (sbyte)(myValue % inValue),
			_ => inValue,
		};
	}
}
