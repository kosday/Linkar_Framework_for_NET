namespace Linkar
{
    /// <summary>
    /// Contains the options to obtain different types of schemas with the LkSchemas function.
    /// </summary>
    public class LkSchemaOptions
    {
        private SchemaType.TYPE _SchemaType;
        private RowHeaders.TYPE _RowHeaders;
        private bool _SqlMode;
        private bool _RowProperties;
        private bool _OnlyVisibles;
        private bool _Pagination;
        private int _Pagination_RegPage;
        private int _Pagination_NumPage;

        /// <summary>
        /// Initializes a new instance of the LkSchemaOptions class.
        /// The object is created with the default values for LKSCHEMA type schemas. 
        /// </summary>
        public LkSchemaOptions() : this(RowHeaders.TYPE.MAINLABEL, false, false)
        { }

        /// <summary>
        /// Initializes a new instance of the LkSchemaOptions class.
        /// This constructor is used to obtain LKSCHEMA type schemas. Creation options are allowed for schemas of type LKSCHEMA. 
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="rowProperties">First row contains property names.</param>
        /// <param name="onlyVisibles">Use only Visible Schemas and Properties.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public LkSchemaOptions(RowHeaders.TYPE rowHeaders, bool rowProperties, bool onlyVisibles, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // LKSCHEMAS MODE
            this._SchemaType = SchemaType.TYPE.LKSCHEMA;
            this._SqlMode = false;
            this._RowHeaders = rowHeaders;
            this._RowProperties = rowProperties;
            this._OnlyVisibles = onlyVisibles;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Initializes a new instance of the LkSchemaOptions class.
        /// This constructor is used to obtain SQLMODE type schemas. Creation options are allowed for SQLMODE type schemas.
        /// </summary>
        /// <param name="onlyVisibles">Use only Visible Schemas and Properties.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public LkSchemaOptions(bool onlyVisibles, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // SQL MODE
            this._SchemaType = SchemaType.TYPE.LKSCHEMA;
            this._SqlMode = true;
            this._RowHeaders = RowHeaders.TYPE.NONE;
            this._RowProperties = true;
            this._OnlyVisibles = onlyVisibles;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Initializes a new instance of the LkSchemaOptions class.
        /// This constructor is used to obtain DICTIONARIES type schemas. Creation options are allowed for DICTIONARIES type schemas.
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public LkSchemaOptions(RowHeaders.TYPE rowHeaders, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // DICTIONARIES MODE
            this._SchemaType = SchemaType.TYPE.DICTIONARY;
            this._SqlMode = false;
            this._RowHeaders = rowHeaders;
            this._RowProperties = true;
            this._OnlyVisibles = true;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Composes the LkSchema options string in the way that LinkarSERVER can manage it.
        /// </summary>
        /// <returns>The string ready to be manage by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (int)this._SchemaType + DBMV_Mark.AM_str +
                (this._SqlMode ? "1" : "0") + DBMV_Mark.AM_str;
            if (_SchemaType == SchemaType.TYPE.LKSCHEMA && _SqlMode)
                str += "1" + DBMV_Mark.AM_str;
            else if (_SchemaType == SchemaType.TYPE.DICTIONARY)
                str += "0" + DBMV_Mark.AM_str;
            else
                str += (this._RowProperties ? "1" : "0") + DBMV_Mark.AM_str;

            if (_SchemaType == SchemaType.TYPE.DICTIONARY)
                str += "0" + DBMV_Mark.AM_str;
            else
                str += (this._OnlyVisibles ? "1" : "0") + DBMV_Mark.AM_str;

            if (_SchemaType == SchemaType.TYPE.LKSCHEMA && _SqlMode)
                str += "3" + DBMV_Mark.AM_str;
            else
                str += (int)this._RowHeaders + DBMV_Mark.AM_str;

            str += (this._Pagination ? "1" : "0") + DBMV_Mark.VM_str +
                this._Pagination_RegPage.ToString() + DBMV_Mark.VM_str +
                this._Pagination_NumPage.ToString();

            return str;
        }
    }
}
