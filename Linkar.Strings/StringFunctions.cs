﻿using System;

namespace Linkar.Strings
{
    /// <summary>
    /// Namespace Linkar.Strings library
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc
    {
        // Dummy class necessary for SandCastle can generate doc about namespace
    }

    /// <summary>
    /// Set of functions that help manipulate the character strings that are used as input and output data in MV type operations.
    /// </summary>
    public static class StringFunctions
    {
        /// <summary>
        /// The tag value for "TOTAL_RECORDS_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string TOTAL_RECORDS_KEY = "TOTAL_RECORDS";

        /// <summary>
        /// The tag value for "RECORD_IDS_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string RECORD_IDS_KEY = "RECORD_ID";

        /// <summary>
        /// The tag value for "RECORDS_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string RECORDS_KEY = "RECORD";

        /// <summary>
        /// The tag value for "CALCULATED_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string CALCULATED_KEY = "CALCULATED";

        /// <summary>
        /// The tag value for "RECORD_DICTS_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string RECORD_DICTS_KEY = "RECORD_DICTS";

        /// <summary>
        /// The tag value for "RECORD_ID_DICTS_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string RECORD_ID_DICTS_KEY = "RECORD_ID_DICTS";

        /// <summary>
        /// The tag value for "CALCULATED_DICTS_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string CALCULATED_DICTS_KEY = "CALCULATED_DICTS";

        /// <summary>
        /// The tag value for "ARGUMENTS_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string ARGUMENTS_KEY = "ARGUMENTS";

        /// <summary>
        /// The tag value for "ORIGINAL_RECORDS_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string ORIGINAL_RECORDS_KEY = "ORIGINALRECORD";

        /// <summary>
        /// The tag value for "FORMAT_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string FORMAT_KEY = "FORMAT";

        /// <summary>
        /// The tag value for "CONVERSION_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string CONVERSION_KEY = "CONVERSION";

        /// <summary>
        /// The tag value for "CAPTURING_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string CAPTURING_KEY = "CAPTURING";

        /// <summary>
        /// The tag value for "RETURNING_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string RETURNING_KEY = "RETURNING";

        /// <summary>
        /// The tag value for "ROWHEADERS_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string ROWHEADERS_KEY = "ROWHEADERS";

        /// <summary>
        /// The tag value for "ROWPROPERTIES_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string ROWPROPERTIES_KEY = "ROWPROPERTIES";

        /// <summary>
        /// The tag value for "ERRORS_KEY" in Database operation responses of MV type.
        /// </summary>
        public const string ERRORS_KEY = "ERRORS";

        /// <summary>
        /// ASCII character used as separator of the arguments of a subroutine.
        /// </summary>
        public const char DC4 = '\x14';
        /// <summary>
        /// ASCII character used as separator of the arguments of a subroutine.
        /// </summary>
        public const string DC4_str = "\x14";

        /// <summary>
        /// When the responses of the operations are of MV type, this character is used to separate the header (the ThisList property in LkData) from the data.
        /// </summary>
        public const char FS = '\x1C';
        /// <summary>
        /// When the responses of the operations are of MV type, this character is used to separate the header (the ThisList property in LkData) from the data.
        /// </summary>
        public const string FS_str = "\x1C";

        /// <summary>
        /// ASCII character used by Linkar as separator of items in lists. For example, list of records.
        /// </summary>
        public const char RS = '\x1E';
        /// <summary>
        /// ASCII character used by Linkar as separator of items in lists. For example, list of records.
        /// </summary>
        public const string RS_str = "\x1E";

        /// <summary>
        /// Character ASCII 254. AM Multi-value mark.
        /// </summary>
        public const char AM = '\xFE';
        /// <summary>
        /// Character ASCII 254. AM Multi-value mark.
        /// </summary>
        public const string AM_str = "\xFE";

        /// <summary>
        /// Character ASCII 253. VM Multi-value mark.
        /// </summary>
        public const char VM = '\xFD';
        /// <summary>
        /// Character ASCII 253. VM Multi-value mark.
        /// </summary>
        public const string VM_str = "\xFD";

        #region --- Extraction functions

