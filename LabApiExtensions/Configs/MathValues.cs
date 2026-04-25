using LabApiExtensions.Enums;

namespace LabApiExtensions.Configs;

/// <summary>
/// Option to specify math operation and value for it.
/// </summary>
public sealed class MathValueDouble
{
    /// <summary>
    /// The value to apply with the math operation.
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// Gets or sets the mathematical options to use for calculations.
    /// </summary>
    public MathOption Math { get; set; }

    /// <summary>
    /// Initializes a new instance of the MathValueDouble class.
    /// </summary>
    public MathValueDouble() { }

    /// <summary>
    /// Initializes a new instance of the MathValueDouble class with the specified mathematical operation and value.
    /// </summary>
    /// <param name="math">The mathematical operation to associate with the value.</param>
    /// <param name="value">The numeric value to be used with the specified mathematical operation.</param>
    public MathValueDouble(MathOption math, double value)
    {
        Math = math;
        Value = value;
    }
}

/// <inheritdoc cref="MathValueDouble"/>
public sealed class MathValueFloat
{
    /// <inheritdoc cref="MathValueDouble.Value"/>
    public float Value { get; set; }

    /// <inheritdoc cref="MathValueDouble.Math"/>
    public MathOption Math { get; set; }

    /// <summary>
    /// Initializes a new instance of the MathValueFloat class.
    /// </summary>
    public MathValueFloat() { }

    /// <summary>
    /// Initializes a new instance of the MathValueFloat class with the specified mathematical operation and value.
    /// </summary>
    /// <param name="math">The mathematical operation to associate with the value.</param>
    /// <param name="value">The numeric value to be used with the specified mathematical operation.</param>
    public MathValueFloat(MathOption math, float value)
    {
        Math = math;
        Value = value;
    }
}

/// <inheritdoc cref="MathValueDouble"/>
public sealed class MathValueLong
{
    /// <inheritdoc cref="MathValueDouble.Value"/>
    public long Value { get; set; }

    /// <inheritdoc cref="MathValueDouble.Math"/>
    public MathOption Math { get; set; }

    /// <summary>
    /// Initializes a new instance of the MathValueLong class.
    /// </summary>
    public MathValueLong() { }

    /// <summary>
    /// Initializes a new instance of the MathValueLong class with the specified mathematical operation and value.
    /// </summary>
    /// <param name="math">The mathematical operation to associate with the value.</param>
    /// <param name="value">The numeric value to be used with the specified mathematical operation.</param>
    public MathValueLong(MathOption math, long value)
    {
        Math = math;
        Value = value;
    }
}

/// <inheritdoc cref="MathValueDouble"/>
public sealed class MathValueInt
{
    /// <inheritdoc cref="MathValueDouble.Value"/>
    public int Value { get; set; }

    /// <inheritdoc cref="MathValueDouble.Math"/>
    public MathOption Math { get; set; }

    /// <summary>
    /// Initializes a new instance of the MathValueInt class.
    /// </summary>
    public MathValueInt() { }

    /// <summary>
    /// Initializes a new instance of the MathValueInt class with the specified mathematical operation and value.
    /// </summary>
    /// <param name="math">The mathematical operation to associate with the value.</param>
    /// <param name="value">The numeric value to be used with the specified mathematical operation.</param>
    public MathValueInt(MathOption math, int value)
    {
        Math = math;
        Value = value;
    }
}

/// <inheritdoc cref="MathValueDouble"/>
public sealed class MathValueShort
{
    /// <inheritdoc cref="MathValueDouble.Value"/>
    public short Value { get; set; }

    /// <inheritdoc cref="MathValueDouble.Math"/>
    public MathOption Math { get; set; }

    /// <summary>
    /// Initializes a new instance of the MathValueShort class.
    /// </summary>
    public MathValueShort() { }

    /// <summary>
    /// Initializes a new instance of the MathValueShort class with the specified mathematical operation and value.
    /// </summary>
    /// <param name="math">The mathematical operation to associate with the value.</param>
    /// <param name="value">The numeric value to be used with the specified mathematical operation.</param>
    public MathValueShort(MathOption math, short value)
    {
        Math = math;
        Value = value;
    }
}

/// <inheritdoc cref="MathValueDouble"/>
public sealed class MathValueByte
{
    /// <inheritdoc cref="MathValueDouble.Value"/>
    public byte Value { get; set; }

    /// <inheritdoc cref="MathValueDouble.Math"/>
    public MathOption Math { get; set; }

    /// <summary>
    /// Initializes a new instance of the MathValueByte class.
    /// </summary>
    public MathValueByte() { }

    /// <summary>
    /// Initializes a new instance of the MathValueByte class with the specified mathematical operation and value.
    /// </summary>
    /// <param name="math">The mathematical operation to associate with the value.</param>
    /// <param name="value">The numeric value to be used with the specified mathematical operation.</param>
    public MathValueByte(MathOption math, byte value)
    {
        Math = math;
        Value = value;
    }
}