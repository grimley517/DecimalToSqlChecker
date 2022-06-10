namespace GrimPop.DecimalChecker;

///<inheritdoc />
public class DecimalValidator : IDecimalValidator
{
    ///<inheritdoc />
    public int TargetPrecision { get; set; }
    ///<inheritdoc />
    public int TargetScale { get; set; }
    ///<inheritdoc />
    public MidpointRounding RoundingStrategy { get; set; }
    ///<inheritdoc />
    public bool ThrowErrorOnValidationFail { get; set; }

    /// <summary>
    /// Default constructor, Default Precision is 18. Default Precision is 0
    ///
    /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/data-types/decimal-and-numeric-transact-sql?view=sql-server-ver16"/>
    /// </summary>
    public DecimalValidator()
    {
        RoundingStrategy = MidpointRounding.AwayFromZero;
        TargetPrecision = 18;
        TargetScale = 0;
    }

    /// <summary>
    /// Constructor for a decimal validator
    /// </summary>
    /// <param name="targetPrecision">Target precision. Maximum number of digits in a decimal number</param>
    /// <param name="targetScale">Target Scale. Maximum number of digits to the right of a decimal point in a decimal number </param>
    /// <param name="roundingStrategy">Rounding strategy. If decimal does not fit into scale, the number will be rounded to fit.  This determines the rounding strategy used.</param>
    /// <param name="throwErrorOnValidationFail">if true an error will be raised on validation failure.</param>
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
        ThrowErrorOnValidationFail = throwErrorOnValidationFail;
    }

    ///<inheritdoc />
    public decimal? Validate(decimal input)
    {
        var testvar = new decimal(decimal.GetBits(input));
        var scale = testvar.GetScale();
        if (scale > TargetScale)
        {
            testvar = decimal.Round(testvar, TargetScale, RoundingStrategy);
        }
        var precision = testvar.GetPrecision();
        if (precision > TargetPrecision)
        {
            if (ThrowErrorOnValidationFail)
            {
                throw new DecimalValidationException(input);
            }
            return null;
        }
        return testvar;
    }

}
