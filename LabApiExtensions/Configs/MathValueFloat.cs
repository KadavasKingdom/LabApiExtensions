using LabApiExtensions.Enums;

namespace LabApiExtensions.Configs;

/// <summary>
/// Option to specify math operation and value for it.
/// </summary>
public sealed class MathValueFloat
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MathValueFloat"/> class.
    /// </summary>
    public MathValueFloat()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MathValueFloat"/> class with the specified mathematical operation and value.
    /// </summary>
    /// <param name="math">The mathematical operation to associate with the value.</param>
    /// <param name="value">The numeric value to be used with the specified mathematical operation.</param>
    public MathValueFloat(MathOption math, float value)
    {
        Math = math;
        Value = value;
    }

    /// <summary>
    /// Gets or sets the value to apply with the math operation.
    /// </summary>
    public float Value { get; set; }

    /// <summary>
    /// Gets or sets the mathematical options to use for calculations.
    /// </summary>
    public MathOption Math { get; set; }
}