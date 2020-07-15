namespace Linkar
{
    /// <summary>
    /// Object that works as an argument in Read function and defines the function options.
    /// </summary>
    public class ReadOptions
    {
        private CommonOptions CommonOptions;

        /// <summary>
        /// Initializes a new instance of the ReadOptions class
        /// </summary>
        public ReadOptions() : this(false)
        { }

        /// <summary>
        /// Initializes a new instance of the ReadOptions class
        /// </summary>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="conversion">Execute the defined conversions in the dictionaries before returning.</param>
        /// <param name="formatSpec">Execute the defined formats in the dictionaries before returning.</param>
        /// <param name="originalRecords">Return a copy of the records in MV format.</param>
        public ReadOptions(bool calculated, bool conversion = false, bool formatSpec = false, bool originalRecords = false)
        {
            this.CommonOptions = new CommonOptions(calculated, conversion, formatSpec, originalRecords);
        }

        /// <summary>
        /// Composes the Read options string in the way that LinkarSERVER can manage it.
        /// </summary>
        /// <returns>The string ready to be manage by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = this.CommonOptions.ToString();

            return str;
        }
    }
}
