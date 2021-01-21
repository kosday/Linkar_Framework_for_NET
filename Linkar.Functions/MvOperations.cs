using System;
using System.Text.RegularExpressions;

namespace Linkar.Functions
{
    /// <summary>
    /// This class contains the basic functions to work with multivalue strings. These functions are locally executed.
    /// </summary>
    public static class MvOperations
    {
        /// <summary>
        /// Counts the delimited substrings inside a string.
        /// </summary>
        /// <param name="str">Source string of delimited fields.</param>
        /// <param name="delimiter">The separator character(s) used to delimit fields in the string.</param>
        /// <returns>The number of occurrences found.</returns>
        /// <example>
        /// <code lang="CS">
        /// int result = MvOperations.LkDCount("CUSTOMER UPDATE 2þADDRESS 2þ444", "þ");
        /// </code>
        /// <code lang="VB">
        /// </code>
        /// Integer result = MvOperations.LkDCount("CUSTOMER UPDATE 2þADDRESS 2þ444", "þ")
        /// </example>
        public static int LkDCount(string str, string delimiter)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            else if (string.IsNullOrEmpty(delimiter))
                return str.Length;
            else
            {
                string[] separator = new string[] { delimiter };
                string[] parts = str.Split(separator, StringSplitOptions.None);

                int c = parts.Length;
                return c;
            }
        }

        /// <summary>
        /// Counts the occurrences of a substring inside a string.
        /// </summary>
        /// <param name="str">Source string of delimited fields.</param>
        /// <param name="delimiter">The separator character(s) used to delimit fields in the string.</param>
        /// <returns>The number of occurrences found.</returns>
        /// <example>
        /// <code lang="CS">
        /// int result = MvOperations.LkCount("CUSTOMER UPDATE 2þADDRESS 2þ444", "þ");
        /// </code>
        /// <code lang="VB">
        /// </code>
        /// Integer result = MvOperations.LkCount("CUSTOMER UPDATE 2þADDRESS 2þ444", "þ")
        /// </example>
        public static int LkCount(string str, string delimiter)
        {
            if (string.IsNullOrEmpty(str))
                return 0;
            else if (string.IsNullOrEmpty(delimiter))
                return str.Length;
            else
                return LkDCount(str, delimiter) - 1;
        }

        /// <summary>
        /// Extracts a field, value or subvalue from a dynamic array.
        /// </summary>
        /// <param name="str">The source string from which data is extracted.</param>
        /// <param name="field">The position of the attribute to extract.</param>
        /// <param name="value">The multivalue position to extract.</param>
        /// <param name="subvalue">The subvalue position to extract.</param>
        /// <returns>A new string with the extracted value.</returns>
        /// <example>
        /// <code lang="CS">
        /// string result = MvOperations.LkExtract("CUSTOMER UPDATE 2þADDRESS 2þ444", 1);
        /// </code>
        /// <code lang="VB">
        /// </code>
        /// String result = MvOperations.LkExtract("CUSTOMER UPDATE 2þADDRESS 2þ444", 1)
        /// </example>
        public static string LkExtract(string str, int field, int value = 0, int subvalue = 0)
        {
            string aux = "";

            if (field > 0)
            {
                string[] parts = str.Split(DBMV_Mark.AM);
                if (field <= parts.Length)
                    str = aux = parts[field - 1];
            }

            if (value > 0)
            {
                string[] parts = str.Split(DBMV_Mark.VM);
                if (value <= parts.Length)
                    str = aux = parts[value - 1];
            }

            if (subvalue > 0)
            {
                string[] parts = str.Split(DBMV_Mark.SM);
                if (subvalue <= parts.Length)
                    aux = parts[subvalue - 1];
            }

            return aux;
        }

        /// <summary>
        /// Extracts a field, value or subvalue from a dynamic array.
        /// </summary>
        /// <param name="str">The source string from which data is extracted.</param>
        /// <param name="lstDicts">Dictionaries list on which the field specified argument will be searched.</param>
        /// <param name="field">The dictionary name of the attribute to extract.</param>
        /// <param name="value">The multivalue position to extract.</param>
        /// <param name="subvalue">The subvalue position to extract.</param>
        /// <returns>A new string with the extracted value.</returns>
        /// <example>
        /// <code lang="CS">
        /// string result = MvOperations.LkExtract("CUSTOMER UPDATE 2þADDRESS 2þ444","NAMEþADDRþPHONE", 1);
        /// </code>
        /// <code lang="VB">
        /// </code>
        /// String result = MvOperations.LkExtract("CUSTOMER UPDATE 2þADDRESS 2þ444","NAMEþADDRþPHONE", 1)
        /// </example>
        public static string LkExtract(string str, string lstDicts, string field, int value = 0, int subvalue = 0)
        {
            string aux = "";

            int pos = GetDictPos(lstDicts, field);
            if (pos > -1)
                aux = LkExtract(str, pos, value, subvalue);

            return aux;
        }

        /// <summary>
        /// Replaces the occurrences of a substring inside a string, by other substring.
        /// </summary>
        /// <param name="str">The string on which the value is going to change.</param>
        /// <param name="strOld">The value to change. </param>
        /// <param name="strNew">The new value.</param>
        /// <param name="occurrence">The number of times it will change.</param>
        /// <param name="start">The position from which you are going to start changing values.</param>
        /// <returns>A new string with replaced text.</returns>
        /// <example>
        /// <code lang="CS">
        /// string result = MvOperations.LkChange("CUSTOMER UPDATE 2þADDRESS 2þ444", "UPDATE", "MYTEXT", 1, 1);
        /// </code>
        /// <code lang="VB">
        /// </code>
        /// String result = MvOperations.LkChange("CUSTOMER UPDATE 2þADDRESS 2þ444", "UPDATE", "MYTEXT", 1, 1)
        /// </example>
        public static string LkChange(string str, string strOld, string strNew, int occurrence = 0, int start = 0)
        {
            string result = "";

            if (occurrence <= 0 && start <= 0)
                result = str.Replace(strOld, strNew);
            else
            {
                Regex regex = new Regex(Regex.Escape(strOld));
                result = regex.Replace(str, strNew, occurrence, start);
            }

            return result;
        }

