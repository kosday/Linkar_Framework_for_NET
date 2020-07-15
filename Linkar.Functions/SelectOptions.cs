namespace Linkar
{
    /// <summary>
    /// Object that works as an argument in Select function and defines the function options.
    /// </summary>
    public class SelectOptions
    {
        private bool _OnlyRecordId;
        private bool _Pagination;
        private int _Pagination_RegPage;
        private int _Pagination_NumPage;

        private CommonOptions _CommonOptions;

        /// <summary>
        /// Initializes a new instance of the SelectOptions class.
        /// </summary>
        public SelectOptions() : this(false)
        { }

        /// <summary>
        /// Initializes a new instance of the SelectOptions class.
        /// </summary>
        /// <param name="onlyRecordId">Returns just the selected records codes.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="conversion">Execute the defined conversions in the dictionaries before returning.</param>
        /// <param name="formatSpec">Execute the defined formats in the dictionaries before returning.</param>
        /// <param name="originalRecords">Return a copy of the records in MV format.</param>
        public SelectOptions(bool onlyRecordId, bool pagination = false, int regPage = 10, int numPage = 1, bool calculated = false,
            bool conversion = false, bool formatSpec = false, bool originalRecords = false)
        {
            this._OnlyRecordId = onlyRecordId;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
            this._CommonOptions = new CommonOptions(calculated, conversion, formatSpec, originalRecords);
        }

        /// <summary>
        /// Composes the Select options string in the way that LinkarSERVER can manage it.
        /// </summary>
        /// <returns>The string ready to be manage by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (this._Pagination ? "1" : "0") + DBMV_Mark.VM_str + this._Pagination_RegPage + DBMV_Mark.VM_str + this._Pagination_NumPage + DBMV_Mark.AM_str +
                (this._OnlyRecordId ? "1" : "0") + DBMV_Mark.AM +
                this._CommonOptions.ToString();
            return str;
        }
    }
}
