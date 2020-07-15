namespace Linkar.LkData
{
    /// <summary>
    /// Class to management the result of the operations Format.
    /// </summary>
    public class LkDataFormat : LkData
    {
        public string Format { get; }

        /// <summary>
        /// Initializes a new instance of the LkDataCRUD class.
        /// </summary>
        /// <param name="formatResult">The string result of the Format operation execution.</param>
        public LkDataFormat(string formatResult) : base(formatResult)
        {
            this.Format = StringFunctions.ExtractFormat(formatResult);
        }
    }
}
