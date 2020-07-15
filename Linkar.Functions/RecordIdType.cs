namespace Linkar
{
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
        /// This constructor defines the options for generating Linkar type codes.
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
        /// This constructor defines the options for generating Random type codes.
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
        /// This constructor defines the options for generating Custom type codes.
        /// </summary>
        /// <param name="custom">It must have the value "true" so that the generation of personalized codes through the subroutine of the Database SUB.LK.MAIN.RECOVERRECORDID.CUSTOM is used. If the value is "false", no code generation technique will be used. The codes must be supplied in the New operations.</param>
        public RecordIdType(bool custom)
        {
            this._ActiveTypeLinkar = false;
            this._ActiveTypeRandom = false;
            this._ActiveTypeCustom = true;
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
}
