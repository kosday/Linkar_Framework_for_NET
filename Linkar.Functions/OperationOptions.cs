
using System;
using System.Runtime.InteropServices;

namespace Linkar
{

    /// <summary>
    /// It contains the options to perform queries with the GetTable function, using the different types of schemas.
    /// </summary>
    public class OperationOptions
    {
        private SchemaType.TYPE _SchemaType;
        private RowHeaders.TYPE _RowHeaders;
        private bool _SqlMode;
        private bool _RowProperties;
        private bool _OnlyVisibles;
        private bool _UsePropertyNames;
        private bool _RepeatValues;
        private bool _ApplyConversion;
        private bool _ApplyFormat;
        private bool _Calculated;
        private bool _Pagination;
        private int _Pagination_RegPage;
        private int _Pagination_NumPage;

        /// <summary>
        /// Initializes a new instance of the TableOptions class.
        /// The object is created with the default values for queries with LKSCHEMA type schemas. 
        /// </summary>
        public OperationOptions() : this(RowHeaders.TYPE.MAINLABEL, false, false, false, false, false, false, false)
        { }

        /// <summary>
        /// Initializes a new instance of the TableOptions class.
        /// This constructor will be used when you want to obtain queries of the LKSCHEMAS schema type.It is allowed to specify options for creating queries of LKSCHEMA type schemas. 
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="rowProperties">First row contains property names.</param>
        /// <param name="onlyVisibles">Use only Visible Schemas and Properties.</param>
        /// <param name="usePropertyNames">Use Properties and Table names.</param>
        /// <param name="repeatValues">Repeat common atributes in MV and SV groups.</param>
        /// <param name="applyConversion">Execute Conversions: With Dictionaries, conversion defined in the dictionary. With Schema conversions defined in Linkar Schemas.</param>
        /// <param name="applyFormat">Execute Formats. With Dictionaries, formats defined in the dictionary. With Schemas formats defined in Linkar Schemas.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public OperationOptions(RowHeaders.TYPE rowHeaders, bool rowProperties, bool onlyVisibles, bool usePropertyNames,
            bool repeatValues, bool applyConversion, bool applyFormat, bool calculated,
            bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // LKSCHEMAS MODE
            this._SchemaType = SchemaType.TYPE.LKSCHEMA;
            this._SqlMode = false;
            this._RowHeaders = rowHeaders;
            this._RowProperties = rowProperties;
            this._OnlyVisibles = onlyVisibles;
            this._UsePropertyNames = usePropertyNames;
            this._RepeatValues = repeatValues;
            this._ApplyConversion = applyConversion;
            this._ApplyFormat = applyFormat;
            this._Calculated = calculated;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Initializes a new instance of the TableOptions class.
        /// This constructor will be used when you want to perform queries of the SQLMODE type schemas.It is allowed to specify options for creating queries of SQLMODE type schemas.
        /// </summary>
        /// <param name="onlyVisibles">Use only Visible Schemas and Properties.</param>
        /// <param name="applyConversion">Execute Conversions: With Dictionaries, conversion defined in the dictionary. With Schema conversions defined in Linkar Schemas.</param>
        /// <param name="applyFormat">Execute Formats. With Dictionaries, formats defined in the dictionary. With Schemas formats defined in Linkar Schemas.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public OperationOptions(bool onlyVisibles, bool applyConversion, bool applyFormat, bool calculated,
            bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // SQL MODE
            this._SchemaType = SchemaType.TYPE.LKSCHEMA;
            this._SqlMode = true;
            this._RowHeaders = RowHeaders.TYPE.NONE;
            this._RowProperties = true;
            this._OnlyVisibles = onlyVisibles;
            this._UsePropertyNames = true;
            this._RepeatValues = true;
            this._ApplyConversion = applyConversion;
            this._ApplyFormat = applyFormat;
            this._Calculated = calculated;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Initializes a new instance of the TableOptions class.
        /// This constructor will be used when you want to perform queries of the DICTIONARIES type schemas.It is allowed to specify queries creation options of DICTIONARIES type schemas.
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="repeatValues">Repeat common atributes in MV and SV groups.</param>
        /// <param name="applyConversion">Execute Conversions: With Dictionaries, conversion defined in the dictionary. With Schema conversions defined in Linkar Schemas.</param>
        /// <param name="applyFormat">Execute Formats. With Dictionaries, formats defined in the dictionary. With Schemas formats defined in Linkar Schemas.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public OperationOptions(RowHeaders.TYPE rowHeaders, bool repeatValues, bool applyConversion, bool applyFormat, bool calculated,
            bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // DICTIONARIES MODE
            this._SchemaType = SchemaType.TYPE.DICTIONARY;
            this._SqlMode = false;
            this._RowHeaders = rowHeaders;
            this._RowProperties = false;
            this._OnlyVisibles = false;
            this._UsePropertyNames = false;
            this._RepeatValues = repeatValues;
            this._ApplyConversion = applyConversion;
            this._ApplyFormat = applyFormat;
            this._Calculated = calculated;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// nitializes a new instance of the TableOptions class.
        /// This constructor will be used when you want to perform queries without schema information.It is allowed to specify queries creation options without any specific type of schemas.
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="repeatValues">Repeat common atributes in MV and SV groups.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public OperationOptions(RowHeaders.TYPE rowHeaders, bool repeatValues,
            bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // NONE MODE
            this._SchemaType = SchemaType.TYPE.NONE;
            this._SqlMode = false;
            this._RowHeaders = rowHeaders;
            this._RowProperties = false;
            this._OnlyVisibles = false;
            this._UsePropertyNames = false;
            this._RepeatValues = repeatValues;
            this._ApplyConversion = false;
            this._ApplyFormat = false;
            this._Calculated = false;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Composes the GetTable options string in the way that LinkarSERVER can manage it.
        /// </summary>
        /// <returns>The string ready to be manage by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (int)this._SchemaType + DBMV_Mark.AM_str +
                (this._SqlMode ? "1" : "0") + DBMV_Mark.AM_str;
            if (this._SchemaType == SchemaType.TYPE.LKSCHEMA && this._SqlMode)
            {
                str += "1" + DBMV_Mark.AM_str +
                    "1" + DBMV_Mark.AM_str +
                    (this._OnlyVisibles ? "1" : "0") + DBMV_Mark.AM_str +
                    "3" + DBMV_Mark.AM_str +
                    "1" + DBMV_Mark.AM_str +
                    (this._ApplyConversion ? "1" : "0") + DBMV_Mark.AM_str +
                    (this._ApplyFormat ? "1" : "0") + DBMV_Mark.AM_str +
                    (this._Calculated ? "1" : "0") + DBMV_Mark.AM_str;
            }
            else if (this._SchemaType == SchemaType.TYPE.DICTIONARY)
            {
                str += "0" + DBMV_Mark.AM_str +
                    "0" + DBMV_Mark.AM_str +
                    "0" + DBMV_Mark.AM_str +
                    (int)this._RowHeaders + DBMV_Mark.AM_str +
                    (this._RepeatValues ? "1" : "0") + DBMV_Mark.AM_str +
                    (this._ApplyConversion ? "1" : "0") + DBMV_Mark.AM_str +
                    (this._ApplyFormat ? "1" : "0") + DBMV_Mark.AM_str +
                    (this._Calculated ? "1" : "0") + DBMV_Mark.AM_str;
            }
            else if (this._SchemaType == SchemaType.TYPE.NONE)
            {
                str += "0" + DBMV_Mark.AM_str +
                    "0" + DBMV_Mark.AM_str +
                    "0" + DBMV_Mark.AM_str +
                    (int)this._RowHeaders + DBMV_Mark.AM_str +
                    (this._RepeatValues ? "1" : "0") + DBMV_Mark.AM_str +
                    "0" + DBMV_Mark.AM_str +
                    "0" + DBMV_Mark.AM_str +
                    "0" + DBMV_Mark.AM_str;
            }
            else
            {
                str += (this._UsePropertyNames ? "1" : "0") + DBMV_Mark.AM_str +
                 (this._RowProperties ? "1" : "0") + DBMV_Mark.AM_str +
                 (this._OnlyVisibles ? "1" : "0") + DBMV_Mark.AM_str +
                 (int)this._RowHeaders + DBMV_Mark.AM_str +
                 (this._RepeatValues ? "1" : "0") + DBMV_Mark.AM_str +
                 (this._ApplyConversion ? "1" : "0") + DBMV_Mark.AM_str +
                 (this._ApplyFormat ? "1" : "0") + DBMV_Mark.AM_str +
                 (this._Calculated ? "1" : "0") + DBMV_Mark.AM_str;
            }

            str += (this._Pagination ? "1" : "0") + DBMV_Mark.VM_str +
                this._Pagination_RegPage.ToString() + DBMV_Mark.VM_str +
                this._Pagination_NumPage.ToString();

            return str;
        }
    }
}
