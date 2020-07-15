namespace Linkar
{
    /// <summary>
    /// Object that works as an argument in Update function and defines the function options.
    /// </summary>
    public class UpdateOptions
    {
        private ReadAfterCommonOptions _ReadAfterCommonOptions;
        private bool OptimisticLock;

        /// <summary>
        /// Initializes a new instance of the UpdateOptions class.
        /// </summary>
        public UpdateOptions() : this(false)
        { }

        /// <summary>
        /// Initializes a new instance of the UpdateOptions class.
        /// </summary>
        /// <param name="optimisticLockControl">if "true", the Update function will check out if the file has not been modified by other user.</param>
        /// <param name="readAfter">Reads the record again and returns it after the update. Calculated, dictionaries, conversion, formatSpec and originalRecords will only make effect if this option is true.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="conversion">Execute the defined conversions in the dictionaries before returning.</param>
        /// <param name="formatSpec">Execute the defined formats in the dictionaries before returning.</param>
        /// <param name="originalRecords">Return a copy of the records in MV format.</param>
        public UpdateOptions(bool optimisticLockControl, bool readAfter = false, bool calculated = false, bool conversion = false, bool formatSpec = false, bool originalRecords = false)
        {
            this.OptimisticLock = optimisticLockControl;

            if (readAfter)
                this._ReadAfterCommonOptions = new ReadAfterCommonOptions(readAfter, calculated, conversion, formatSpec, originalRecords);
            else
                this._ReadAfterCommonOptions = new ReadAfterCommonOptions(readAfter);
        }

        /// <summary>
        /// Composes the Update options string in the way that LinkarSERVER can manage it.
        /// </summary>
        /// <returns>The string ready to be manage by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (this.OptimisticLock ? "1" : "0") + DBMV_Mark.AM_str +
                this._ReadAfterCommonOptions.ToString();

            return str;
        }
    }
}
