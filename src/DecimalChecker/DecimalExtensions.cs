namespace GrimPop.DecimalChecker;

public static class DecimalExtensions
{
    public static byte GetScale(this decimal input)
    {
        int[] parts = decimal.GetBits(input);
        byte scale = (byte)((parts[3] >> 16) & 0x7F);
        return scale;
    }
    public static int GetPrecision(this decimal input)
    {
        int[] parts = decimal.GetBits(input);
        parts[3] = 0x0;
        decimal newDecimal = new decimal(parts);
        return newDecimal.ToString().Length;
    }
}
