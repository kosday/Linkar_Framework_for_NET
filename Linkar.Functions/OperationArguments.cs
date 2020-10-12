using System;
using System.Collections.Generic;
using System.Text;

namespace Linkar
{
    /// <summary>
    /// Auxiliary static class with functions to obtain the 3 items of every LinkarSERVER operation.
    /// These items are: CUSTOMVARS, OPTIONS and INPUTDATA.
    /// Unit Separator character (31) is used as separator between these items.
    /// CUSTOMVARS: String for database custom subroutines.
    /// OPTIONS: The options of every operation.
    /// INPUT: The necessary data for perform every operation.
    /// CUSTOMVARS US_char OPTIONS US_char INPUT
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
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
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
        /// <param name="records">Buffer of record data to update. Inside this string are the recordIds, the modified records, and the originalRecords. Use the StringFunctions.ComposeUpdateBuffer function to compose this string.</param>
        /// <param name="updateOptions">Object that defines the different writing options of the Function: optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
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
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the New operation.
        /// </summary>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Are the records you want to write. Inside this string are the recordIds, and the records. Use StringFunctions.ComposeNewBuffer function to compose this string.</param>
        /// <param name="newOptions">Object that defines the following writing options of the Function: recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
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
        /// <param name="records">The records list to be deleted. Use StringFunctions.ComposeDeleteBuffer function to compose this string.</param>
        /// <param name="deleteOptions">Object that defines the different Function options: optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
       /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
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
        /// <param name="selectOptions">Object that defines the different reading options of the Function: calculated, dictionaries, conversion, formatSpec, originalRecords, onlyItemId, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
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
        /// <param name="subroutineName">Subroutine name you want to execute.</param>
        /// <param name="argsNumber">Number of arguments</param>
        /// <param name="arguments">The subroutine arguments list. Use StringFunctions.ComposeSubroutineArgs function to compose this string.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
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
        /// <param name="expression">The data or expression to convert. It can have MV marks, in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. It will have to obey the Database conversions specifications.</param>
        /// <param name="conversionOptions">Indicates the conversion type, input or output: INPUT=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
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
        /// <param name="expression">The data or expression to format. It can contain MV marks, in which case the conversion in each value will be executed according to the original MV mark.</param>
        /// <param name="formatSpec">Specified format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
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
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
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
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
        public static string GetExecuteArgs(string statement,string customVars)
        {
            string options = "";

            string cmdArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + statement;
            return cmdArgs;
        }

        /// <summary>
        /// Compose the 3 items (CUSTOMVARS, OPTIONS and INPUTDATA) of the Version operation.
        /// </summary>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
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
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
        public static string GetLkSchemasArgs(LkSchemasOptions lkSchemasOptions, string customVars)
        {
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
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
        public static string GetLkPropertiesArgs(string filename, LkPropertiesOptions lkPropertiesOptions, string customVars)
        {
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
        /// <param name="tableOptions">Different function options: rowHeaders, rowProperties, onlyVisibe, usePropertyNames, repeatValues, applyConversion, applyFormat, calculated, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
        public static string GetGetTableArgs(string filename, string selectClause, string dictClause, string sortClause, TableOptions tableOptions, string customVars)
        {
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
       /// <returns>A string ready to be used in Linkar.ExecuteDirectOperation and Linkar.ExecutePermanentOperation.</returns>
        public static string GetResetCommonBlocksArgs()
        {
            string options = "";

            string cmdArgs = "" + ASCII_Chars.US_str + options + ASCII_Chars.US_str + "";
            return cmdArgs;
        }
    }
}
