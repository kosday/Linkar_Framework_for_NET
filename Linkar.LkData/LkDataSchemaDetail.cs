namespace Linkar.LkData
{
    /// <summary>
    /// Class to manage the result of LkSchema and LkProperties operations.
    /// </summary>
    public class LkDataSchemaDetail : LkData
    {
        public string[] RowProperties { get; }
        public string[] RowHeaders { get; }

        /// <summary>
        /// Initializes a new instance of the LkDataSchemaDetail class.
        /// </summary>
        /// <param name="lkSchemaResult">The string result of the LkSchema or LkProperties operation execution.</param>
        public LkDataSchemaDetail(string lkSchemaResult) : base(lkSchemaResult)
        {
            this.RowProperties = StringFunctions.ExtractRowProperties(lkSchemaResult);
            this.RowHeaders = StringFunctions.ExtractRowHeaders(lkSchemaResult);
        }
    }
}
