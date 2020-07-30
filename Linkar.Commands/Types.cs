using System;
using System.Collections.Generic;
using System.Text;

namespace Linkar.Commands
{
    public enum OPERATION_CODE
    {
        NONE = 0,
        LOGIN = 1, LOGOUT = 8, VERSION = 9,

        COMMAND_XML = 150, COMMAND_JSON = 151,
    };

    public enum ENVELOPE_FORMAT
    {
        XML,
        JSON
    };

    /// <summary>
    /// Output format type for all operations, except Read, New, Update, Select, LkSchemas, LkProperties and GetTable
    /// Also it's the input format type for New, Update and Delete operations.
    /// </summary>
    public enum DATAFORMAT_TYPE
    {
        MV = 1,
        XML = 2,
        JSON = 3
    };

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
        public const byte TAB = 0x09;
        public const char TAB_chr = '\x09';
        public const string TAB_str = "\x09";

        public const byte LF = 0x0A;
        public const char LF_chr = '\x0A';
        public const string LF_str = "\x0A";

        public const byte CR = 0x0D;
        public const char CR_chr = '\x0D';
        public const string CR_str = "\x0D";

        public const byte US = 0x1F;
        public const char US_chr = '\x1F';
        public const string US_str = "\x1F";

        public const byte SUB = 0x1A;
        public const char SUB_chr = '\x1A';
        public const string SUB_str = "\x1A";

        public const byte DC1 = 0x11;
        public const char DC1_chr = '\x11';
        public const string DC1_str = "\x11";

        public const byte DC2 = 0x12;
        public const char DC2_chr = '\x12';
        public const string DC2_str = "\x12";

        public const byte DC4 = 0x14;
        public const char DC4_chr = '\x14';
        public const string DC4_str = "\x14";

        public const byte FS = 0x1C;
        public const char FS_chr = '\x1C';
        public const string FS_str = "\x1C";

        public const byte RS = 0x1E;
        public const char RS_chr = '\x1E';
        public const string RS_str = "\x1E";
    }
}
