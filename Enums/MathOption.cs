namespace LabApiExtensions.Enums;

public enum MathOption
{
    /// <summary>
    /// No Math Option, returns with InValue.
    /// </summary>
    None,
    /// <summary>
    /// Returns with MyValue.
    /// </summary>
    Set,
    /// <summary>
    /// Add InValue and MyValue together.
    /// </summary>
    Add,
    /// <summary>
    /// Subtract InValue with MyValue.
    /// </summary>
    Subtract,
    /// <summary>
    /// Subtract InValue with MyValue. (InValue - MyValue)
    /// </summary>
    Multiply,
    /// <summary>
    /// Divide InValue with MyValue. (InValue / MyValue)
    /// </summary>
    Divide,
    /// <summary>
    /// Modulus InValue with MyValue. (InValue % MyValue)
    /// </summary>
    Modulus,
    /// <summary>
    /// Subtract MyValue with InValue. (MyValue - InValue)
    /// </summary>
    Subtract_MyWithIn,
    /// <summary>
    /// Divide MyValue with InValue. (MyValue / InValue)
    /// </summary>
    Divide_MyWithIn,
    /// <summary>
    /// Modulus MyValue with InValue. (MyValue % InValue)
    /// </summary>
    Modulus_MyWithIn,
}