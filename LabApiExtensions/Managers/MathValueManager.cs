using LabApiExtensions.Configs;
using LabApiExtensions.Enums;

namespace LabApiExtensions.Managers;

/// <summary>
/// Calculation manager for Math Values.
/// </summary>
public static class MathValueManager
{
    #region Float
    /// <summary>
    /// Calculate math with a given input.
    /// </summary>
    /// <param name="mathValue">The math value to calculate.</param>
    /// <param name="inValue">The input value.</param>
    /// <returns>The new value.</returns>
    public static float MathCalculation(this MathValueFloat mathValue, float inValue)
    {
        return mathValue.Math.MathCalculation(inValue, mathValue.Value);
    }

    /// <summary>
    /// Calculate math with a given input.
    /// </summary>
    /// <param name="mathValue">The math value to calculate.</param>
    /// <param name="inValue">The reference for value to change with.</param>
    public static void MathCalculation(this MathValueFloat mathValue, ref float inValue)
    {
        inValue = mathValue.Math.MathCalculation(inValue, mathValue.Value);
    }

    /// <summary>
    /// Calculate math with a given input.
    /// </summary>
    /// <param name="mathOption">The math option to calculate with.</param>
    /// <param name="inValue">The input value to use.</param>
    /// <param name="myValue">The value to calculate.</param>
    /// <returns>The new value.</returns>
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
            MathOption.Subtract_MyWithIn => myValue - inValue,
            MathOption.Divide_MyWithIn => myValue / inValue,
            MathOption.Modulus_MyWithIn => myValue % inValue,
            _ => inValue,
        };
    }
    #endregion
    #region Long
    /// <inheritdoc cref="MathCalculation(MathValueFloat, ref float)"/>
    public static void MathCalculation(this MathValueLong mathValue, ref long inValue)
    {
        inValue = mathValue.Math.MathCalculation(inValue, mathValue.Value);
    }

    /// <inheritdoc cref="MathCalculation(MathValueFloat, float)"/>
    public static long MathCalculation(this MathValueLong mathValue, long inValue)
    {
        return mathValue.Math.MathCalculation(inValue, mathValue.Value);
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
            MathOption.Subtract_MyWithIn => myValue - inValue,
            MathOption.Divide_MyWithIn => myValue / inValue,
            MathOption.Modulus_MyWithIn => myValue % inValue,
            _ => inValue,
        };
    }
    #endregion
    #region Int
    /// <inheritdoc cref="MathCalculation(MathValueFloat, ref float)"/>
    public static void MathCalculation(this MathValueInt mathValue, ref int inValue)
    {
        inValue = mathValue.Math.MathCalculation(inValue, mathValue.Value);
    }

    /// <inheritdoc cref="MathCalculation(MathValueFloat, float)"/>
    public static int MathCalculation(this MathValueInt mathValue, int inValue)
    {
        return mathValue.Math.MathCalculation(inValue, mathValue.Value);
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
            MathOption.Subtract_MyWithIn => myValue - inValue,
            MathOption.Divide_MyWithIn => myValue / inValue,
            MathOption.Modulus_MyWithIn => myValue % inValue,
            _ => inValue,
        };
    }
    #endregion
    #region Short
    /// <inheritdoc cref="MathCalculation(MathValueFloat, ref float)"/>
    public static void MathCalculation(this MathValueShort mathValue, ref short inValue)
    {
        inValue = mathValue.Math.MathCalculation(inValue, mathValue.Value);
    }

    /// <inheritdoc cref="MathCalculation(MathValueFloat, float)"/>
    public static short MathCalculation(this MathValueShort mathValue, short inValue)
    {
        return mathValue.Math.MathCalculation(inValue, mathValue.Value);
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
            MathOption.Subtract_MyWithIn => (short)(myValue - inValue),
            MathOption.Divide_MyWithIn => (short)(myValue / inValue),
            MathOption.Modulus_MyWithIn => (short)(myValue % inValue),
            _ => inValue,
        };
    }
    #endregion
    #region Byte
    /// <inheritdoc cref="MathCalculation(MathValueFloat, ref float)"/>
    public static void MathCalculation(this MathValueByte mathValue, ref byte inValue)
    {
        inValue = mathValue.Math.MathCalculation(inValue, mathValue.Value);
    }

    /// <inheritdoc cref="MathCalculation(MathValueFloat, float)"/>
    public static byte MathCalculation(this MathValueByte mathValue, byte inValue)
    {
        return mathValue.Math.MathCalculation(inValue, mathValue.Value);
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
            MathOption.Subtract_MyWithIn => (byte)(myValue - inValue),
            MathOption.Divide_MyWithIn => (byte)(myValue / inValue),
            MathOption.Modulus_MyWithIn => (byte)(myValue % inValue),
            _ => inValue,
        };
    }
    #endregion
}
