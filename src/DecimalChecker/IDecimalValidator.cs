
namespace GrimPop.DecimalChecker
{
    /// <summary>
    /// Validates that a decimal generated using the System.Decimal struct will store a SqlServer decimal field of a given Precision and Scale
    /// </summary>
    public interface IDecimalValidator
    {
        /// <summary>
        /// Precision to Validate against
        /// </summary>
        int TargetPrecision { get; set; }

        /// <summary>
        /// Scale to validate against
        /// </summary>
        int TargetScale { get; set; }

        /// <summary>
        /// If the scale is unable to store the value - the strategy used to round the input being validated
        /// </summary>
        MidpointRounding RoundingStrategy { get; set; }

        /// <summary>
        /// Should the Validator throw an error on validation failure.
        ///
        /// If true <see cref="DecimalValidationException"/> is raised on Validation failure
        /// </summary>
        bool ThrowErrorOnValidationFail { get; set; }

        /// <summary>
        /// Validate an input against the <see cref="TargetPrecision"/> and <see cref="TargetScale"/> specified.
        ///
        /// If successful the validated decimal is returned. This may be rounded using the rounding strategy <see cref="RoundingStrategy"/> to fit in the desired scale
        /// 
        /// If <see cref="ThrowErrorOnValidationFail"/> is set to true, will throw an error on failure. Otherwise a null value will be returned.
        /// </summary>
        /// <param name="input">decimal number to validate against Precision and Scale</param>
        /// <returns>A decimal value that will store in a sql decimal field with the given precision and scale, <see langword="null"/>otherwise.  </returns>
        decimal? Validate(decimal input);
    }
}