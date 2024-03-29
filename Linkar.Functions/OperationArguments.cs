﻿namespace Linkar.Functions
{
    /// <summary>
    /// Auxiliary static class with functions to obtain the 3 items of every LinkarSERVER operation.
    /// These items are: CUSTOMVARS, OPTIONS and INPUTDATA.
    /// Unit Separator character (31) is used as separator between these items.
    /// CUSTOMVARS: String for database custom subroutines.
    /// OPTIONS: The options of every operation.
    /// INPUTDATA: The necessary data for perform every operation.
    /// CUSTOMVARS US_char OPTIONS US_char INPUTDATA
    /// </summary>
    public static class OperationArguments
    {
        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the Read operation.
        /// </summary>
        /// <param name="filename">File name to read.</param>
        /// <param name="recordIds">A list of item IDs to read, separated by the Record Separator character (30). Use StringFunctions.ComposeRecordIds to compose this string.</param>
        /// <param name="dictionaries">List of dictionaries to read, separated by space. If this list is not set, all fields are returned.</param>
        /// <param name="readOptions">Object that defines the different reading options of the Function: Calculated, dictClause, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetReadArgs(string filename, string recordIds, string dictionaries, ReadOptions readOptions, string customVars)
        {
            if (readOptions == null)
                readOptions = new ReadOptions();

            string options = readOptions.ToString();
            string inputData = filename + DBMV_Mark.AM + recordIds + DBMV_Mark.AM + dictionaries;

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + inputData;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items ( CUSTOMVARS, OPTIONS and INPUTDATA) of the Update operation.
        /// </summary>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Buffer of record data to update. Inside this string are the recordIds, the modified records, and the originalRecords. Use StringFunctions.ComposeUpdateBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="updateOptions">Object with write options, including optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetUpdateArgs(string filename, string records, UpdateOptions updateOptions, string customVars)
        {
            if (updateOptions == null)
                updateOptions = new UpdateOptions();

            string options = updateOptions.ToString();
            string inputData = filename + DBMV_Mark.AM + records;

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + inputData;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items ( CUSTOMVARS, OPTIONS and INPUTDATA) of the UpdatePartial operation.
        /// </summary>
        /// <param name="filename">Name of the file being updated.</param>        
        /// <param name="records">Buffer of record data to update. Inside this string are the recordIds, the modified records, and the originalRecords. Use StringFunctions.ComposeUpdateBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="dictionaries">List of dictionaries to write, separated by space. In MV output format is mandatory.</param>
        /// <param name="updateOptions">Object with write options, including optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetUpdatePartialArgs(string filename, string records, string dictionaries, UpdateOptions updateOptions, string customVars)
        {
            if (updateOptions == null)
                updateOptions = new UpdateOptions();

            string options = updateOptions.ToString();
            string inputData = filename + DBMV_Mark.AM + records + ASCII_Chars.FS_str + dictionaries;

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + inputData;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the New operation.
        /// </summary>
        /// <param name="filename">The file name where the records are going to be created.</param>
        /// <param name="records">Buffer of records to write. Inside this string are the recordIds, and the records. Use StringFunctions.ComposeNewBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="newOptions">Object with write options for the new record(s), including recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetNewArgs(string filename, string records, NewOptions newOptions, string customVars)
        {
            if (newOptions == null)
                newOptions = new NewOptions();

            string options = newOptions.ToString();
            string inputData = filename + DBMV_Mark.AM + records;

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + inputData;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the Delete operation.
        /// </summary>
        /// <param name="filename">The file name where the records are going to be deleted. DICT in case of deleting a record that belongs to a dictionary.</param>
        /// <param name="records">Buffer of records to be deleted. Use StringFunctions.ComposeDeleteBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="deleteOptions">Object with options to manage how records are deleted, including optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
       /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetDeleteArgs(string filename, string records, DeleteOptions deleteOptions, string customVars)
        {
            if (deleteOptions == null)
                deleteOptions = new DeleteOptions();

            string options = deleteOptions.ToString();
            string inputData = filename + DBMV_Mark.AM + records;

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + inputData;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the Select operation.
        /// </summary>
        /// <param name="filename">Name of file on which the operation is performed. For example LK.ORDERS</param>
        /// <param name="selectClause">Statement fragment specifies the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="sortClause">Statement fragment specifies the selection order. If there is a selection rule, Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="dictClause">Space-delimited list of dictionaries to read. If this list is not set, all fields are returned. For example CUSTOMER DATE ITEM</param>
        /// <param name="preSelectClause">An optional command that executes before the main Select</param>
        /// <param name="selectOptions">Object with options to manage how records are selected, including calculated, dictionaries, conversion, formatSpec, originalRecords, onlyItemId, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetSelectArgs(string filename, string selectClause, string sortClause, string dictClause, string preSelectClause,
            SelectOptions selectOptions, string customVars)
        {
            if (selectOptions == null)
                selectOptions = new SelectOptions();

            string options = selectOptions.ToString();
            string inputData = filename + DBMV_Mark.AM +
                selectClause + DBMV_Mark.AM +
                sortClause + DBMV_Mark.AM +
                dictClause + DBMV_Mark.AM +
                preSelectClause;

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + inputData;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the Subroutine operation.
        /// </summary>
        /// <param name="subroutineName">Name of BASIC subroutine to execute.</param>
        /// <param name="argsNumber">Number of arguments</param>
        /// <param name="arguments">The subroutine arguments list. Use StringFunctions.ComposeSubroutineArgs function to compose this string.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetSubroutineArgs(string subroutineName, int argsNumber, string arguments, string customVars)
        {
            string options = "";
            string inputData1 = subroutineName + DBMV_Mark.AM_str + argsNumber;
            string inputData2 = arguments;
            string inputData = inputData1 + ASCII_Chars.FS_str + inputData2;

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + inputData;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the Conversion operation.
        /// </summary>
        /// <param name="expression">The data or expression to convert. May include MV marks (value delimiters), in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. Must obey the Database conversions specifications.</param>
        /// <param name="conversionOptions">Indicates the conversion type, input or output: INPUT=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetConversionArgs(string expression, string code, CONVERSION_TYPE conversionOptions, string customVars)
        {
            string options = (conversionOptions == CONVERSION_TYPE.INPUT ? "I" : "O");
            string inputData = code + ASCII_Chars.FS_str + expression;

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + inputData;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the Format operation.
        /// </summary>
        /// <param name="expression">The data or expression to format. If multiple values are present, the operation will be performed individually on all values in the expression.</param>
        /// <param name="formatSpec">Specified format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetFormatArgs(string expression, string formatSpec, string customVars)
        {
            string options = "";
            string inputData = formatSpec + ASCII_Chars.FS_str + expression;

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + inputData;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the Dictionaries operation.
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetDictionariesArgs(string filename, string customVars)
        {
            string options = "";

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + filename;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the Execute operation.
        /// </summary>
        /// <param name="statement">The command you want to execute in the Database.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetExecuteArgs(string statement,string customVars)
        {
            string options = "";

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + statement;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the Version operation.
        /// </summary>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetVersionArgs()
        {
            string options = "";

            string cmdArgs = "" + ASCII_Chars.US_str + options + ASCII_Chars.US_str + "";
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the LkSchemas operation.
        /// </summary>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetLkSchemasArgs(LkSchemasOptions lkSchemasOptions, string customVars)
        {
            if (lkSchemasOptions == null)
                lkSchemasOptions = new LkSchemasOptions();
            string options = lkSchemasOptions.ToString();

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + "";
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the LkProperties operation.
        /// </summary>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetLkPropertiesArgs(string filename, LkPropertiesOptions lkPropertiesOptions, string customVars)
        {
            if (lkPropertiesOptions == null)
                lkPropertiesOptions = new LkPropertiesOptions();
            string options = lkPropertiesOptions.ToString();

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + filename;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the GetTable operation.
        /// </summary>
        /// <param name="filename">File or table name defined in Linkar Schemas. Table notation is: MainTable[.MVTable[.SVTable]]</param>
        /// <param name="selectClause">Statement fragment specifies the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="dictClause">Space-delimited list of dictionaries to read. If this list is not set, all fields are returned. For example CUSTOMER DATE ITEM</param>
        /// <param name="sortClause">Statement fragment specifies the selection order. If there is a selection rule Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="tableOptions">Detailed options to be used, including: rowHeaders, rowProperties, onlyVisibe, usePropertyNames, repeatValues, applyConversion, applyFormat, calculated, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetGetTableArgs(string filename, string selectClause, string dictClause, string sortClause, TableOptions tableOptions, string customVars)
        {
            if (tableOptions == null)
                tableOptions = new TableOptions();
            string options = tableOptions.ToString();
            string inputData = filename + DBMV_Mark.AM +
                selectClause + DBMV_Mark.AM +
                dictClause + DBMV_Mark.AM +
                sortClause;

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + inputData;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the ResetCommonBlocks operation.
        /// </summary>
       /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePersistentOperation.</returns>
        public static string GetResetCommonBlocksArgs()
        {
            string options = "";

            string cmdArgs = "" + ASCII_Chars.US_str + options + ASCII_Chars.US_str + "";
            return cmdArgs;
        }
    }
}
