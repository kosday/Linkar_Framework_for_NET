
using System;
using System.Runtime.InteropServices;

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

    /// <summary>
    /// Object that works as an argument in NewOptions function and defines the techniques for generating codes.
    /// </summary>
    public class RecordIdType
    {
        private bool _ActiveTypeLinkar;
        private bool _ActiveTypeRandom;
        private bool _ActiveTypeCustom;

        private string _Prefix;
        private string _Separator;
        private string _FormatSpec;

        private bool _Numeric;
        private int _Length;

        /// <summary>
        /// No code generation technique will be used. The codes must be supplied in the New operations.
        /// </summary>
        public RecordIdType()
        {
            this._ActiveTypeLinkar = false;
            this._ActiveTypeRandom = false;
            this._ActiveTypeCustom = false;
        }

        /// <summary>
        /// Constructor accepts options for generating Linkar type codes.
        /// </summary>
        /// <param name="prefix">Adding a prefix to the code.</param>
        /// <param name="separator">The separator between the prefix and the code. The allowed separators list is: ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~</param>
        /// <param name="formatSpec">The code format, under the Database syntax.</param>
        public RecordIdType(string prefix, string separator, string formatSpec)
        {
            this._ActiveTypeLinkar = true;
            this._ActiveTypeRandom = false;
            this._ActiveTypeCustom = false;

            this._Prefix = prefix;
            this._Separator = separator;
            this._FormatSpec = formatSpec;
        }

        /// <summary>
        /// Constructor accepts options for generating Random type codes.
        /// </summary>
        /// <param name="numeric">Indicates if the code must be numeric.</param>
        /// <param name="length">Length of the code to create. It must be bigger than 0.</param>
        public RecordIdType(bool numeric, int length)
        {
            this._ActiveTypeLinkar = false;
            this._ActiveTypeRandom = true;
            this._ActiveTypeCustom = false;

            this._Numeric = numeric;
            this._Length = length;
        }

        /// <summary>
        /// Constructor accepts options for generating Custom type codes.
        /// </summary>
        /// <param name="custom">It must have the value "true" so that the generation of personalized codes through the subroutine of the Database SUB.LK.MAIN.RECOVERRECORDID.CUSTOM is used. If the value is "false", no code generation technique will be used. The codes must be supplied in the New operations.</param>
        public RecordIdType(bool custom)
        {
            this._ActiveTypeLinkar = false;
            this._ActiveTypeRandom = false;
            this._ActiveTypeCustom = custom;
        }

        /// <summary>
        /// Composes the RecordIdType options string in the way that LinkarSERVER can manage it.
        /// </summary>
        /// <returns>The string ready to be manage by LinkarSERVER.</returns>
        public override string ToString()
        {
            string opLinkar;
            if (this._ActiveTypeLinkar)
                opLinkar = "1" + DBMV_Mark.VM_str + this._Prefix + DBMV_Mark.VM_str + this._Separator + DBMV_Mark.VM_str + this._FormatSpec;
            else
                opLinkar = "0" + DBMV_Mark.VM_str + "" + DBMV_Mark.VM_str + "" + DBMV_Mark.VM_str + "";

            string opRamdom;
            if (this._ActiveTypeRandom)
                opRamdom = "1" + DBMV_Mark.VM_str + (this._Numeric ? "1" : "0") + DBMV_Mark.VM_str + this._Length;
            else
                opRamdom = "0" + DBMV_Mark.VM_str + "" + DBMV_Mark.VM_str + "";

            string str = opLinkar + DBMV_Mark.AM_str +
                (this._ActiveTypeCustom ? "1" : "0") + DBMV_Mark.AM_str +
                opRamdom;

            return str;
        }
    }

    /// <summary>
    /// Object that works as an argument in Delete function and defines the function options.
    /// </summary>
    public class DeleteOptions
    {
        private bool _OptimisticLock;
        private RecoverIdType _RecoverIdType;

        /// <summary>
        /// Initializes a new instance of the DeleteOptions class
        /// </summary>
        public DeleteOptions() : this(false)
        { }

        /// <summary>
        /// Initializes a new instance of the DeleteOptions class
        /// </summary>
        /// <param name="optimisticLockControl">In the execution of the Delete function, before updating the record, checks out if the record has not been modified by other user.</param>
        /// <param name="recoverIdType">Specifies the different recovery techniques of deleted codes.</param>
        public DeleteOptions(bool optimisticLockControl, RecoverIdType recoverIdType = null)
        {
            this._OptimisticLock = optimisticLockControl;
            if (recoverIdType == null)
                this._RecoverIdType = new RecoverIdType();
            else
                this._RecoverIdType = recoverIdType;
        }

        /// <summary>
        /// Composes the Delete options string in the way that LinkarSERVER can manage it.
        /// </summary>
        /// <returns>The string ready to be manage by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (this._OptimisticLock ? "1" : "0") + DBMV_Mark.AM_str +
                this._RecoverIdType.ToString();

            return str;
        }
    }

    /// <summary>
    /// Object that works as an argument in DeleteOptions function and defines the techniques for recovering deleted codes.
    /// </summary>
    public class RecoverIdType
    {
        private bool _ActiveTypeLinkar;
        private bool _ActiveTypeCustom;

        private string _Prefix;
        private string _Separator;

        /// <summary>
        /// No code recovery technique will be used.
        /// </summary>
        public RecoverIdType()
        {
            this._ActiveTypeLinkar = false;
            this._ActiveTypeCustom = false;
        }

        /// <summary>
        /// The technique of recovering deleted Linkar type codes will be used.
        /// </summary>
        /// <param name="prefix">Adding a prefix to the code.</param>
        /// <param name="separator">The separator between the prefix and the code. The allowed separators list is: ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~</param>
        public RecoverIdType(string prefix, string separator)
        {
            this._ActiveTypeLinkar = true;
            this._ActiveTypeCustom = false;

            this._Prefix = prefix;
            this._Separator = separator;
        }

        /// <summary>
        /// The technique of recovering deleted Custom type codes will be used.
        /// </summary>
        /// <param name="custom">It must have the value "true" so that the recovery of deleted codes is used through the subroutine of the Database SUB.LK.MAIN.RECOVERRECORDID.CUSTOM. If the value is "false", no technique to recover deleted codes will be used.</param>
        public RecoverIdType(bool custom)
        {
            this._ActiveTypeLinkar = false;
            this._ActiveTypeCustom = custom;
        }

        /// <summary>
        /// Composes the RecoverIdType options string in the way that LinkarSERVER can manage it.
        /// </summary>
        /// <returns>The string ready to be manage by LinkarSERVER.</returns>
        public override string ToString()
        {
            string opLinkar;
            if (this._ActiveTypeLinkar)
                opLinkar = "1" + DBMV_Mark.VM_str + this._Prefix + DBMV_Mark.VM_str + this._Separator;
            else
                opLinkar = "0" + DBMV_Mark.VM_str + "" + DBMV_Mark.VM_str + "";

            string opCustom;
            if (this._ActiveTypeCustom)
                opCustom = "1";
            else
                opCustom = "0";

            string str = opLinkar + DBMV_Mark.AM_str + opCustom;
            return str;
        }
    }

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

    /// <summary>
    /// Contains the options to obtain different types of schemas with the LkSchemas function.
    /// </summary>
    public class LkSchemasOptions
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
        /// Initializes a new instance of the LkSchemasOptions class.
        /// The object is created with the default values for LKSCHEMAS type schemas.
        /// </summary>
        public LkSchemasOptions() : this(RowHeaders.TYPE.MAINLABEL, false, false)
        { }

        /// <summary>
        /// Initializes a new instance of the LkSchemasOptions class.
        /// Constructor of object used to obtain LKSCHEMAS type schemas.
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="rowProperties">First row contains property names.</param>
        /// <param name="onlyVisibles">Use only Visible Schemas and Properties.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public LkSchemasOptions(RowHeaders.TYPE rowHeaders, bool rowProperties, bool onlyVisibles, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // LKSCHEMAS MODE
            this._SchemaType = SchemaType.TYPE.LKSCHEMAS;
            this._SqlMode = false;
            this._RowHeaders = rowHeaders;
            this._RowProperties = rowProperties;
            this._OnlyVisibles = onlyVisibles;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Initializes a new instance of the LkSchemasOptions class.
        /// Constructor of object used to obtain SQLMODE type schemas.Creation options are allowed for SQLMODE type schemas.
        /// </summary>
        /// <param name="onlyVisibles">Use only Visible Schemas and Properties.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public LkSchemasOptions(bool onlyVisibles, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // SQL MODE
            this._SchemaType = SchemaType.TYPE.LKSCHEMAS;
            this._SqlMode = true;
            this._RowHeaders = RowHeaders.TYPE.NONE;
            this._RowProperties = true;
            this._OnlyVisibles = onlyVisibles;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Initializes a new instance of the LkSchemasOptions class.
        /// Constructor of object used to obtain DICTIONARIES type schemas.Creation options are allowed for DICTIONARIES type schemas.
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public LkSchemasOptions(RowHeaders.TYPE rowHeaders, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // DICTIONARIES MODE
            this._SchemaType = SchemaType.TYPE.DICTIONARIES;
            this._SqlMode = false;
            this._RowHeaders = rowHeaders;
            this._RowProperties = true;
            this._OnlyVisibles = true;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Composes the LkSchemas options string in the way that LinkarSERVER can manage it.
        /// </summary>
        /// <returns>The string ready to be manage by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (int)this._SchemaType + DBMV_Mark.AM_str +
                (this._SqlMode ? "1" : "0") + DBMV_Mark.AM_str;
            if (_SchemaType == SchemaType.TYPE.LKSCHEMAS && _SqlMode)
                str += "1" + DBMV_Mark.AM_str;
            else if (_SchemaType == SchemaType.TYPE.DICTIONARIES)
                str += "0" + DBMV_Mark.AM_str;
            else
                str += (this._RowProperties ? "1" : "0") + DBMV_Mark.AM_str;

            if (_SchemaType == SchemaType.TYPE.DICTIONARIES)
                str += "0" + DBMV_Mark.AM_str;
            else
                str += (this._OnlyVisibles ? "1" : "0") + DBMV_Mark.AM_str;

            if (_SchemaType == SchemaType.TYPE.LKSCHEMAS && _SqlMode)
                str += "3" + DBMV_Mark.AM_str;
            else
                str += (int)this._RowHeaders + DBMV_Mark.AM_str;

            str += (this._Pagination ? "1" : "0") + DBMV_Mark.VM_str +
                this._Pagination_RegPage.ToString() + DBMV_Mark.VM_str +
                this._Pagination_NumPage.ToString();

            return str;
        }
    }

    /// <summary>
    /// Contains the options to obtain the list of Properties of the different types of schemas with the LkProperties function.
    /// </summary>
    public class LkPropertiesOptions
    {
        private SchemaType.TYPE _SchemaType;
        private RowHeaders.TYPE _RowHeaders;
        private bool _SqlMode;
        private bool _RowProperties;
        private bool _OnlyVisibles;
        private bool _UsePropertyNames;
        private bool _Pagination;
        private int _Pagination_RegPage;
        private int _Pagination_NumPage;

        /// <summary>
        /// Initializes a new instance of the LkPropertiesOptions class.
        /// The object is created with the default values for list of Schema Properties of LKSCHEMAS type.
        /// </summary>
        public LkPropertiesOptions() : this(RowHeaders.TYPE.MAINLABEL, false, false, false)
        { }

        /// <summary>
        /// Initializes a new instance of the LkPropertiesOptions class.
        /// Constructor of object used to obtain a list of Properties of the LKSCHEMAS schema type.
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="rowProperties">First row contains property names.</param>
        /// <param name="onlyVisibles">Use only Visible Schemas and Properties.</param>
        /// <param name="usePropertyNames">Use Properties and Table names.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public LkPropertiesOptions(RowHeaders.TYPE rowHeaders, bool rowProperties, bool onlyVisibles, bool usePropertyNames, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // LKSCHEMAS MODE
            this._SchemaType = SchemaType.TYPE.LKSCHEMAS;
            this._SqlMode = false;
            this._RowHeaders = rowHeaders;
            this._RowProperties = rowProperties;
            this._OnlyVisibles = onlyVisibles;
            this._UsePropertyNames = usePropertyNames;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Initializes a new instance of the LkPropertiesOptions class.
        /// Constructor of object used to obtain a list of Properties of the SQLMODE schema type.
        /// </summary>
        /// <param name="onlyVisibles">Use only Visible Schemas and Properties.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public LkPropertiesOptions(bool onlyVisibles, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // SQL MODE
            this._SchemaType = SchemaType.TYPE.LKSCHEMAS;
            this._SqlMode = true;
            this._RowHeaders = RowHeaders.TYPE.NONE;
            this._RowProperties = true;
            this._OnlyVisibles = onlyVisibles;
            this._UsePropertyNames = true;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Initializes a new instance of the LkPropertiesOptions class.
        /// Constructor of object used to obtain a list of Properties of the DICTIONARIES schema type.
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public LkPropertiesOptions(RowHeaders.TYPE rowHeaders, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // DICTIONARIES MODE
            this._SchemaType = SchemaType.TYPE.DICTIONARIES;
            this._SqlMode = false;
            this._RowHeaders = rowHeaders;
            this._RowProperties = false;
            this._OnlyVisibles = false;
            this._UsePropertyNames = false;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Composes the LkProperties options string in the way that LinkarSERVER can manage it.
        /// </summary>
        /// <returns>The string ready to be manage by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (int)this._SchemaType + DBMV_Mark.AM_str +
                (this._SqlMode ? "1" : "0") + DBMV_Mark.AM_str;

            if (this._SchemaType == SchemaType.TYPE.LKSCHEMAS && _SqlMode)
                str += "1" + DBMV_Mark.AM_str + "1" + DBMV_Mark.AM_str;
            else if (this._SchemaType == SchemaType.TYPE.DICTIONARIES)
                str += "0" + DBMV_Mark.AM_str + "0" + DBMV_Mark.AM_str;
            else
            {
                str += (this._UsePropertyNames ? "1" : "0") + DBMV_Mark.AM_str +
                    (this._RowProperties ? "1" : "0") + DBMV_Mark.AM_str;
            }

            if (this._SchemaType == SchemaType.TYPE.DICTIONARIES)
                str += "0" + DBMV_Mark.AM_str;
            else
                str += (this._OnlyVisibles ? "1" : "0") + DBMV_Mark.AM_str;

            if (this._SchemaType == SchemaType.TYPE.LKSCHEMAS && _SqlMode)
                str += "3" + DBMV_Mark.AM_str;
            else
                str += (int)this._RowHeaders + DBMV_Mark.AM_str;

            str += (this._Pagination ? "1" : "0") + DBMV_Mark.VM_str +
                this._Pagination_RegPage.ToString() + DBMV_Mark.VM_str +
                this._Pagination_NumPage.ToString();

            return str;
        }
    }

    /// <summary>
    /// It contains the options to perform queries with the GetTable function, using the different types of schemas.
    /// </summary>
    public class TableOptions
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
        /// The object is created with the default values for queries with LKSCHEMAS type schemas.
        /// </summary>
        public TableOptions() : this(RowHeaders.TYPE.MAINLABEL, false, false, false, false, false, false, false)
        { }

        /// <summary>
        /// Initializes a new instance of the TableOptions class.
        /// Constructor of object used to obtain queries of the LKSCHEMAS schema type.
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="rowProperties">First row contains property names.</param>
        /// <param name="onlyVisibles">Use only Visible Schemas and Properties.</param>
        /// <param name="usePropertyNames">Use Properties and Table names.</param>
        /// <param name="repeatValues">Repeat common atributes in MV and SV groups.</param>
        /// <param name="applyConversion">Execute Conversions: With Dictionaries, conversion defined in the dictionary. With Schemas conversions defined in Linkar Schemas.</param>
        /// <param name="applyFormat">Execute Formats. With Dictionaries, formats defined in the dictionary. With Schemas formats defined in Linkar Schemas.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public TableOptions(RowHeaders.TYPE rowHeaders, bool rowProperties, bool onlyVisibles, bool usePropertyNames,
            bool repeatValues, bool applyConversion, bool applyFormat, bool calculated,
            bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // LKSCHEMAS MODE
            this._SchemaType = SchemaType.TYPE.LKSCHEMAS;
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
        /// Constructor of object used to perform queries of the SQLMODE type schemas.
        /// </summary>
        /// <param name="onlyVisibles">Use only Visible Schemas and Properties.</param>
        /// <param name="applyConversion">Execute Conversions: With Dictionaries, conversion defined in the dictionary. With Schemas conversions defined in Linkar Schemas.</param>
        /// <param name="applyFormat">Execute Formats. With Dictionaries, formats defined in the dictionary. With Schemas formats defined in Linkar Schemas.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public TableOptions(bool onlyVisibles, bool applyConversion, bool applyFormat, bool calculated,
            bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // SQL MODE
            this._SchemaType = SchemaType.TYPE.LKSCHEMAS;
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
        /// Constructor of object used to perform queries of the DICTIONARIES type schemas.
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="repeatValues">Repeat common atributes in MV and SV groups.</param>
        /// <param name="applyConversion">Execute Conversions: With Dictionaries, conversion defined in the dictionary. With Schemas conversions defined in Linkar Schemas.</param>
        /// <param name="applyFormat">Execute Formats. With Dictionaries, formats defined in the dictionary. With Schemas formats defined in Linkar Schemas.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public TableOptions(RowHeaders.TYPE rowHeaders, bool repeatValues, bool applyConversion, bool applyFormat, bool calculated,
            bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // DICTIONARIES MODE
            this._SchemaType = SchemaType.TYPE.DICTIONARIES;
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
        /// Initializes a new instance of the TableOptions class.
        /// Constructor of object used to perform queries without schema information.
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="repeatValues">Repeat common atributes in MV and SV groups.</param>
        /// <param name="pagination">Indicates if pagination is being used or not.</param>
        /// <param name="regPage">In case of pagination indicates the number of records by page. It must be bigger than 0.</param>
        /// <param name="numPage">In case of pagination it indicates the page number to obtain. Must be greater than 0.</param>
        public TableOptions(RowHeaders.TYPE rowHeaders, bool repeatValues,
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
            if (this._SchemaType == SchemaType.TYPE.LKSCHEMAS && this._SqlMode)
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
            else if (this._SchemaType == SchemaType.TYPE.DICTIONARIES)
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
