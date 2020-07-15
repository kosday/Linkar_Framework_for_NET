namespace Linkar.LkData
{
    /// <summary>
    /// Class to management the result of the operations Conversion.
    /// </summary>
    public class LkDataConversion : LkData
    {
        public string Conversion { get; }

        /// <summary>
        /// Initializes a new instance of the LkDataCRUD class.
        /// </summary>
        /// <param name="conversionResult">The string result of the Conversion operation execution.</param>
        public LkDataConversion(string conversionResult) : base(conversionResult)
        {
            this.Conversion = StringFunctions.ExtractConversion(conversionResult);
        }
    }
}
