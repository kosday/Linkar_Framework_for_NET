namespace Linkar
{
    /// <summary>
    /// Object that works as an argument in New function and defines the function options.
    /// </summary>
    public class NewOptions
    {
        private ReadAfterCommonOptions _ReadAfterCommonOptions;
        private RecordIdType RecordIdType;

        /// <summary>
        /// Initializes a new instance of the NewOptions class.
        /// </summary>
        public NewOptions() : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the NewOptions class.
        /// </summary>
        /// <param name="recordIdType">Specify the different techniques for generating codes. Mandatory if no registration codes are indicated in the New functions.</param>
        /// <param name="readAfter">Reads the record again and returns it after the update. Calculated, dictionaries, conversion, formatSpec and originalRecords will only make effect if this option is true.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="conversion">Execute the defined conversions in the dictionaries before returning.</param>
        /// <param name="formatSpec">Execute the defined formats in the dictionaries before returning.</param>
        /// <param name="originalRecords">Return a copy of the records in MV format.</param>
        public NewOptions(RecordIdType recordIdType, bool readAfter = false, bool calculated = false, bool conversion = false, bool formatSpec = false, bool originalRecords = false)
        {
            if (recordIdType == null)
                this.RecordIdType = new RecordIdType();
            else
                this.RecordIdType = recordIdType;

            if (readAfter)
                this._ReadAfterCommonOptions = new ReadAfterCommonOptions(readAfter, calculated, conversion, formatSpec, originalRecords);
            else
                this._ReadAfterCommonOptions = new ReadAfterCommonOptions(readAfter);
        }

        /// <summary>
        /// Composes the New options string in the way that LinkarSERVER can manage it.
        /// </summary>
        /// <returns>The string ready to be manage by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = this.RecordIdType.ToString() + DBMV_Mark.AM_str +
                this._ReadAfterCommonOptions.ToString();

            return str;
        }
    }
}
