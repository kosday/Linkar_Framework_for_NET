namespace Linkar
{
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
}
