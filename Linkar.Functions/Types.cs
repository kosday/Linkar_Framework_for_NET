namespace Linkar.Functions
{
    /// <summary>
    /// The codes of each operation
    /// </summary>
    public enum OPERATION_CODE
    {
        NONE = 0,
        LOGIN = 1, READ = 2, UPDATE = 3, NEW = 4, DELETE = 5, CONVERSION = 6, FORMAT = 7, LOGOUT = 8, VERSION = 9,
        SELECT = 10, SUBROUTINE = 11, EXECUTE = 12, DICTIONARIES = 13,
        LKSCHEMAS = 14, LKPROPERTIES = 15, GETTABLE = 16, RESETCOMMONBLOCKS = 17,

        COMMAND_XML = 150, COMMAND_JSON = 151,
    };

    /// <summary>
    /// Indicates in what format you want to receive the data resulting from the operation.
    /// Output format type for all operations, except Read, New, Update, Select, LkSchemas, LkProperties and GetTable
    /// Also The input format type for New, Update and Delete operations.
    /// </summary>
    public enum DATAFORMAT_TYPE
    {
        /// <summary>
        /// Show the results of the operation in MV format.
        /// </summary>
        MV = 1,

        /// <summary>
        /// Show the results of the operation in XML format.
        /// </summary>
        XML = 2,

        /// <summary>
        /// Show the results of the operation in JSON format.
        /// </summary>
        JSON = 3
    };

    /// <summary>
    /// Indicates in what format you want to receive the data resulting from the operation.
    /// Output format type for Read, New, Update and Select operations.
    /// </summary>
    public enum DATAFORMATCRU_TYPE
    {
        /// <summary>
        /// Show the results of the operation in MV format.
        /// </summary>
        MV = 1,

        /// <summary>
        /// Show the results of the operation in XML format.
        /// </summary>
        XML = 2,

        /// <summary>
        /// Show the results of the operation in JSON format.
        /// </summary>
        JSON = 3,

        /// <summary>
        /// Show the results of the operation in XML_DICT format, using the dictionaries.
        /// </summary>
        XML_DICT = 5,

        /// <summary>
        /// Show the results of the operation in XML_SCH format, using the schema properties.
        /// </summary>
        XML_SCH = 6,

        /// <summary>
        /// Show the results of the operation in JSON_DICT format, using the dictionaries.
        /// </summary>
        JSON_DICT = 7,

        /// <summary>
        /// Show the results of the operation in JSON_SCH format, using the schema properties.
        /// </summary>
        JSON_SCH = 8
    };

    /// <summary>
    /// Specify the output formats of LkSchemas and LkProperties operations (For other operations, <see cref="DATAFORMAT_TYPE"/> and <see cref="DATAFORMATCRU_TYPE"/>).
    /// </summary>
    public enum DATAFORMATSCH_TYPE
    {
        /// <summary>
        /// Show the results of the operation in MV format.
        /// </summary>
        MV = 1,

        /// <summary>
        /// Show the results of the operation in XML format.
        /// </summary>
        XML = 2,

        /// <summary>
        /// Show the results of the operation in JSON format.
        /// </summary>
        JSON = 3,

        /// <summary>
        /// Show the results of the operation in TABLE format.
        /// </summary>
        TABLE = 4
    };

    /// <summary>
    /// The conversion type for Conversion functions.
    /// </summary>
    public enum CONVERSION_TYPE
    {
        /// <summary>
        /// Perform ICONV type conversions.
        /// </summary>
        INPUT,

        /// <summary>
        /// Perform OCONV type conversions.
        /// </summary>
        OUTPUT
    };

    /// <summary>
    /// The schemas type for <see cref="LkSchemasOptions"/>, <see cref="LkPropertiesOptions"/> and <see cref="TableOptions"/> functions
    /// </summary>
    public class SchemaType
    {
        /// <summary>
        /// Schema types
        /// </summary>
        public enum TYPE
        {
            LKSCHEMAS = 1,
            DICTIONARIES = 2,
            NONE = 3
        };

        internal static string GetString(TYPE strType)
        {
            string str = "NOTHING";
            if (strType == TYPE.LKSCHEMAS)
                str = "LKSCHEMAS";
            if (strType == TYPE.DICTIONARIES)
                str = "DICTIONARIES";

            return str;
        }
    }

    /// <summary>
    /// Indicates options to include headers in the first row or not <see cref="LkSchemasOptions"/> <see cref="LkPropertiesOptions"/> and <see cref="TableOptions"/>
    /// </summary>
    public class RowHeaders
    {
        /// <summary>
        /// RowHeaders types
        /// </summary>
        public enum TYPE
        {
            /// <summary>
            /// Main headings.
            /// </summary>
            MAINLABEL = 1,

            /// <summary>
            /// Short label headings.
            /// </summary>
            SHORTLABEL = 2,

            /// <summary>
            /// Without headings.
            /// </summary>
            NONE = 3
        };


        internal static string GetString(TYPE strType)
        {
            string str = "NOTHING";
            if (strType == TYPE.MAINLABEL)
                str = "MAINLABEL";
            if (strType == TYPE.SHORTLABEL)
                str = "SHORTLABEL";

            return str;
        }
    }

    /// <summary>
    /// Some ASCII characters used by Linkar.
    /// </summary>
    public static class ASCII_Chars
    {
        //IMPORTANT:
        // Forbiden chars inside the Linkar Packets: SOH, STX, EOT, DC1, DC2, DC3, DC4, FS, SUB, RS, US

        /*
        Binario	    Decimal	    Hex	    Abreviatura	Repr AT     Nombre/Significado
        0000 0000	0	        00	    NUL	    	^@	        Carácter Nulo
        0000 0001	1	        01	    SOH	    	^A	        Inicio de Encabezado
        0000 0010	2	        02	    STX	    	^B	        Inicio de Texto
        0000 0011	3	        03	    ETX	    	^C	        Fin de Texto
        0000 0100	4	        04	    EOT	    	^D	        Fin de Transmisión
        0000 0101	5	        05	    ENQ	    	^E	        Enquiry
        0000 0110	6	        06	    ACK	    	^F	        Acknowledgement
        0000 0111	7	        07	    BEL	    	^G	        Timbre
        0000 1000	8	        08	    BS	    	^H	        Retroceso
        0000 1001	9	        09	    HT	    	^I	        Tabulación horizontal
        0000 1010	10	        0A	    LF	    	^J	        Line feed
        0000 1011	11	        0B	    VT	    	^K	        Tabulación Vertical
        0000 1100	12	        0C	    FF	    	^L	        Form feed
        0000 1101	13	        0D	    CR	    	^M	        Carriage return
        0000 1110	14	        0E	    SO	    	^N	        Shift Out
        0000 1111	15	        0F	    SI	    	^O	        Shift In
        0001 0000	16	        10	    DLE	    	^P	        Data Link Escape
        0001 0001	17	        11	    DC1	    	^Q	        Device Control 1 — oft. XON
        0001 0010	18	        12	    DC2	    	^R	        Device Control 2
        0001 0011	19	        13	    DC3	    	^S	        Device Control 3 — oft. XOFF
        0001 0100	20	        14	    DC4	    	^T	        Device Control 4
        0001 0101	21	        15	    NAK	    	^U	        Negative Acknowledgement
        0001 0110	22	        16	    SYN	    	^V	        Synchronous Idle
        0001 0111	23	        17	    ETB	    	^W	        End of Trans. Block
        0001 1000	24	        18	    CAN	    	^X	        Cancel
        0001 1001	25	        19	    EM	    	^Y	        End of Medium
        0001 1010	26	        1A	    SUB	    	^Z	        Substitute
        0001 1011	27	        1B	    ESC	    	^[ o        r ESC	Escape
        0001 1100	28	        1C	    FS	    	^\	        File Separator
        0001 1101	29	        1D	    GS	    	^]	        Group Separator
        0001 1110	30	        1E	    RS	    	^^	        Record Separator
        0001 1111	31	        1F	    US	    	^_	        Unit Separator
        0111 1111	127	        7F	    DEL	    	^?,         Delete, or Backspace	Delete         
 */

        /// <summary>
        /// ASCII character horizontal tab.
        /// </summary>
        public const byte TAB = 0x09;
        /// <summary>
        /// ASCII character horizontal tab.
        /// </summary>
        public const char TAB_chr = '\x09';
        /// <summary>
        /// ASCII character horizontal tab.
        /// </summary>
        public const string TAB_str = "\x09";

        /// <summary>
        /// ASCII character line break.
        /// </summary>
        public const byte LF = 0x0A;
        /// <summary>
        /// ASCII character line break.
        /// </summary>
        public const char LF_chr = '\x0A';
        /// <summary>
        /// ASCII character line break.
        /// </summary>
        public const string LF_str = "\x0A";

        /// <summary>
        /// ASCII character carriage return.
        /// </summary>
        public const byte CR = 0x0D;
        /// <summary>
        /// ASCII character carriage return.
        /// </summary>
        public const char CR_chr = '\x0D';
        /// <summary>
        /// ASCII character carriage return.
        /// </summary>
        public const string CR_str = "\x0D";

        /// <summary>
        /// ASCII character used as separator of the operation arguments <see cref="OperationArguments"/>.
        /// </summary>
        public const byte US = 0x1F;
        /// <summary>
        /// ASCII character used as separator of the operation arguments <see cref="OperationArguments"/>.
        /// </summary>
        public const char US_chr = '\x1F';
        /// <summary>
        /// ASCII character used as separator of the operation arguments <see cref="OperationArguments"/>.
        /// </summary>
        public const string US_str = "\x1F";

        /// <summary>
        /// ASCII character used as separator of the arguments of a subroutine.
        /// </summary>
        public const byte DC4 = 0x14;
        /// <summary>
        /// ASCII character used as separator of the arguments of a subroutine.
        /// </summary>
        public const char DC4_chr = '\x14';
        /// <summary>
        /// ASCII character used as separator of the arguments of a subroutine.
        /// </summary>
        public const string DC4_str = "\x14";

        /// <summary>
        /// When the responses of the operations are of MV type, this character is used to separate the header (the ThisList property in LkData) from the data.
        /// </summary>
        public const byte FS = 0x1C;
        /// <summary>
        /// When the responses of the operations are of MV type, this character is used to separate the header (the ThisList property in LkData) from the data.
        /// </summary>
        public const char FS_chr = '\x1C';
        /// <summary>
        /// When the responses of the operations are of MV type, this character is used to separate the header (the ThisList property in LkData) from the data.
        /// </summary>
        public const string FS_str = "\x1C";

        /// <summary>
        /// ASCII character used by Linkar as separator of items in lists. For example, list of records.
        /// </summary>
        public const byte RS = 0x1E;
        /// <summary>
        /// ASCII character used by Linkar as separator of items in lists. For example, list of records.
        /// </summary>
        public const char RS_chr = '\x1E';
        /// <summary>
        /// ASCII character used by Linkar as separator of items in lists. For example, list of records.
        /// </summary>
        public const string RS_str = "\x1E";
    }


    /// <summary>
    /// Special ASCII characters used by Multivalued Databases.
    /// </summary>
    public static class DBMV_Mark
    {
        /// <summary>
        /// Character ASCII 255. IM Multi-value mark.
        /// </summary>
        public const char IM = (char)255;

        /// <summary>
        /// Character ASCII 254. AM Multi-value mark.
        /// </summary>
        public const char AM = (char)254;

        /// <summary>
        /// Character ASCII 253. VM Multi-value mark.
        /// </summary>
        public const char VM = (char)253;

        /// <summary>
        /// Character ASCII 252. SM Multi-value mark.
        /// </summary>
        public const char SM = (char)252;

        /// <summary>
        /// Character ASCII 251. TM Multi-value mark.
        /// </summary>
        public const char TM = (char)251;

        /// <summary>
        /// Character ASCII 255. IM Multi-value mark.
        /// </summary>
        public const string IM_str = "\xFF";

        /// <summary>
        /// Character ASCII 254. AM Multi-value mark.
        /// </summary>
        public const string AM_str = "\xFE";

        /// <summary>
        /// Character ASCII 253. VM Multi-value mark.
        /// </summary>
        public const string VM_str = "\xFD";

        /// <summary>
        /// Character ASCII 252. SM Multi-value mark.
        /// </summary>
        public const string SM_str = "\xFC";

        /// <summary>
        /// Character ASCII 251. TM Multi-value mark.
        /// </summary>
        public const string TM_str = "\xFB";
    }


}
