using System;

namespace Linkar.Functions.Direct
{
    /// <summary>
    /// These functions perform synchronous direct (without establishing permanent session) operations with any kind of output format type.
    /// </summary>
    public static class DirectFunctions
    {
        /// <summary>
        /// Reads one or several records of a file in synchronous way.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name to read.</param>
        /// <param name="recordIds">A list of item IDs to read, separated by the Record Separator character (30). Use StringFunctions.ComposeRecordIds to compose this string</param>
        /// <param name="dictionaries">List of dictionaries to read, separated by space. If this list is not set, all fields are returned.</param>
        /// <param name="readOptions">Object that defines the different reading options of the Function: Calculated, dictClause, conversion, formatSpec, originalRecords.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the record ids: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string Read(CredentialOptions credentialOptions, string filename, string recordIds, string dictionaries = "", ReadOptions readOptions = null,
             DATAFORMAT_TYPE inputFormat = DATAFORMAT_TYPE.MV, DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV, string customVars = "", int receiveTimeout = 0)
        {
            string readArgs = OperationArguments.GetReadArgs(filename, recordIds, dictionaries, readOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.READ;
            byte byteInputFormat = (byte)inputFormat;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, readArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Update one or several records of a file, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Buffer of record data to update. Inside this string are the recordIds, the modified records, and the originalRecords. Use the StringFunctions.ComposeUpdateBuffer function to compose this string.</param>
        /// <param name="updateOptions">Object with write options, including optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the resultant writing data: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string Update(CredentialOptions credentialOptions, string filename, string records, UpdateOptions updateOptions = null,
            DATAFORMAT_TYPE inputFormat = DATAFORMAT_TYPE.MV, DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string updateArgs = OperationArguments.GetUpdateArgs(filename, records, updateOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.UPDATE;
            byte byteInputFormat = (byte)inputFormat;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, updateArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Creates one or several records of a file, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Buffer of records to write. Inside this string are the recordIds, and the records. Use StringFunctions.ComposeNewBuffer function to compose this string.</param>
        /// <param name="newOptions">Object with write options for the new record(s), including recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the resultant writing data: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string New(CredentialOptions credentialOptions, string filename, string records, NewOptions newOptions = null,
            DATAFORMAT_TYPE inputFormat = DATAFORMAT_TYPE.MV, DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string newArgs = OperationArguments.GetNewArgs(filename, records, newOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.NEW;
            byte byteInputFormat = (byte)inputFormat;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, newArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Deletes one or several records in file, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">The file name where the records are going to be deleted. DICT in case of deleting a record that belongs to a dictionary.</param>
        /// <param name="records">Buffer of records to be deleted. Use StringFunctions.ComposeDeleteBuffer function to compose this string.</param>
        /// <param name="deleteOptions">Object with options to manage how records are deleted, including optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string Delete(CredentialOptions credentialOptions, string filename, string records, DeleteOptions deleteOptions = null,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string deleteArgs = OperationArguments.GetDeleteArgs(filename, records, deleteOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.DELETE;
            byte byteInputFormat = (byte)DATAFORMATCRU_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, deleteArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Executes a Query in the Database, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">Name of file on which the operation is performed. For example LK.ORDERS</param>
        /// <param name="selectClause">Statement fragment specifies the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="sortClause">Statement fragment specifies the selection order. If there is a selection rule, Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="dictClause">Space-delimited list of dictionaries to read. If this list is not set, all fields are returned. For example CUSTOMER DATE ITEM</param>
        /// <param name="preSelectClause">An optional command that executes before the main Select</param>
        /// <param name="selectOptions">Object with options to manage how records are selected, including calculated, dictionaries, conversion, formatSpec, originalRecords, onlyItemId, pagination, regPage, numPage.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string Select(CredentialOptions credentialOptions, string filename, string selectClause = "", string sortClause = "", string dictClause = "", string preSelectClause = "", SelectOptions selectOptions = null,
            DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string selectArgs = OperationArguments.GetSelectArgs(filename, selectClause, sortClause, dictClause, preSelectClause, selectOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.SELECT;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, selectArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Executes a subroutine, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="subroutineName">Name of BASIC subroutine to execute.</param>
        /// <param name="argsNumber">Number of arguments</param>
        /// <param name="arguments">The subroutine arguments list.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the subroutine arguments: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string Subroutine(CredentialOptions credentialOptions, string subroutineName, int argsNumber, string arguments,
            DATAFORMAT_TYPE inputFormat = DATAFORMAT_TYPE.MV, DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string subroutineArgs = OperationArguments.GetSubroutineArgs(subroutineName, argsNumber, arguments, customVars);
            byte opCode = (byte)OPERATION_CODE.SUBROUTINE;
            byte byteInputFormat = (byte)inputFormat;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, subroutineArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns the result of executing ICONV() or OCONV() functions from a expression list in the Database, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="conversionOptions">Indicates the conversion type, input or output: INPUT=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="expression">The data or expression to convert. May include MV marks (value delimiters), in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. Must obey the Database conversions specifications.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string Conversion(CredentialOptions credentialOptions, string expression, string code, CONVERSION_TYPE conversionOptions,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string conversionArgs = OperationArguments.GetConversionArgs(expression, code, conversionOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.CONVERSION;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, conversionArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns the result of executing the FMT function in a expressions list in the Database, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="expression">The data or expression to format. If multiple values are present, the operation will be performed individually on all values in the expression.</param>
        /// <param name="formatSpec">Specified format</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string Format(CredentialOptions credentialOptions, string expression, string formatSpec,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string formatArgs = OperationArguments.GetFormatArgs(expression, formatSpec, customVars);
            byte opCode = (byte)OPERATION_CODE.FORMAT;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, formatArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns all the dictionaries of a file, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string Dictionaries(CredentialOptions credentialOptions, string filename,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string dictionariesArgs = OperationArguments.GetDictionariesArgs(filename, customVars);
            byte opCode = (byte)OPERATION_CODE.DICTIONARIES;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, dictionariesArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Allows the execution of any command from the Database synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="statement">The command you want to execute in the Database.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string Execute(CredentialOptions credentialOptions, string statement,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string executeArgs = OperationArguments.GetExecuteArgs(statement, customVars);
            byte opCode = (byte)OPERATION_CODE.EXECUTE;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, executeArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Allows getting the client version.
        /// </summary>
        /// <returns>The results of the operation.</returns>
        public static string GetLocalVersion()
        {
            return Linkar.ClientVersion;
        }

        /// <summary>
        /// Allows getting the server version, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string GetVersion(CredentialOptions credentialOptions, DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV, int receiveTimeout = 0)
        {
            string versionArgs = OperationArguments.GetVersionArgs();
            byte opCode = (byte)OPERATION_CODE.VERSION;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, versionArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML, JSON or TABLE.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string LkSchemas(CredentialOptions credentialOptions, LkSchemasOptions lkSchemasOptions = null,
             DATAFORMATSCH_TYPE outputFormat = DATAFORMATSCH_TYPE.MV,
             string customVars = "", int receiveTimeout = 0)
        {
            string lkSchemasArgs = OperationArguments.GetLkSchemasArgs(lkSchemasOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.LKSCHEMAS;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, lkSchemasArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML, JSON or TABLE.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string LkProperties(CredentialOptions credentialOptions, string filename, LkPropertiesOptions lkPropertiesOptions = null,
            DATAFORMATSCH_TYPE outputFormat = DATAFORMATSCH_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string lkPropertiesArgs = OperationArguments.GetLkPropertiesArgs(filename, lkPropertiesOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.LKPROPERTIES;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, lkPropertiesArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns a query result in a table format, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File or table name defined in Linkar Schemas. Table notation is: MainTable[.MVTable[.SVTable]]</param>
        /// <param name="selectClause">Statement fragment specifies the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="dictClause">Space-delimited list of dictionaries to read. If this list is not set, all fields are returned. For example CUSTOMER DATE ITEM</param>
        /// <param name="sortClause">Statement fragment specifies the selection order. If there is a selection rule Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="tableOptions">Detailed options to be used, including: rowHeaders, rowProperties, onlyVisibe, usePropertyNames, repeatValues, applyConversion, applyFormat, calculated, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string GetTable(CredentialOptions credentialOptions, string filename, string selectClause = "", string dictClause = "", string sortClause = "",
            TableOptions tableOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            string getTableArgs = OperationArguments.GetGetTableArgs(filename, selectClause, dictClause, sortClause, tableOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.GETTABLE;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)DATAFORMATSCH_TYPE.TABLE;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, getTableArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Resets the COMMON variables with the 100 most used files in a asynchronous way.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string ResetCommonBlocks(CredentialOptions credentialOptions, DATAFORMAT_TYPE outputFormat, int receiveTimeout = 0)
        {
            string resetCommonBlocksArgs = OperationArguments.GetResetCommonBlocksArgs();
            byte opCode = (byte)OPERATION_CODE.RESETCOMMONBLOCKS;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)DATAFORMAT_TYPE.MV;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, resetCommonBlocksArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }
    }
}
