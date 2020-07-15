namespace Linkar
{
    public class RowHeaders
    {
        public enum TYPE
        {
            MAINLABEL = 1,
            SHORTLABEL = 2,
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


}
