
using System;
using System.Runtime.InteropServices;

namespace Linkar
{
    /// <summary>
    /// Auxiliary class with the common options for ReadOptions, SelectOptions and ReadAfterCommonOptions classes
    /// </summary>
    public class CommonOptions
    {
        private bool _Calculated;
        /// <summary>
        /// Returns the resulting values from the calculated dictionaries.
        /// </summary>
        public bool Calculated
        {
            get { return this._Calculated; }
        }

        private bool _Conversion;
        /// <summary>
        /// Executes the defined conversions in the dictionaries before returning.
        /// </summary>
        public bool Conversion
        {
            get { return this._Conversion; }
        }

        private bool _FormatSpec;
        /// <summary>
        /// Executes the defined formats in the dictionaries before returning.
        /// </summary>
        public bool FormatSpec
        {
            get { return this._FormatSpec; }
        }

        private bool _OriginalRecords;
        /// <summary>
        /// Returns a copy of the records in MV format.
        /// </summary>
        public bool OriginalRecords
        {
            get { return this._OriginalRecords; }
        }

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
            this._Calculated = calculated;
            this._Conversion = conversion;
            this._FormatSpec = formatSpec;
            this._OriginalRecords = originalRecords;
        }

        /// <summary>
        /// Composes the CommonOptions options string for use with ReadOptions, SelectOptions and ReadAfterCommonOptions classes.
        /// </summary>
        /// <returns>The string ready to be used by ReadOptions, SelectOptions and ReadAfterCommonOptions classes</returns>
        public override string ToString()
        {
            string str = (this._Calculated ? "1" : "0") + DBMV_Mark.AM_str +
                /* RESERVED */ DBMV_Mark.AM_str +
                (this._Conversion ? "1" : "0") + DBMV_Mark.AM_str +
                (this._FormatSpec ? "1" : "0") + DBMV_Mark.AM_str +
                (this._OriginalRecords ? "1" : "0");

            return str;
        }
    }

    /// <summary>
    /// Auxiliary class with the ReadAfters options for UpdateOptions and NewOptions classes
    /// </summary>
    public class ReadAfterCommonOptions : CommonOptions
    {
        private bool _ReadAfter;

        /// <summary>
        /// Reads the record again and returns it after the update or new. Calculated, dictionaries, conversion, formatSpec and originalRecords will only make effect if this option is true.
        /// </summary>
        public bool ReadAfter
        {
            get { return this._ReadAfter; }
        }

        /// <summary>
        /// Initializes a new instance of the ReadAfterCommonOptions class.
        /// </summary>
        public ReadAfterCommonOptions() : this(false)
        { }

        /// <summary>
        /// Initializes a new instance of the ReadAfterCommonOptions class.
        /// </summary>
        /// <param name="readAfter">Reads the record again and returns it after the update or new. Calculated, dictionaries, conversion, formatSpec and originalRecords will only be applied if this option is true.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="conversion">Execute the defined conversions in the dictionaries before returning.</param>
        /// <param name="formatSpec">Execute the defined formats in the dictionaries before returning.</param>
        /// <param name="originalRecords">Return a copy of the records in MV format.</param>
        public ReadAfterCommonOptions(bool readAfter, bool calculated = false, bool conversion = false, bool formatSpec = false, bool originalRecords = false)
            : base(calculated, conversion, formatSpec, originalRecords)
        {
            this._ReadAfter = readAfter;
        }

        /// <summary>
        /// Composes the ReadAfterCommonOptions options string for use with UpdateOptions and NewOptions classes.
        /// </summary>
        /// <returns>The string ready to be used by UpdateOptions and NewOptions classes</returns>
        public new string ToString()
        {
            string str = (this._ReadAfter ? "1" : "0") + DBMV_Mark.AM_str + base.ToString();
            return str;
        }
    }

    /// <summary>
    /// Object that works as an argument in Read function and defines the function options.
    /// </summary>
    public class ReadOptions
    {
        private CommonOptions _CommonOptions;

        /// <summary>
        /// Returns the resulting values from the calculated dictionaries.
        /// </summary>
        public bool Calculated
        {
            get { return this._CommonOptions.Calculated; }
        }

        /// <summary>
        /// Executes the defined conversions in the dictionaries before returning.
        /// </summary>
        public bool Conversion
        {
            get { return this._CommonOptions.Conversion; }
        }

        /// <summary>
        /// Executes the defined formats in the dictionaries before returning.
        /// </summary>
        public bool FormatSpec
        {
            get { return this._CommonOptions.FormatSpec; }
        }

        /// <summary>
        /// Returns a copy of the records in MV format.
        /// </summary>
        public bool OriginalRecords
        {
            get { return this._CommonOptions.OriginalRecords; }
        }

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
            this._CommonOptions = new CommonOptions(calculated, conversion, formatSpec, originalRecords);
        }

        /// <summary>
        /// Composes the Read options string for processing through LinkarSERVER to the database.
        /// </summary>
        /// <returns>The string ready to be used by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = this._CommonOptions.ToString();

            return str;
        }
    }

    /// <summary>
    /// Object that works as an argument in Update function and defines the function options.
    /// </summary>
    public class UpdateOptions
    {
        private ReadAfterCommonOptions _ReadAfterCommonOptions;
        private bool _OptimisticLock;
        /// <summary>
        /// Checks out if the file has not been modified by other user.
        /// </summary>
        public bool OptimisticLock
        {
            get { return this._OptimisticLock; }
        }

        /// <summary>
        /// Reads the record again and returns it after the update. Calculated, dictionaries, conversion, formatSpec and originalRecords will only make effect if this option is true.
        /// </summary>
        public bool ReadAfter
        {
            get { return this._ReadAfterCommonOptions.ReadAfter; }
        }

        /// <summary>
        /// Returns the resulting values from the calculated dictionaries.
        /// </summary>
        public bool Calculated
        {
            get { return this._ReadAfterCommonOptions.Calculated; }
        }

        /// <summary>
        /// Executes the defined conversions in the dictionaries before returning.
        /// </summary>
        public bool Conversion
        {
            get { return this._ReadAfterCommonOptions.Conversion; }
        }

        /// <summary>
        /// Executes the defined formats in the dictionaries before returning.
        /// </summary>
        public bool FormatSpec
        {
            get { return this._ReadAfterCommonOptions.FormatSpec; }
        }

        /// <summary>
        /// Returns a copy of the records in MV format.
        /// </summary>
        public bool OriginalRecords
        {
            get { return this._ReadAfterCommonOptions.OriginalRecords; }
        }

        /// <summary>
        /// Initializes a new instance of the UpdateOptions class.
        /// </summary>
        public UpdateOptions() : this(false)
        { }

        /// <summary>
        /// Initializes a new instance of the UpdateOptions class.
        /// </summary>
        /// <param name="optimisticLockControl">if "true", the Update function will check out if the file has not been modified by other user.</param>
        /// <param name="readAfter">Reads the record again and returns it after the update. Calculated, dictionaries, conversion, formatSpec and originalRecords will only be applied if this option is true.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="conversion">Execute the defined conversions in the dictionaries before returning.</param>
        /// <param name="formatSpec">Execute the defined formats in the dictionaries before returning.</param>
        /// <param name="originalRecords">Return a copy of the records in MV format.</param>
        public UpdateOptions(bool optimisticLockControl, bool readAfter = false, bool calculated = false, bool conversion = false, bool formatSpec = false, bool originalRecords = false)
        {
            this._OptimisticLock = optimisticLockControl;

            if (readAfter)
                this._ReadAfterCommonOptions = new ReadAfterCommonOptions(readAfter, calculated, conversion, formatSpec, originalRecords);
            else
                this._ReadAfterCommonOptions = new ReadAfterCommonOptions(readAfter);
        }

        /// <summary>
        /// Composes the Update options string for processing through LinkarSERVER to the database.
        /// </summary>
        /// <returns>The string ready to be used by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (this._OptimisticLock ? "1" : "0") + DBMV_Mark.AM_str +
                this._ReadAfterCommonOptions.ToString();

            return str;
        }
    }

    /// <summary>
    /// Object that works as an argument in New function and defines the function options.
    /// </summary>
    public class NewOptions
    {
        private RecordIdType _RecordIdType;

        /// <summary>
        /// Indicates that the Record Id Type Linkar is enabled.
        /// </summary>
        public bool ActiveTypeLinkar
        {
            get { return this._RecordIdType.ActiveTypeLinkar; }
        }

        /// <summary>
        /// Indicates that the Record Id Type Random is enabled.
        /// </summary>
        public bool ActiveTypeRandom
        {
            get { return this._RecordIdType.ActiveTypeRandom; }
        }

        /// <summary>
        /// Indicates that the Record Id Type Custom is enabled.
        /// </summary>
        public bool ActiveTypeCustom
        {
            get { return this._RecordIdType.ActiveTypeCustom; }
        }

        /// <summary>
        /// A prefix to the code
        /// </summary>
        public string Prefix
        {
            get { return this._RecordIdType.Prefix; }
        }

        /// <summary>
        /// The separator between the prefix and the code. The allowed separators list is: ! " # $ % &amp; ' ( ) * + , - . / : ; &lt; = &gt; ? @ [ \ ] ^ _ ` { | } ~
        /// </summary>
        public string Separator
        {
            get { return this._RecordIdType.Separator; }
        }

        /// <summary>
        /// The code format, under the Database syntax.
        /// </summary>
        public string FormatSpec_RecordId
        {
            get { return this._RecordIdType.FormatSpec; }
        }

        /// <summary>
        /// Indicates if the code must be numeric.
        /// </summary>
        public bool Numeric
        {
            get { return this._RecordIdType.Numeric; }
        }

        /// <summary>
        /// Length of the code to create. It must be bigger than 0.
        /// </summary>
        public int Length
        {
            get { return this._RecordIdType.Length; }
        }

        private ReadAfterCommonOptions _ReadAfterCommonOptions;

        /// <summary>
        /// Reads the record again and returns it after the update. Calculated, dictionaries, conversion, formatSpec and originalRecords will only make effect if this option is true.
        /// </summary>
        public bool ReadAfter
        {
            get { return this._ReadAfterCommonOptions.ReadAfter; }
        }

        /// <summary>
        /// Returns the resulting values from the calculated dictionaries.
        /// </summary>
        public bool Calculated
        {
            get { return this._ReadAfterCommonOptions.Calculated; }
        }

        /// <summary>
        /// Executes the defined conversions in the dictionaries before returning.
        /// </summary>
        public bool Conversion
        {
            get { return this._ReadAfterCommonOptions.Conversion; }
        }

        /// <summary>
        /// Executes the defined formats in the dictionaries before returning.
        /// </summary>
        public bool FormatSpec
        {
            get { return this._ReadAfterCommonOptions.FormatSpec; }
        }

        /// <summary>
        /// Returns a copy of the records in MV format.
        /// </summary>
        public bool OriginalRecords
        {
            get { return this._ReadAfterCommonOptions.OriginalRecords; }
        }

        /// <summary>
        /// Initializes a new instance of the NewOptions class.
        /// </summary>
        public NewOptions() : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the NewOptions class.
        /// </summary>
        /// <param name="recordIdType">Specifies the technique for generating item IDs. Mandatory if no registration codes are indicated in the New functions.</param>
        /// <param name="readAfter">Reads the record again and returns it after the update. Calculated, dictionaries, conversion, formatSpec and originalRecords will only be applied if this option is true.</param>
        /// <param name="calculated">Return the resulting values from the calculated dictionaries.</param>
        /// <param name="conversion">Execute the defined conversions in the dictionaries before returning.</param>
        /// <param name="formatSpec">Execute the defined formats in the dictionaries before returning.</param>
        /// <param name="originalRecords">Return a copy of the records in MV format.</param>
        public NewOptions(RecordIdType recordIdType, bool readAfter = false, bool calculated = false, bool conversion = false, bool formatSpec = false, bool originalRecords = false)
        {
            //TODO: TG: Please explain "Mandatory if no registration codes are indicated in the New functions."
            if (recordIdType == null)
                this._RecordIdType = new RecordIdType();
            else
                this._RecordIdType = recordIdType;

            if (readAfter)
                this._ReadAfterCommonOptions = new ReadAfterCommonOptions(readAfter, calculated, conversion, formatSpec, originalRecords);
            else
                this._ReadAfterCommonOptions = new ReadAfterCommonOptions(readAfter);
        }

        /// <summary>
        /// Composes the New options string for processing through LinkarSERVER to the database.
        /// </summary>
        /// <returns>The string ready to be used by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = this._RecordIdType.ToString() + DBMV_Mark.AM_str +
                this._ReadAfterCommonOptions.ToString();

            return str;
        }
    }

    /// <summary>
    /// Object that works as an argument in NewOptions function and defines the technique for generating item IDs.
    /// </summary>
    public class RecordIdType
    {
        private bool _ActiveTypeLinkar;
        /// <summary>
        /// Indicates that the Record Id Type Linkar is enabled.
        /// </summary>
        public bool ActiveTypeLinkar
        {
            get { return this._ActiveTypeLinkar; }
        }

        private bool _ActiveTypeRandom;
        /// <summary>
        /// Indicates that the Record Id Type Random is enabled.
        /// </summary>
        public bool ActiveTypeRandom
        {
            get { return this._ActiveTypeRandom; }
        }

        private bool _ActiveTypeCustom;
        /// <summary>
        /// Indicates that the Record Id Type Custom is enabled.
        /// </summary>
        public bool ActiveTypeCustom
        {
            get { return this._ActiveTypeCustom; }
        }

        private string _Prefix;
        /// <summary>
        /// A prefix to the code
        /// </summary>
        public string Prefix
        {
            get { return this._Prefix; }
        }

        private string _Separator;
        /// <summary>
        /// The separator between the prefix and the code. The allowed separators list is: ! " # $ % &amp; ' ( ) * + , - . / : ; &lt; = &gt; ? @ [ \ ] ^ _ ` { | } ~
        /// </summary>
        public string Separator
        {
            get { return this._Separator; }
        }

        private string _FormatSpec;
        /// <summary>
        /// The code format, under the Database syntax.
        /// </summary>
        public string FormatSpec
        {
            get { return this._FormatSpec; }
        }

        private bool _Numeric;
        /// <summary>
        /// Indicates if the code must be numeric.
        /// </summary>
        public bool Numeric
        {
            get { return this._Numeric; }
        }

        private int _Length;
        /// <summary>
        /// Length of the code to create. It must be bigger than 0.
        /// </summary>
        public int Length
        {
            get { return this._Length; }
        }

        /// <summary>
        /// No item ID generation technique will be used. the item IDs must be supplied in the New operations.
        /// </summary>
        public RecordIdType()
        {
            this._ActiveTypeLinkar = false;
            this._ActiveTypeRandom = false;
            this._ActiveTypeCustom = false;
        }

        /// <summary>
        /// Constructor accepts options for generating Linkar item IDs.
        /// </summary>
        /// <param name="prefix">Adding a prefix to the item ID.</param>
        /// <param name="separator">The separator between the prefix and the ID. Valid delimiters: ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~</param>
        /// <param name="formatSpec">Conversion format for the item ID. Use database-specific syntax.</param>
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
        /// Constructor accepts options for generating Random item IDs.
        /// </summary>
        /// <param name="numeric">Indicates if the item ID must be numeric.</param>
        /// <param name="length">Length of the item ID to create. Must be greater than 0.</param>
        public RecordIdType(bool numeric, int length)
        {
            this._ActiveTypeLinkar = false;
            this._ActiveTypeRandom = true;
            this._ActiveTypeCustom = false;

            this._Numeric = numeric;
            this._Length = length;
        }

        /// <summary>
        /// Constructor accepts options for generating Custom item IDs.
        /// </summary>
        /// <param name="custom">If true, item IDs are generated by SUB.LK.MAIN.RECOVERRECORDID.CUSTOM. If false, no ID generation technique will be used - IDs must be supplied in the New operations.</param>
        public RecordIdType(bool custom)
        {
            this._ActiveTypeLinkar = false;
            this._ActiveTypeRandom = false;
            this._ActiveTypeCustom = custom;
        }

        /// <summary>
        /// Composes the RecordIdType options string for processing through LinkarSERVER to the database.
        /// </summary>
        /// <returns>The string ready to be used by LinkarSERVER.</returns>
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
        /// <summary>
        /// In the execution of the Delete function, before updating the record, checks out if the record has not been modified by other user.
        /// </summary>
        public bool OptimisticLock
        {
            get { return this._OptimisticLock; }
        }

        private RecoverIdType _RecoverIdType;

        /// <summary>
        /// Indicates that the Recover Id Type Linkar is enabled.
        /// </summary>
        public bool ActiveTypeLinkar
        {
            get { return this._RecoverIdType.ActiveTypeLinkar; }
        }

        /// <summary>
        /// Indicates that the Recover Id Type Custom is enabled.
        /// </summary>
        public bool ActiveTypeCustom
        {
            get { return this._RecoverIdType.ActiveTypeCustom; }
        }

        /// <summary>
        /// A prefix to the code.
        /// </summary>
        public string Prefix
        {
            get { return this._RecoverIdType.Prefix; }
        }

        /// <summary>
        /// The separator between the prefix and the code. The allowed separators list is: ! " # $ % &amp; ' ( ) * + , - . / : ; &lt; = &gt; ? @ [ \ ] ^ _ ` { | } ~
        /// </summary>
        public string Separator
        {
            get { return this._RecoverIdType.Separator; }
        }

        /// <summary>
        /// Initializes a new instance of the DeleteOptions class
        /// </summary>
        public DeleteOptions() : this(false)
        { }

        /// <summary>
        /// Initializes a new instance of the DeleteOptions class
        /// </summary>
        /// <param name="optimisticLockControl">In the execution of the Delete function, before updating the record, checks out if the record has not been modified by other user.</param>
        /// <param name="recoverIdType">Specifies the recovery technique for deleted item IDs.</param>
        public DeleteOptions(bool optimisticLockControl, RecoverIdType recoverIdType = null)
        {
            this._OptimisticLock = optimisticLockControl;
            if (recoverIdType == null)
                this._RecoverIdType = new RecoverIdType();
            else
                this._RecoverIdType = recoverIdType;
        }

        /// <summary>
        /// Composes the Delete options string for processing through LinkarSERVER to the database.
        /// </summary>
        /// <returns>The string ready to be used by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (this._OptimisticLock ? "1" : "0") + DBMV_Mark.AM_str +
                this._RecoverIdType.ToString();

            return str;
        }
    }

    /// <summary>
    /// Object that works as an argument in DeleteOptions function and defines the technique for recovering deleted item IDs.
    /// </summary>
    public class RecoverIdType
    {
        private bool _ActiveTypeLinkar;
        /// <summary>
        /// Indicates that the Recover Id Type Linkar is enabled.
        /// </summary>
        public bool ActiveTypeLinkar
        {
            get { return this._ActiveTypeLinkar; }
        }

        private bool _ActiveTypeCustom;
        /// <summary>
        /// Indicates that the Recover Id Type Custom is enabled.
        /// </summary>
        public bool ActiveTypeCustom
        {
            get { return this._ActiveTypeCustom; }
        }

        private string _Prefix;
        /// <summary>
        /// A prefix to the code.
        /// </summary>
        public string Prefix
        {
            get { return this._Prefix; }
        }

        private string _Separator;
        /// <summary>
        /// The separator between the prefix and the code. The allowed separators list is: ! " # $ % &amp; ' ( ) * + , - . / : ; &lt; = &gt; ? @ [ \ ] ^ _ ` { | } ~
        /// </summary>
        public string Separator
        {
            get { return this._Separator; }
        }

        /// <summary>
        /// No id recovery technique will be used.
        /// </summary>
        public RecoverIdType()
        {
            this._ActiveTypeLinkar = false;
            this._ActiveTypeCustom = false;
        }

        /// <summary>
        /// Use this constructor for recovering items ids that used Linkar RecordIdType.
        /// </summary>
        /// <param name="prefix">Adding a prefix to the item ID.</param>
        /// <param name="separator">The separator between the prefix and the ID. Valid delimiters: ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~</param>
        public RecoverIdType(string prefix, string separator)
        {
            //TODO: TG: I don't understand "type codes". Does that mean "record/item IDs"?
            this._ActiveTypeLinkar = true;
            this._ActiveTypeCustom = false;

            this._Prefix = prefix;
            this._Separator = separator;
        }

        /// <summary>
        /// Use this constructor to recovering items ids that used Custom RecordIdType
        /// </summary>
        /// <param name="custom">If true, the recovery of deleted item IDs is handled in SUB.LK.MAIN.RECOVERRECORDID.CUSTOM. If false, no technique to recover deleted item IDs will be used.</param>
        public RecoverIdType(bool custom)
        {
            //TODO: TG: I don't understand "type codes". Does that mean "record/item IDs"?
            this._ActiveTypeLinkar = false;
            this._ActiveTypeCustom = custom;
        }

        /// <summary>
        /// Composes the RecoverIdType options string for processing through LinkarSERVER to the database.
        /// </summary>
        /// <returns>The string ready to be used by LinkarSERVER.</returns>
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
        /// <summary>
        /// Returns just the selected records codes.
        /// </summary>
        public bool OnlyRecordId
        {
            get { return this._OnlyRecordId; }
        }
        private bool _Pagination;
        /// <summary>
        /// Indicates if pagination is being used or not.
        /// </summary>
        public bool Pagination
        {
            get { return this._Pagination; }
        }
        private int _Pagination_RegPage;
        /// <summary>
        /// In case of pagination indicates the number of records by page. It must be bigger than 0.
        /// </summary>
        public int Pagination_RegPage
        {
            get { return this._Pagination_RegPage; }
        }
        private int _Pagination_NumPage;
        /// <summary>
        /// In case of pagination it indicates the page number to obtain. Must be greater than 0.
        /// </summary>
        public int Pagination_NumPage
        {
            get { return this._Pagination_NumPage; }
        }
        private CommonOptions _CommonOptions;

        /// <summary>
        /// Returns the resulting values from the calculated dictionaries.
        /// </summary>
        public bool Calculated
        {
            get { return this._CommonOptions.Calculated; }
        }

        /// <summary>
        /// Executes the defined conversions in the dictionaries before returning.
        /// </summary>
        public bool Conversion
        {
            get { return this._CommonOptions.Conversion; }
        }

        /// <summary>
        /// Executes the defined formats in the dictionaries before returning.
        /// </summary>
        public bool FormatSpec
        {
            get { return this._CommonOptions.FormatSpec; }
        }

        /// <summary>
        /// Returns a copy of the records in MV format.
        /// </summary>
        public bool OriginalRecords
        {
            get { return this._CommonOptions.OriginalRecords; }
        }

        /// <summary>
        /// Initializes a new instance of the SelectOptions class.
        /// </summary>
        public SelectOptions() : this(false)
        { }

        /// <summary>
        /// Initializes a new instance of the SelectOptions class.
        /// </summary>
        /// <param name="onlyRecordId">Returns just the ID(s) of selected record(s).</param>
        /// <param name="pagination">True if pagination is being used.</param>
        /// <param name="regPage">For use with pagination, indicates the number of records by page. Must be greater than 0.</param>
        /// <param name="numPage">For use with pagination, indicates the page number to obtain. Must be greater than 0.</param>
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
        /// Composes the Select options string for processing through LinkarSERVER to the database.
        /// </summary>
        /// <returns>The string ready to be used by LinkarSERVER.</returns>
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
        /// <summary>
        /// Indicates the type of LkSchemas used
        /// </summary>
        public SchemaType.TYPE SchemaType
        {
            get { return this._SchemaType; }
        }

        private RowHeaders.TYPE _RowHeaders;
        /// <summary>
        /// Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).
        /// </summary>
        public RowHeaders.TYPE RowHeaders
        {
            get { return this._RowHeaders; }
        }

        private bool _SqlMode;
        /// <summary>
        /// SQLMODE type schemas
        /// </summary>
        public bool SqlMode
        {
            get { return this._SqlMode; }
        }

        private bool _RowProperties;
        /// <summary>
        /// First row contains property names.
        /// </summary>
        public bool RowProperties
        {
            get { return this._RowProperties; }
        }

        private bool _OnlyVisibles;
        /// <summary>
        /// Use only Visible Schemas and Properties.
        /// </summary>
        public bool OnlyVisibles
        {
            get { return this._OnlyVisibles; }
        }

        private bool _Pagination;
        /// <summary>
        /// Indicates if pagination is being used or not.
        /// </summary>
        public bool Pagination
        {
            get { return this._Pagination; }
        }

        private int _Pagination_RegPage;
        /// <summary>
        /// In case of pagination indicates the number of records by page. It must be bigger than 0.
        /// </summary>
        public int Pagination_RegPage
        {
            get { return this._Pagination_RegPage; }
        }

        private int _Pagination_NumPage;
        /// <summary>
        /// In case of pagination it indicates the page number to obtain. Must be greater than 0.
        /// </summary>
        public int Pagination_NumPage
        {
            get { return this._Pagination_NumPage; }
        }

        /// <summary>
        /// Initializes a new instance of the LkSchemasOptions class.
        /// The object is created with the default values for LKSCHEMAS type schemas.
        /// </summary>
        public LkSchemasOptions() : this(Linkar.RowHeaders.TYPE.MAINLABEL, false, false)
        { }

        /// <summary>
        /// Initializes a new instance of the LkSchemasOptions class.
        /// Constructor of object used to obtain LKSCHEMAS type schemas.
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="rowProperties">First row contains property names.</param>
        /// <param name="onlyVisibles">Use only Visible Schemas and Properties.</param>
        /// <param name="pagination">True if pagination is being used.</param>
        /// <param name="regPage">For use with pagination, indicates the number of records by page. Must be greater than 0.</param>
        /// <param name="numPage">For use with pagination, indicates the page number to obtain. Must be greater than 0.</param>
        public LkSchemasOptions(RowHeaders.TYPE rowHeaders, bool rowProperties, bool onlyVisibles, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // LKSCHEMAS MODE
            this._SchemaType = Linkar.SchemaType.TYPE.LKSCHEMAS;
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
        /// <param name="pagination">True if pagination is being used.</param>
        /// <param name="regPage">For use with pagination, indicates the number of records by page. Must be greater than 0.</param>
        /// <param name="numPage">For use with pagination, indicates the page number to obtain. Must be greater than 0.</param>
        public LkSchemasOptions(bool onlyVisibles, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // SQL MODE
            this._SchemaType = Linkar.SchemaType.TYPE.LKSCHEMAS;
            this._SqlMode = true;
            this._RowHeaders = Linkar.RowHeaders.TYPE.NONE;
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
        /// <param name="pagination">True if pagination is being used.</param>
        /// <param name="regPage">For use with pagination, indicates the number of records by page. Must be greater than 0.</param>
        /// <param name="numPage">For use with pagination, indicates the page number to obtain. Must be greater than 0.</param>
        public LkSchemasOptions(RowHeaders.TYPE rowHeaders, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // DICTIONARIES MODE
            this._SchemaType = Linkar.SchemaType.TYPE.DICTIONARIES;
            this._SqlMode = false;
            this._RowHeaders = rowHeaders;
            this._RowProperties = true;
            this._OnlyVisibles = true;
            this._Pagination = pagination;
            this._Pagination_RegPage = regPage;
            this._Pagination_NumPage = numPage;
        }

        /// <summary>
        /// Composes the LkSchemas options string for processing through LinkarSERVER to the database.
        /// </summary>
        /// <returns>The string ready to be used by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (int)this._SchemaType + DBMV_Mark.AM_str +
                (this._SqlMode ? "1" : "0") + DBMV_Mark.AM_str;
            if (_SchemaType == Linkar.SchemaType.TYPE.LKSCHEMAS && _SqlMode)
                str += "1" + DBMV_Mark.AM_str;
            else if (_SchemaType == Linkar.SchemaType.TYPE.DICTIONARIES)
                str += "0" + DBMV_Mark.AM_str;
            else
                str += (this._RowProperties ? "1" : "0") + DBMV_Mark.AM_str;

            if (_SchemaType == Linkar.SchemaType.TYPE.DICTIONARIES)
                str += "0" + DBMV_Mark.AM_str;
            else
                str += (this._OnlyVisibles ? "1" : "0") + DBMV_Mark.AM_str;

            if (_SchemaType == Linkar.SchemaType.TYPE.LKSCHEMAS && _SqlMode)
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
        /// <summary>
        /// Indicates the type of LkSchemas used
        /// </summary>
        public SchemaType.TYPE SchemaType
        {
            get { return this._SchemaType; }
        }

        private RowHeaders.TYPE _RowHeaders;
        /// <summary>
        /// Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).
        /// </summary>
        public RowHeaders.TYPE RowHeaders
        {
            get { return this._RowHeaders; }
        }

        private bool _SqlMode;
        /// <summary>
        /// SQLMODE type schemas
        /// </summary>
        public bool SqlMode
        {
            get { return this._SqlMode; }
        }

        private bool _RowProperties;
        /// <summary>
        /// First row contains property names.
        /// </summary>
        public bool RowProperties
        {
            get { return this._RowProperties; }
        }

        private bool _OnlyVisibles;
        /// <summary>
        /// Use only Visible Schemas and Properties.
        /// </summary>
        public bool OnlyVisibles
        {
            get { return this._OnlyVisibles; }
        }

        private bool _UsePropertyNames;
        /// <summary>
        /// Use Properties and Table names.
        /// </summary>
        public bool UsePropertiesNames
        {
            get { return this._UsePropertyNames; }
        }

        private bool _Pagination;
        /// <summary>
        /// Indicates if pagination is being used or not.
        /// </summary>
        public bool Pagination
        {
            get { return this._Pagination; }
        }

        private int _Pagination_RegPage;
        /// <summary>
        /// In case of pagination indicates the number of records by page. It must be bigger than 0.
        /// </summary>
        public int Pagination_RegPage
        {
            get { return this._Pagination_RegPage; }
        }

        private int _Pagination_NumPage;
        /// <summary>
        /// In case of pagination it indicates the page number to obtain. Must be greater than 0.
        /// </summary>
        public int Pagination_NumPage
        {
            get { return this._Pagination_NumPage; }
        }

        /// <summary>
        /// Initializes a new instance of the LkPropertiesOptions class.
        /// The object is created with the default values for list of Schema Properties of LKSCHEMAS type.
        /// </summary>
        public LkPropertiesOptions() : this(Linkar.RowHeaders.TYPE.MAINLABEL, false, false, false)
        { }

        /// <summary>
        /// Initializes a new instance of the LkPropertiesOptions class.
        /// Constructor of object used to obtain a list of Properties of the LKSCHEMAS schema type.
        /// </summary>
        /// <param name="rowHeaders">Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).</param>
        /// <param name="rowProperties">First row contains property names.</param>
        /// <param name="onlyVisibles">Use only Visible Schemas and Properties.</param>
        /// <param name="usePropertyNames">Use Properties and Table names.</param>
        /// <param name="pagination">True if pagination is being used.</param>
        /// <param name="regPage">For use with pagination, indicates the number of records by page. Must be greater than 0.</param>
        /// <param name="numPage">For use with pagination, indicates the page number to obtain. Must be greater than 0.</param>
        public LkPropertiesOptions(RowHeaders.TYPE rowHeaders, bool rowProperties, bool onlyVisibles, bool usePropertyNames, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // LKSCHEMAS MODE
            this._SchemaType = Linkar.SchemaType.TYPE.LKSCHEMAS;
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
        /// <param name="pagination">True if pagination is being used.</param>
        /// <param name="regPage">For use with pagination, indicates the number of records by page. Must be greater than 0.</param>
        /// <param name="numPage">For use with pagination, indicates the page number to obtain. Must be greater than 0.</param>
        public LkPropertiesOptions(bool onlyVisibles, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // SQL MODE
            this._SchemaType = Linkar.SchemaType.TYPE.LKSCHEMAS;
            this._SqlMode = true;
            this._RowHeaders = Linkar.RowHeaders.TYPE.NONE;
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
        /// <param name="pagination">True if pagination is being used.</param>
        /// <param name="regPage">For use with pagination, indicates the number of records by page. Must be greater than 0.</param>
        /// <param name="numPage">For use with pagination, indicates the page number to obtain. Must be greater than 0.</param>
        public LkPropertiesOptions(RowHeaders.TYPE rowHeaders, bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // DICTIONARIES MODE
            this._SchemaType = Linkar.SchemaType.TYPE.DICTIONARIES;
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
        /// Composes the LkProperties options string for processing through LinkarSERVER to the database.
        /// </summary>
        /// <returns>The string ready to be used by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (int)this._SchemaType + DBMV_Mark.AM_str +
                (this._SqlMode ? "1" : "0") + DBMV_Mark.AM_str;

            if (this._SchemaType == Linkar.SchemaType.TYPE.LKSCHEMAS && _SqlMode)
                str += "1" + DBMV_Mark.AM_str + "1" + DBMV_Mark.AM_str;
            else if (this._SchemaType == Linkar.SchemaType.TYPE.DICTIONARIES)
                str += "0" + DBMV_Mark.AM_str + "0" + DBMV_Mark.AM_str;
            else
            {
                str += (this._UsePropertyNames ? "1" : "0") + DBMV_Mark.AM_str +
                    (this._RowProperties ? "1" : "0") + DBMV_Mark.AM_str;
            }

            if (this._SchemaType == Linkar.SchemaType.TYPE.DICTIONARIES)
                str += "0" + DBMV_Mark.AM_str;
            else
                str += (this._OnlyVisibles ? "1" : "0") + DBMV_Mark.AM_str;

            if (this._SchemaType == Linkar.SchemaType.TYPE.LKSCHEMAS && _SqlMode)
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
    /// Detailed options to be used in GetTable and related functions.
    /// </summary>
    public class TableOptions
    {
        private SchemaType.TYPE _SchemaType;
        /// <summary>
        /// Indicates the type of LkSchemas used
        /// </summary>
        public SchemaType.TYPE SchemaType
        {
            get { return this._SchemaType; }
        }

        private RowHeaders.TYPE _RowHeaders;
        /// <summary>
        /// Include headings in first row MAINLABEL (main headings), SHORTLABEL (short label headings), and NONE (without headings).
        /// </summary>
        public RowHeaders.TYPE RowHeaders
        {
            get { return this._RowHeaders; }
        }

        private bool _SqlMode;
        /// <summary>
        /// SQLMODE type schemas
        /// </summary>
        public bool SqlMode
        {
            get { return this._SqlMode; }
        }

        private bool _RowProperties;
        /// <summary>
        /// First row contains property names.
        /// </summary>
        public bool RowProperties
        {
            get { return this._RowProperties; }
        }

        private bool _OnlyVisibles;
        /// <summary>
        /// Use only Visible Schemas and Properties.
        /// </summary>
        public bool OnlyVisibles
        {
            get { return this._OnlyVisibles; }
        }

        private bool _UsePropertyNames;
        /// <summary>
        /// Use Properties and Table names.
        /// </summary>
        public bool UsePropertiesNames
        {
            get { return this._UsePropertyNames; }
        }

        private bool _RepeatValues;
        /// <summary>
        /// Repeat common atributes in MV and SV groups.
        /// </summary>
        public bool RepeatValues
        {
            get { return this._RepeatValues; } 
        }

        private bool _ApplyConversion;
        /// <summary>
        /// Execute Conversions: With Dictionaries, conversion defined in the dictionary. With Schemas conversions defined in Linkar Schemas.
        /// </summary>
        public bool ApplyConversion
        {
            get { return this._ApplyConversion; }
        }

        private bool _ApplyFormat;
        /// <summary>
        /// Execute Formats. With Dictionaries, formats defined in the dictionary. With Schemas formats defined in Linkar Schemas.
        /// </summary>
        public bool ApplyFormat
        {
            get { return this._ApplyFormat; }
        }

        private bool _Calculated;
        /// <summary>
        /// Return the resulting values from the calculated dictionaries.
        /// </summary>
        public bool Calculated
        {
            get { return this._Calculated; }
        }

        private bool _Pagination;
        /// <summary>
        /// Indicates if pagination is being used or not.
        /// </summary>
        public bool Pagination
        {
            get { return this._Pagination; }
        }

        private int _Pagination_RegPage;
        /// <summary>
        /// In case of pagination indicates the number of records by page. It must be bigger than 0.
        /// </summary>
        public int Pagination_RegPage
        {
            get { return this._Pagination_RegPage; }
        }

        private int _Pagination_NumPage;
        /// <summary>
        /// In case of pagination it indicates the page number to obtain. Must be greater than 0.
        /// </summary>
        public int Pagination_NumPage
        {
            get { return this._Pagination_NumPage; }
        }

        /// <summary>
        /// Initializes a new instance of the TableOptions class.
        /// The object is created with the default values for queries with LKSCHEMAS type schemas.
        /// </summary>
        public TableOptions() : this(Linkar.RowHeaders.TYPE.MAINLABEL, false, false, false, false, false, false, false)
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
        /// <param name="pagination">True if pagination is being used.</param>
        /// <param name="regPage">For use with pagination, indicates the number of records by page. Must be greater than 0.</param>
        /// <param name="numPage">For use with pagination, indicates the page number to obtain. Must be greater than 0.</param>
        public TableOptions(RowHeaders.TYPE rowHeaders, bool rowProperties, bool onlyVisibles, bool usePropertyNames,
            bool repeatValues, bool applyConversion, bool applyFormat, bool calculated,
            bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // LKSCHEMAS MODE
            this._SchemaType = Linkar.SchemaType.TYPE.LKSCHEMAS;
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
        /// <param name="pagination">True if pagination is being used.</param>
        /// <param name="regPage">For use with pagination, indicates the number of records by page. Must be greater than 0.</param>
        /// <param name="numPage">For use with pagination, indicates the page number to obtain. Must be greater than 0.</param>
        public TableOptions(bool onlyVisibles, bool applyConversion, bool applyFormat, bool calculated,
            bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // SQL MODE
            this._SchemaType = Linkar.SchemaType.TYPE.LKSCHEMAS;
            this._SqlMode = true;
            this._RowHeaders = Linkar.RowHeaders.TYPE.NONE;
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
        /// <param name="pagination">True if pagination is being used.</param>
        /// <param name="regPage">For use with pagination, indicates the number of records by page. Must be greater than 0.</param>
        /// <param name="numPage">For use with pagination, indicates the page number to obtain. Must be greater than 0.</param>
        public TableOptions(RowHeaders.TYPE rowHeaders, bool repeatValues, bool applyConversion, bool applyFormat, bool calculated,
            bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // DICTIONARIES MODE
            this._SchemaType = Linkar.SchemaType.TYPE.DICTIONARIES;
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
        /// <param name="pagination">True if pagination is being used.</param>
        /// <param name="regPage">For use with pagination, indicates the number of records by page. Must be greater than 0.</param>
        /// <param name="numPage">For use with pagination, indicates the page number to obtain. Must be greater than 0.</param>
        public TableOptions(RowHeaders.TYPE rowHeaders, bool repeatValues,
            bool pagination = false, int regPage = 10, int numPage = 1)
        {
            // NONE MODE
            this._SchemaType = Linkar.SchemaType.TYPE.NONE;
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
        /// Composes the GetTable options string for processing through LinkarSERVER to the database.
        /// </summary>
        /// <returns>The string ready to be used by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (int)this._SchemaType + DBMV_Mark.AM_str +
                (this._SqlMode ? "1" : "0") + DBMV_Mark.AM_str;
            if (this._SchemaType == Linkar.SchemaType.TYPE.LKSCHEMAS && this._SqlMode)
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
            else if (this._SchemaType == Linkar.SchemaType.TYPE.DICTIONARIES)
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
            else if (this._SchemaType == Linkar.SchemaType.TYPE.NONE)
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
