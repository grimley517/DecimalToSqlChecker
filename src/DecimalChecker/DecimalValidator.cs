using System.Text;
using DecimalChecker;

namespace Grimpop.DecimalChecker;

public class DecimalValidator{
    public int TargetPrecision { get; set; }
    public int TargetScale {get; set;}
    public MidpointRounding RoundingStrategy {get; set;}
    public bool ThrowErrorOnValidationFail { get; set; }

    public DecimalValidator()
    {
        RoundingStrategy = MidpointRounding.AwayFromZero;
    }
    public DecimalValidator(
        int targetPrecision,
        int targetScale,
        MidpointRounding roundingStrategy = MidpointRounding.AwayFromZero,
        bool throwErrorOnValidationFail = false
        )
    {
        TargetPrecision = targetPrecision;
        TargetScale = targetScale;
        RoundingStrategy = roundingStrategy;

    }

    public bool Validate(decimal input)
    {
        var scale = input.GetScale();
        if (scale > TargetScale)
        {
            input = decimal.Round(input, TargetScale, RoundingStrategy);
        }
        var precision = input.GetPrecision();
        if (precision > TargetPrecision)
        {
            if (ThrowErrorOnValidationFail)
            {
                throw new DecimalValidationException(input);
            }
            return false;
        }
        return true;
    }

}
