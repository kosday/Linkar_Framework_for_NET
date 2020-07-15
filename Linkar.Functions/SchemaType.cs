namespace Linkar
{
    internal class SchemaType
    {
        public enum TYPE
        {
            LKSCHEMA = 1,
            DICTIONARY = 2,
            NONE = 3
        };

        internal static string GetString(TYPE strType)
        {
            string str = "NOTHING";
            if (strType == TYPE.LKSCHEMA)
                str = "LKSCHEMA";
            if (strType == TYPE.DICTIONARY)
                str = "DICTIONARY";

            return str;
        }
    }


}