        /// <summary>
        /// Looks for the TOTAL_RECORDS_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of TOTAL_RECORDS_KEY tag.</returns>
        public static int ExtractTotalRecords(string lkString)
        {
            string block = GetData(lkString, TOTAL_RECORDS_KEY, FS, AM);
            int result;
            if (int.TryParse(block, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Looks for the RECORD_IDS_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of RECORD_IDS_KEY tag.</returns>
        public static string[] ExtractRecordIds(string lkString)
        {
            string valueTag = GetData(lkString, RECORD_IDS_KEY, FS, AM);
            return SplitArray(valueTag, RS);
        }

        /// <summary>
        /// Looks for the RECORDS_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of RECORDS_KEY tag.</returns>
        public static string[] ExtractRecords(string lkString)
        {
            string valueTag = GetData(lkString, RECORDS_KEY, FS, AM);
            return SplitArray(valueTag, RS);
        }

        /// <summary>
        /// Looks for the ERRORS_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of ERRORS_KEY tag.</returns>
        public static string[] ExtractErrors(string lkString)
        {
            string valueTag = GetData(lkString, ERRORS_KEY, FS, AM);
            return SplitArray(valueTag, AM);
        }

        /// <summary>
        /// This function formats the message error by split into Error Code and Error Message.
        /// </summary>
        /// <param name="error">The value of ERRORS_KEY tag.</param>
        /// <returns>The error formated</returns>
        public static string FormatError(string error)
        {
            string result = error;
            string[] items = error.Split(VM);
            if(items.Length == 2)
                result = "ERROR CODE: " + items[0] + " ERROR MESSAGE: " + items[1];

            return result;
        }

        /// <summary>
        /// Looks for the CALCULATED_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of CALCULATED_KEY tag.</returns>
        public static string[] ExtractRecordsCalculated(string lkString)
        {
            string valueTag = GetData(lkString, CALCULATED_KEY, FS, AM);
            return SplitArray(valueTag, RS);
        }

        /// <summary>
        /// Looks for the RECORD_DICTS_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of RECORD_DICTS_KEY tag.</returns>
        public static string[] ExtractRecordsDicts(string lkString)
        {
            string valueTag = GetData(lkString, RECORD_DICTS_KEY, FS, AM);
            return SplitArray(valueTag, AM);
        }

        /// <summary>
        /// Looks for the CALCULATED_DICTS_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of CALCULATED_DICTS_KEY tag.</returns>
        public static string[] ExtractRecordsCalculatedDicts(string lkString)
        {
            string valueTag = GetData(lkString, CALCULATED_DICTS_KEY, FS, AM);
            return SplitArray(valueTag, AM);
        }

        /// <summary>
        /// Looks for the RECORD_ID_DICTS_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of RECORD_ID_DICTS_KEY tag.</returns>
        public static string[] ExtractRecordsIdDicts(string lkString)
        {
            string valueTag = GetData(lkString, RECORD_ID_DICTS_KEY, FS, AM);
            return SplitArray(valueTag, AM);
        }

        /// <summary>
        /// Looks for the ORIGINAL_RECORDS_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of ORIGINAL_RECORDS_KEY tag.</returns>
        public static string[] ExtractOriginalRecords(string lkString)
        {
            string valueTag = GetData(lkString, ORIGINAL_RECORDS_KEY, FS, AM);
            return SplitArray(valueTag, RS);
        }

        /// <summary>
        /// Looks for the RECORDS_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of RECORDS_KEY tag.</returns>
        public static string[] ExtractDictionaries(string lkString)
        {
            string valueTag = GetData(lkString, RECORDS_KEY, FS, AM);
            return SplitArray(valueTag, RS);
        }

        /// <summary>
        /// Looks for the CONVERSION_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of CONVERSION_KEY tag.</returns>
        public static string ExtractConversion(string lkString)
        {
            return GetData(lkString, CONVERSION_KEY, FS, AM);
        }

        /// <summary>
        /// Looks for the FORMAT_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of FORMAT_KEY tag.</returns>
        public static string ExtractFormat(string lkString)
        {
            return GetData(lkString, FORMAT_KEY, FS, AM);
        }

        /// <summary>
        /// Looks for the CAPTURING_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of CAPTURING_KEY tag.</returns>
        public static string ExtractCapturing(string lkString)
        {
            return GetData(lkString, CAPTURING_KEY, FS, AM);
        }

        /// <summary>
        /// Looks for the RETURNING_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of RETURNING_KEY tag.</returns>
        public static string ExtractReturning(string lkString)
        {
            return GetData(lkString, RETURNING_KEY, FS, AM);
        }

        /// <summary>
        /// Looks for the ARGUMENTS_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of ARGUMENTS_KEY tag.</returns>
        public static string[] ExtractSubroutineArgs(string lkString)
        {
            string arguments = GetData(lkString, ARGUMENTS_KEY, FS, AM);
            return SplitArray(arguments, DC4);
        }

        /// <summary>
        /// Looks for the ROWPROPERTIES_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of ROWPROPERTIES_KEY tag.</returns>
        public static string[] ExtractRowProperties(string lkString)
        {
            string rowProperties = GetData(lkString, ROWPROPERTIES_KEY, FS, AM);
            return SplitArray(rowProperties, AM);
        }

        /// <summary>
        /// Looks for the ROWHEADERS_KEY tag inside "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <returns>The value of ROWHEADERS_KEY tag.</returns>
        public static string[] ExtractRowHeaders(string lkString)
        {
            string rowHeaders = GetData(lkString, ROWHEADERS_KEY, FS, AM);
            return SplitArray(rowHeaders, AM);
        }

        /// <summary>
        /// Looks for the "tag" inside the "lkString", and extracts its value.
        /// </summary>
        /// <param name="lkString">A string obtained as a result of executing an operation.</param>
        /// <param name="tag">The tag to looking for</param>
        /// <param name="delimiter">Delimiter char of every main items in "lkString".</param>
        /// <param name="delimiterThisList">Delimiter char inside the first item of "lkString". The first item of "lkString" is always the header tags (THISLIST).</param>
        /// <returns>The value of tag.</returns>
        private static string GetData(string lkString, string tag, char delimiter, char delimiterThisList)
        {
            string block = "";
            string[] parts = lkString.Split(delimiter);
            if (parts.Length >= 1)
            {
                string[] headersList = parts[0].Split(delimiterThisList);
                for (int i = 1; i < headersList.Length; i++)
                {
                    if (headersList[i].ToUpper() == tag.ToUpper())
                    {
                        block = parts[i];
                        break;
                    }
                }
            }
            return block;
        }

        /// <summary>
        /// Auxiliary function to extract arrays inside a tag value.
        /// </summary>
        /// <param name="valueTag">The string to be splitted.</param>
        /// <param name="delimiter">The char to use for split.</param>
        /// <returns>The array extracted.</returns>
        private static string[] SplitArray(string valueTag, char delimiter)
        {
            if (string.IsNullOrEmpty(valueTag))
                return new string[] { };
            else
                return valueTag.Split(delimiter);
        }

        #endregion

        #region --- Composition Functions

        /// <summary>
        /// Composes the final string of various "recordsIds". Used by CRUD Operations.
        /// </summary>
        /// <param name="recordIds">Array with the "recordIds" to be joined</param>
        /// <returns>The final string of "recordIds" to be used by CRUD Operations.</returns>
        public static string ComposeRecordIds(params string[] recordIds)
        {
            return JoinArray(recordIds, RS_str);
        }

        /// <summary>
        /// Composes the final string of various "records". Used by CRUD Operations.
        /// </summary>
        /// <param name="records">Array with the "records" to be joined.</param>
        /// <returns>The final string of "records" to be used by CRUD Operations.</returns>
        public static string ComposeRecords(params string[] records)
        {
            return JoinArray(records, RS_str);
        }

        /// <summary>
        /// Composes the final string of various "originalRecords". Used by CRUD Operations.
        /// </summary>
        /// <param name="originalRecords">Array with the "originalRecords" to be joined.</param>
        /// <returns>The final string of "originalRecords" to be used by CRUD Operations.</returns>
        public static string ComposeOriginalRecords(params string[] originalRecords)
        {
            return JoinArray(originalRecords, RS_str);
        }

        /// <summary>
        /// Composes the final string of various "dictionaries". Used by Read and Select Operations.
        /// </summary>
        /// <param name="dictionaries">Array with the "dictionaries" to be joined.</param>
        /// <returns>The final string of "dictionaries" to be used by Read and Select Operations.</returns>
        public static string ComposeDictionaries(params string[] dictionaries)
        {
            return JoinArray(dictionaries, " ");
        }

        /// <summary>
        /// Composes the final string of various "expressions". Used by Format and Conversion Operations.
        /// </summary>
        /// <param name="expressions">Array with the "expressions" to be joined.</param>
        /// <returns>The final string of "expressions" to be used in Format and Conversion Operations.</returns>
        public static string ComposeExpressions(params string[] expressions)
        {
            return JoinArray(expressions, VM_str);
        }

        /// <summary>
        /// Composes the final string of various "arguments" of a subroutine.
        /// </summary>
        /// <param name="args">Array with the "arguments" to be joined.</param>
        /// <returns>The final string to be used in Subroutine Operations.</returns>
        public static string ComposeSubroutineArgs(params string[] args)
        {
            return JoinArray(args, DC4_str);
        }

        /// <summary>
        /// Auxiliary function to compose the final string of multiple items using "delimiter" as separation char.
        /// </summary>
        /// <param name="items">The "items" to be joined.</param>
        /// <param name="delimiter">The "delimiter" char between the "items".</param>
        /// <returns>The final string with the different items joined by "delimiter" char.</returns>
        private static string JoinArray(string[] items, string delimiter)
        {
            if (items != null && items.Length > 0)
                return string.Join(delimiter, items);
            else
                return "";
        }

        /// <summary>
        /// Compose the fully buffer of the Update Operations with the block of "recordIds", "records" and "originalRecords".
        /// </summary>
        /// <param name="recordIds">Block of "recordIds". You can obtain this block with ComposeRecordIds function.</param>
        /// <param name="records">Block of "records". You can obtain this block with ComposeRecords function.</param>
        /// <param name="originalRecords">Block of "originalRecords". You can obtain this block with ComposeRecords function.</param>
        /// <returns>The buffer to be used by Update Operations.</returns>
        public static string ComposeUpdateBuffer(string recordIds, string records, string originalRecords = "")
        {
            return recordIds + FS + records + FS + originalRecords;
        }

        /// <summary>
        /// Compose the fully buffer of the Update Operations with the block of "recordIds", "records" and "originalRecords".
        /// </summary>
        /// <param name="recordIds">Array of "recordIds".</param>
        /// <param name="records">Array of "records".</param>
        /// <param name="originalRecords">Array of "originalRecords".</param>
        /// <returns>The buffer to be used by Update Operations.</returns>
        public static string ComposeUpdateBuffer(string[] recordIds, string[] records, string[] originalRecords = null)
        {
            if ((recordIds.Length != records.Length && originalRecords == null) ||
                (recordIds.Length != originalRecords.Length))
                throw new Exception("The arrays must have the same Length");

            return ComposeUpdateBuffer(ComposeRecordIds(recordIds), ComposeRecords(records), ComposeRecords(originalRecords));
        }

        /// <summary>
        /// Compose the fully buffer of the New Operations with the block of "recordIds" and "records".
        /// </summary>
        /// <param name="recordIds">Block of "recordIds". You can obtain this block with ComposeRecordIds function.</param>
        /// <param name="records">Block of "records". You can obtain this block with ComposeRecords function.</param>
        /// <returns>The buffer to be used by New Operations.</returns>
        public static string ComposeNewBuffer(string recordIds, string records)
        {
            return recordIds + FS + records;
        }

        /// <summary>
        /// Compose the fully buffer of the New Operations with the block of "recordIds" and "records".
        /// </summary>
        /// <param name="recordIds">Array of "recordIds".</param>
        /// <param name="records">Array of "records".</param>
        /// <returns>The buffer to be used by New Operations.</returns>
        public static string ComposeNewBuffer(string[] recordIds, string[] records)
        {
            if (recordIds.Length != records.Length)
                throw new Exception("The arrays must have the same Length");
            return ComposeNewBuffer(ComposeRecordIds(recordIds), ComposeRecords(records));
        }

        /// <summary>
        /// Compose the fully buffer of the Delete Operations with the block of "recordIds" and "originalRecords".
        /// </summary>
        /// <param name="recordIds">Block of "recordIds". You can obtain this block with ComposeRecordIds function.</param>
        /// <param name="originalRecords">Block of "originalRecords". You can obtain this block with ComposeRecords function.</param>
        /// <returns>The buffer to be used by Delete Operations.</returns>
        public static string ComposeDeleteBuffer(string recordIds, string originalRecords = null)
        {
            if (originalRecords != null)
                return recordIds + FS + originalRecords;
            else
                return recordIds;
        }

        /// <summary>
        /// Compose the fully buffer of the Delete Operations with the block of "recordIds" and "originalRecords".
        /// </summary>
        /// <param name="recordIds">Array of "recordIds".</param>
        /// <param name="originalRecords">Array of "originalRecords".</param>
        /// <returns>The buffer to be used by Delete Operations.</returns>
        public static string ComposeDeleteBuffer(string[] recordIds, string[] originalRecords = null)
        {
            if (originalRecords != null && recordIds.Length != originalRecords.Length)
                throw new Exception("The arrays must have the same Length");
            return ComposeDeleteBuffer(ComposeRecordIds(recordIds), ComposeRecords(originalRecords));
        }

        #endregion
    }
}
