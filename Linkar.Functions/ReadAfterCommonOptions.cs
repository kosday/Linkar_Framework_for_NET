namespace Linkar
{
    /// <summary>
    /// Auxiliary class with the ReadAfters options for UpdateOptions and NewOptions classes
    /// </summary>
    public class ReadAfterCommonOptions : CommonOptions
    {
        private bool ReadAfter;

        /// <summary>
        /// Initializes a new instance of the ReadAfterCommonOptions class.
        /// </summary>
        public ReadAfterCommonOptions() : this(false)
        { }

        /// <summary>
        /// Initializes a new instance of the ReadAfterCommonOptions class.
        /// </summary>
        /// <param name="readAfter">Reads the record again and returns it after the update or new. Calculated, dictionaries, conversion, formatSpec and originalRecords will only make effect if this option is true.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="conversion">Execute the defined conversions in the dictionaries before returning.</param>
        /// <param name="formatSpec">Execute the defined formats in the dictionaries before returning.</param>
        /// <param name="originalRecords">Return a copy of the records in MV format.</param>
        public ReadAfterCommonOptions(bool readAfter, bool calculated = false, bool conversion = false, bool formatSpec = false, bool originalRecords = false)
            : base(calculated, conversion, formatSpec, originalRecords)
        {
            this.ReadAfter = readAfter;
        }

        /// <summary>
        /// Composes the ReadAfterCommonOptions options string in the way that need it by UpdateOptions and NewOptions classes.
        /// </summary>
        /// <returns>The string ready to be manage by UpdateOptions and NewOptions classes</returns>
        public new string ToString()
        {
            string str = (this.ReadAfter ? "1" : "0") + DBMV_Mark.AM_str + base.ToString();
            return str;
        }
    }
}
