namespace Linkar.LkData
{
    /// <summary>
    /// Class to management the result of the operations LkSchemas and LkProperties.
    /// </summary>
    public class LkDataSchProp : LkData
    {
        public string[] RowProperties { get; }
        public string[] RowHeaders { get; }

        /// <summary>
        /// Initializes a new instance of the LkDataSchProp class.
        /// </summary>
        /// <param name="lkSchemasResult">The string result of the Lkchemas or LkProperties operation execution.</param>
        public LkDataSchProp(string lkSchemasResult) : base(lkSchemasResult)
        {
            this.RowProperties = StringFunctions.ExtractRowProperties(lkSchemasResult);
            this.RowHeaders = StringFunctions.ExtractRowHeaders(lkSchemasResult);
        }
    }
}