        /// <summary>
        /// Replaces a field, value or subvalue from a dynamic array, returning the result.
        /// </summary>
        /// <param name="str">The string on which you are going to replace a value.</param>
        /// <param name="newVal">New value that will be replaced in the indicated string.</param>
        /// <param name="field">The position of the attribute where you want to replace.</param>
        /// <param name="value">The multivalue position where you want to replace.</param>
        /// <param name="subvalue">The subvalue position where you want to replace.</param>
        /// <returns>A new string with the replaced value.</returns>
        /// <example>
        /// <code lang="CS">
        /// string result = MvOperations.LkReplace("CUSTOMER UPDATE 2þADDRESS 2þ444", "MYTEXT", 1);
        /// </code>
        /// <code lang="VB">
        /// String result = MvOperations.LkReplace("CUSTOMER UPDATE 2þADDRESS 2þ444", "MYTEXT", 1)
        /// </code>
        /// </example>
        public static string LkReplace(string str, string newVal, int field, int value = 0, int subvalue = 0)
        {
            string result = "";

            int len = str.Length;
            int i = 0;

            field--;
            while (field > 0 && len > 0)
            {
                if (str[i] == DBMV_Mark.AM)
                    field--;
                i++;
                len--;
            }
            if (field > 0)
            {
                str += new string(DBMV_Mark.AM, field);
                i += field;
            }

            value--;
            while (value > 0 && len > 0)
            {
                if (str[i] == DBMV_Mark.AM)
                    break;

                if (str[i] == DBMV_Mark.VM)
                    value--;
                i++;
                len--;
            }
            if (value > 0)
            {
                str = str.Insert(i, new string(DBMV_Mark.VM, value));
                i += value;
            }

            subvalue--;
            while (subvalue > 0 && len > 0)
            {
                if (str[i] == DBMV_Mark.VM || str[i] == DBMV_Mark.AM)
                    break;

                if (str[i] == DBMV_Mark.SM)
                    subvalue--;

                i++;
                len--;
            }
            if (subvalue > 0)
            {
                str = str.Insert(i, new string(DBMV_Mark.SM, subvalue));
                i += subvalue;
            }

            if (i >= str.Length)
                result = str + newVal;
            else
            {
                int nextAM = str.IndexOf(DBMV_Mark.AM, i);
                if (nextAM == -1)
                    nextAM = int.MaxValue;
                int nextVM = str.IndexOf(DBMV_Mark.VM, i);
                if (nextVM == -1)
                    nextVM = int.MaxValue;
                int nextSM = str.IndexOf(DBMV_Mark.SM, i);
                if (nextSM == -1)
                    nextSM = int.MaxValue;
                int j = Math.Min(nextAM, Math.Min(nextVM, nextSM));
                if (j == int.MaxValue)
                    j = str.Length;

                string part1 = str.Substring(0, i);
                string part2 = str.Substring(j);
                result = part1 + newVal + part2;
            }

            return result;
        }

        /// <summary>
        /// Replaces a field, value or subvalue from a dynamic array, returning the result.
        /// </summary>
        /// <param name="str">The string on which you are going to replace a value.</param>
        /// <param name="newVal">New value that will be replaced in the indicated string.</param>
        /// <param name="lstDicts">Dictionaries list on which the field specified argument will be searched.</param>
        /// <param name="field">The dictionary name of the attribute where you want to replace.</param>
        /// <param name="value">The multivalue position where you want to replace.</param>
        /// <param name="subvalue">The subvalue position where you want to replace.</param>
        /// <returns>A new string with the replaced value.</returns>
        /// <example>
        /// <code lang="CS">
        /// string result = MvOperations.LkReplace("CUSTOMER UPDATE 2þADDRESS 2þ444", "MYTEXT", "NAMEþADDRþPHONE", 1,);
        /// </code>
        /// <code lang="VB">
        /// String result = MvOperations.LkReplace("CUSTOMER UPDATE 2þADDRESS 2þ444", "MYTEXT", "NAMEþADDRþPHONE", 1,)
        /// </code>
        /// </example>
        public static string LkReplace(string str, string newVal, string lstDicts, string field, int value = 0, int subvalue = 0)
        {
            string aux = "";

            int pos = GetDictPos(lstDicts, field);
            if (pos > -1)
            {
                aux = LkReplace(str, newVal, pos, value, subvalue);
            }

            return aux;
        }

        /// <summary>
        /// Auxiliary function to obtain the position (field value) of the dictionary
        /// </summary>
        /// <param name="lstdicts">Dictionaries list on which the field specified argument will be searched.</param>
        /// <param name="field">The dictionary name of the attribute that you want to obtain the position</param>
        /// <returns>The position (filed number) of the dictionary</returns>
        private static int GetDictPos(string lstdicts, string field)
        {
            int pos = -1;
            if (!string.IsNullOrEmpty(lstdicts) && !string.IsNullOrEmpty(field))
            {
                string[] dicts = lstdicts.Split(DBMV_Mark.AM);

                for (int i = 0; i < dicts.Length; i++)
                {
                    if (dicts[i].ToUpper() == field.ToUpper())
                    {
                        pos = i;
                        break;
                    }
                }
            }
            return pos;
        }
    }
}
