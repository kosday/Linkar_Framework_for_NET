namespace Linkar
{
    /// <summary>
    /// Auxiliary class with the common options for ReadOptions, SelectOptions and ReadAfterCommonOptions classes
    /// </summary>
    public class CommonOptions
    {
        private bool Calculated;
        private bool Conversion;
        private bool FormatSpec;
        private bool OriginalRecords;

        /// <summary>
        /// Initializes a new instance of the CommonOptions class.
        /// </summary>
        public CommonOptions() : this(false)
        { }

        /// <summary>
        /// Initializes a new instance of the CommonOptions class.
        /// </summary>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="conversion">Execute the defined conversions in the dictionaries before returning.</param>
        /// <param name="formatSpec">Execute the defined formats in the dictionaries before returning.</param>
        /// <param name="originalRecords">Return a copy of the records in MV format.</param>
        public CommonOptions(bool calculated, bool conversion = false, bool formatSpec = false, bool originalRecords = false)
        {
            this.Calculated = calculated;
            this.Conversion = conversion;
            this.FormatSpec = formatSpec;
            this.OriginalRecords = originalRecords;
        }

        /// <summary>
        /// Composes the CommonOptions options string in the way that need it by ReadOptions, SelectOptions and ReadAfterCommonOptions classes.
        /// </summary>
        /// <returns>The string ready to be manage by ReadOptions, SelectOptions and ReadAfterCommonOptions classes</returns>
        public override string ToString()
        {
            string str = (this.Calculated ? "1" : "0") + DBMV_Mark.AM_str +
                /* RESERVED */ DBMV_Mark.AM_str +
                (this.Conversion ? "1" : "0") + DBMV_Mark.AM_str +
                (this.FormatSpec ? "1" : "0") + DBMV_Mark.AM_str +
                (this.OriginalRecords ? "1" : "0");

            return str;
        }
    }
}
