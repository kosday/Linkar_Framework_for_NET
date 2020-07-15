namespace Linkar
{
    internal class SchemaType
    {
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


}
