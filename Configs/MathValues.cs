using LabApiExtensions.Enums;

namespace LabApiExtensions.Configs;

public sealed class MathValueFloat
{
    public float Value { get; set; }

    public MathOption Math { get; set; }

    public MathValueFloat() { }

    public MathValueFloat(MathOption math, float value)
    {
        Math = math;
        Value = value;
    }
}

public sealed class MathValueLong
{
    public long Value { get; set; }

    public MathOption Math { get; set; }

    public MathValueLong() { }

    public MathValueLong(MathOption math, long value)
    {
        Math = math;
        Value = value;
    }
}

public sealed class MathValueInt
{
    public int Value { get; set; }

    public MathOption Math { get; set; }

    public MathValueInt() { }

    public MathValueInt(MathOption math, int value)
    {
        Math = math;
        Value = value;
    }
}

public sealed class MathValueShort
{
    public short Value { get; set; }

    public MathOption Math { get; set; }

    public MathValueShort() { }

    public MathValueShort(MathOption math, short value)
    {
        Math = math;
        Value = value;
    }
}

public sealed class MathValueByte
{
    public byte Value { get; set; }

    public MathOption Math { get; set; }

    public MathValueByte() { }

    public MathValueByte(MathOption math, byte value)
    {
        Math = math;
        Value = value;
    }
}