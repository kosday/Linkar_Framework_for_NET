using System;
using System.Text.RegularExpressions;

namespace Linkar
{
    /// <summary>
    /// 
    /// </summary>
    public static class MvOperations
    {
        /// <summary>
        /// Counts the delimited substrings inside a string.
        /// </summary>
        /// <param name="str">The string you are going to count.</param>
        /// <param name="delimiter">The separator you are going to count.</param>
        /// <returns>The number of occurrences found.</returns>
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
        /// <param name="str">The string you are going to count.</param>
        /// <param name="delimiter">The separator you are going to count.</param>
        /// <returns>The number of occurrences found.</returns>
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
        /// <param name="str">The string on which you are going to extract a value.</param>
        /// <param name="field">The position of the attribute to be extracted.</param>
        /// <param name="value">The multivalue position to be extracted.</param>
        /// <param name="subvalue">The subvalue position to be extracted.</param>
        /// <returns>A new string with the extracted value.</returns>
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
        /// <param name="strSource">Dynamic Array source data</param>
        /// <param name="lstDicts">List of Dictionary Definitions defining the record being processed.</param>
        /// <param name ="fieldName">The dictionary name of the attribute to be extracted.</param>
        /// <param name="value">The multivalue position to be extracted.</param>
        /// <param name="subvalue">The subvalue position to be extracted.</param>
        /// <returns>A new string with the extracted value.</returns>
        public static string LkExtract(string strSource, string lstDicts, string fieldName, int value = 0, int subvalue = 0)
        {
            string result = "";

            int pos = GetDictPos(lstDicts, fieldName);
            if (pos > -1)
                result = LkExtract(strSource, pos, value, subvalue);

            return result;
        }

        /// <summary>
        /// Replaces the occurrences of a substring inside a string, by other substring.
        /// </summary>
        /// <param name="str">The string on which the value is going to change.</param>
        /// <param name="strOld">The value to change. </param>
        /// <param name="strNew">The new value.</param>
        /// <param name="ocurrence">The new value.</param>
        /// <param name="start">The position from which you are going to start changing values.</param>
        /// <returns>A new string with replaced text.</returns>
        public static string LkChange(string str, string strOld, string strNew, int ocurrence = 0, int start = 0)
        {
            string result = "";

            if (ocurrence <= 0 && start <= 0)
                result = str.Replace(strOld, strNew);
            else
            {
                Regex regex = new Regex(Regex.Escape(strOld));
                result = regex.Replace(str, strNew, ocurrence, start);
            }

            return result;
        }

        /// <summary>
        /// Replaces a field, value or subvalue from a dynamic array, returning the result.
        /// </summary>
        /// <param name="strOld">The string on which you are going to replace a value.</param>
        /// <param name="strNew">New value that will be replaced in the indicated string.</param>
        /// <param name="field">The position of the attribute to be to be replaced.</param>
        /// <param name="value">The multivalue position to be to be replaced.</param>
        /// <param name="subvalue">The subvalue position to be to be replaced.</param>
        /// <returns>A new string with the replaced value.</returns>
        public static string LkReplace(string strOld, string strNew, int field, int value = 0, int subvalue = 0)
        {
            string result = "";

            int len = strOld.Length;
            int i = 0;

            field--;
            while (field > 0 && len > 0)
            {
                if (strOld[i] == DBMV_Mark.AM)
                    field--;
                i++;
                len--;
            }
            if (field > 0)
            {
                strOld += new string(DBMV_Mark.AM, field);
                i += field;
            }

            value--;
            while (value > 0 && len > 0)
            {
                if (strOld[i] == DBMV_Mark.AM)
                    break;

                if (strOld[i] == DBMV_Mark.VM)
                    value--;
                i++;
                len--;
            }
            if (value > 0)
            {
                strOld = strOld.Insert(i, new string(DBMV_Mark.VM, value));
                i += value;
            }

            subvalue--;
            while (subvalue > 0 && len > 0)
            {
                if (strOld[i] == DBMV_Mark.VM || strOld[i] == DBMV_Mark.AM)
                    break;

                if (strOld[i] == DBMV_Mark.SM)
                    subvalue--;

                i++;
                len--;
            }
            if (subvalue > 0)
            {
                strOld = strOld.Insert(i, new string(DBMV_Mark.SM, subvalue));
                i += subvalue;
            }

            if (i >= strOld.Length)
                result = strOld + strNew;
            else
            {
                int nextAM = strOld.IndexOf(DBMV_Mark.AM, i);
                if (nextAM == -1)
                    nextAM = int.MaxValue;
                int nextVM = strOld.IndexOf(DBMV_Mark.VM, i);
                if (nextVM == -1)
                    nextVM = int.MaxValue;
                int nextSM = strOld.IndexOf(DBMV_Mark.SM, i);
                if (nextSM == -1)
                    nextSM = int.MaxValue;
                int j = Math.Min(nextAM, Math.Min(nextVM, nextSM));
                if (j == int.MaxValue)
                    j = strOld.Length;

                string part1 = strOld.Substring(0, i);
                string part2 = strOld.Substring(j);
                result = part1 + strNew + part2;
            }

            return result;
        }

        /// <summary>
        /// Replaces a field, value or subvalue from a dynamic array, returning the result.
        /// </summary>
        /// <param name="strOld">The string on which you are going to replace a value.</param>
        /// <param name="strNew">New value that will be replaced in the indicated string.</param>
        /// <param name="lstDicts">List of Dictionary Definitions on which the field specified argument will be searched.</param>
        /// <param name="field">The dictionary name of the attribute to be to be replaced.</param>
        /// <param name="value">The multivalue position to be to be replaced.</param>
        /// <param name="subvalue">The subvalue position to be to be replaced.</param>
        /// <returns>A new string with the replaced value.</returns>
        public static string LkReplace(string strOld, string strNew, string lstDicts, string field, int value = 0, int subvalue = 0)
        {
            string aux = "";

            int pos = GetDictPos(lstDicts, field);
            if (pos > -1)
            {
                aux = LkReplace(strOld, strNew, pos, value, subvalue);
            }

            return aux;
        }

        /// <summary>
        /// Auxiliary function to obtain the position (field value) of the dictionary
        /// </summary>
        /// <param name="lstDicts">List of Dictionary Definitions.</param>
        /// <param name="fieldName">The name of the dictionary definition which defines the desired field position</param>
        /// <returns>The position (attribute/field number) defined by the dictionary definition</returns>
        private static int GetDictPos(string lstDicts, string fieldName)
        {
            int pos = -1;
            if (!string.IsNullOrEmpty(lstDicts) && !string.IsNullOrEmpty(fieldName))
            {
                string[] dicts = lstDicts.Split(DBMV_Mark.AM);

                for (int i = 0; i < dicts.Length; i++)
                {
                    if (dicts[i].ToUpper() == fieldName.ToUpper())
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
