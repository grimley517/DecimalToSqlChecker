namespace DecimalChecker
{
    public interface IDecimalChecker
    {

        int Scale { get; init; }
        int Precision { get; init; }

        /// <summary>
        /// Gets the precision of a decimal number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        int GetPrecision(decimal input);

        /// <summary>
        /// Gets the scale of a decimal number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        byte GetScale(decimal input);

        /// <summary>
        /// Checks compatibility with a sql Server decimal data type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        bool IsCompatible(decimal input);
    }
}