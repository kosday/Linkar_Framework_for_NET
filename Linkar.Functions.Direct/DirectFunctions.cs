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
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name to read.</param>
        /// <param name="recordIds">It's the records codes list to read, separated by the Record Separator character (30). Use StringFunctions.ComposeRecordIds to compose this string</param>
        /// <param name="dictionaries">List of dictionaries to read, separated by space. If dictionaries are not indicated the function will read the complete buffer.</param>
        /// <param name="readOptions">Object that defines the different reading options of the Function: Calculated, dictClause, conversion, formatSpec, originalRecords.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">'s a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Read(CredentialOptions credentialsOptions, string filename, string recordIds, string dictionaries = "", ReadOptions readOptions = null,
            DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV, string customVars = "", int receiveTimeout = 0)
        {
            string readArgs = OperationArguments.GetReadArgs(filename, recordIds, dictionaries, outputFormat, readOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.READ;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, readArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Update one or several records of a file, in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name where you are going to write.</param>
        /// <param name="records">Are the records you want to update. Inside this string are the recordIds, the records, and the originalRecords. Use StringFunctions.ComposeUpdateBuffer function to compose this string.</param>
        /// <param name="updateOptions">Object that defines the different writing options of the Function: optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the resultant writing data: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Update(CredentialOptions credentialsOptions, string filename, string records, UpdateOptions updateOptions = null,
            DATAFORMAT_TYPE inputFormat = DATAFORMAT_TYPE.MV, DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string updateArgs = OperationArguments.GetUpdateArgs(filename, records, updateOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.UPDATE;
            byte byteInputFormat = (byte)inputFormat;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, updateArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Creates one or several records of a file, in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name where you are going to write.</param>
        /// <param name="records">Are the records you want to write. Inside this string are the recordIds, and the records. Use StringFunctions.ComposeNewBuffer function to compose this string.</param>
        /// <param name="newOptions">Object that defines the following writing options of the Function: recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the resultant writing data: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string New(CredentialOptions credentialsOptions, string filename, string records, NewOptions newOptions = null,
            DATAFORMAT_TYPE inputFormat = DATAFORMAT_TYPE.MV, DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string newArgs = OperationArguments.GetNewArgs(filename, records, newOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.NEW;
            byte byteInputFormat = (byte)inputFormat;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, newArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Deletes one or several records in file, in a synchronous way
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">It's the file name where the records are going to be deleted. DICT in case of deleting a record that belongs to a dictionary.</param>
        /// <param name="records">It's the records list to be deleted. Use StringFunctions.ComposeDeleteBuffer function to compose this string.</param>
        /// <param name="deleteOptions">Object that defines the different Function options: optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Delete(CredentialOptions credentialsOptions, string filename, string records, DeleteOptions deleteOptions = null,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string deleteArgs = OperationArguments.GetDeleteArgs(filename, records, deleteOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.DELETE;
            byte byteInputFormat = (byte)DATAFORMATCRU_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, deleteArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Executes a Query in the Database, in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name where the select operation will be perform. For example LK.ORDERS</param>
        /// <param name="selectClause">Fragment of the phrase that indicate the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="sortClause">Fragment of the phrase that indicates the selection order. If there is a selection rule, Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="dictClause">Is the list of dictionaries to read, separated by space. If dictionaries are not indicated the function will read the complete buffer. For example CUSTOMER DATE ITEM</param>
        /// <param name="preSelectClause">It's an optional statement that will execute before the main Select</param>
        /// <param name="selectOptions">Object that defines the different reading options of the Function: calculated, dictionaries, conversion, formatSpec, originalRecords, onlyItemId, pagination, regPage, numPage.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Select(CredentialOptions credentialsOptions, string filename, string selectClause = "", string sortClause = "", string dictClause = "", string preSelectClause = "", SelectOptions selectOptions = null,
            DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string selectArgs = OperationArguments.GetSelectArgs(filename, selectClause, sortClause, dictClause, preSelectClause, selectOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.SELECT;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, selectArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Executes a subroutine, in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="subroutineName">Subroutine name you want to execute.</param>
        /// <param name="argsNumber">Number of arguments</param>
        /// <param name="arguments">The subroutine arguments list.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Subroutine(CredentialOptions credentialsOptions, string subroutineName, int argsNumber, string arguments,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string subroutineArgs = OperationArguments.GetSubroutineArgs(subroutineName, argsNumber, arguments, customVars);
            byte opCode = (byte)OPERATION_CODE.SUBROUTINE;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, subroutineArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns the result of executing ICONV() or OCONV() functions from a expression list in the Database, in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="conversionOptions">Indicates the conversion type, input or output: Input=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="expression">The data or expression to convert. It can have MV marks, in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. It will have to obey the Database conversions specifications.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Conversion(CredentialOptions credentialsOptions, string expression, string code, CONVERSION_TYPE conversionOptions,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string conversionArgs = OperationArguments.GetConversionArgs(code, expression, conversionOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.CONVERSION;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, conversionArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns the result of executing the FMT function in a expressions list in the Database, in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="expression">The data or expression to format. It can contain MV marks, in which case the conversion in each value will be executed according to the original MV mark.</param>
        /// <param name="formatSpec">Specified format</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Format(CredentialOptions credentialsOptions, string expression, string formatSpec,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string formatArgs = OperationArguments.GetFormatArgs(formatSpec, expression, customVars);
            byte opCode = (byte)OPERATION_CODE.FORMAT;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, formatArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns all the dictionaries of a file, in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Dictionaries(CredentialOptions credentialsOptions, string filename,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string dictionariesArgs = OperationArguments.GetDictionariesArgs(filename, customVars);
            byte opCode = (byte)OPERATION_CODE.DICTIONARIES;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, dictionariesArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Allows the execution of any command from the Database in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="statement">The command you want to execute in the Database.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Execute(CredentialOptions credentialsOptions, string statement,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string executeArgs = OperationArguments.GetExecuteArgs(statement, customVars);
            byte opCode = (byte)OPERATION_CODE.EXECUTE;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, executeArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Allows making different operations, through some templates in standar format (XML, JSON), in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="commandFormat">Indicates in what format you are doing the operation: XML or JSON.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string SendCommand(CredentialOptions credentialsOptions, string command, ENVELOPE_FORMAT commandFormat = ENVELOPE_FORMAT.XML, int receiveTimeout = 0)
        {
            string sendCommandArgs = OperationArguments.GetSendCommandArgs(command);
            byte opCode;
            if (commandFormat == ENVELOPE_FORMAT.JSON)
                opCode = (byte)OPERATION_CODE.COMMAND_JSON;
            else
                opCode = (byte)OPERATION_CODE.COMMAND_XML;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)DATAFORMAT_TYPE.MV;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, sendCommandArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
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
        /// Allows getting the server version, in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string GetVersion(CredentialOptions credentialsOptions, DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV, int receiveTimeout = 0)
        {
            string versionArgs = OperationArguments.GetVersionArgs();
            byte opCode = (byte)OPERATION_CODE.VERSION;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, versionArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML, JSON or TABLE.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string LkSchemas(CredentialOptions credentialsOptions, LkSchemasOptions lkSchemasOptions = null,
             DATAFORMATSCH_TYPE outputFormat = DATAFORMATSCH_TYPE.MV,
             string customVars = "", int receiveTimeout = 0)
        {
            string lkSchemasArgs = OperationArguments.GetLkSchemasArgs(lkSchemasOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.LKSCHEMAS;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, lkSchemasArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML, JSON or TABLE.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string LkProperties(CredentialOptions credentialsOptions, string filename, LkPropertiesOptions lkPropertiesOptions = null,
            DATAFORMATSCH_TYPE outputFormat = DATAFORMATSCH_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string lkPropertiesArgs = OperationArguments.GetLkPropertiesArgs(filename, lkPropertiesOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.LKPROPERTIES;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, lkPropertiesArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns a query result in a table format, in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File or table name defined in Linkar Schemas. Table notation is: MainTable[.MVTable[.SVTable]]</param>
        /// <param name="selectClause">Fragment of the phrase that indicate the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="dictClause">Is the list of dictionaries to read, separated by space. If dictionaries are not indicated the function will read the complete buffer. For example CUSTOMER DATE ITEM</param>
        /// <param name="sortClause">Fragment of the phrase that indicates the selection order. If there is a selection rule Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="tableOptions">Different function options: rowHeaders, rowProperties, onlyVisibe, usePropertyNames, repeatValues, applyConversion, applyFormat, calculated, pagination, regPage, numPage.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string GetTable(CredentialOptions credentialsOptions, string filename, string selectClause = "", string dictClause = "", string sortClause = "",
            TableOptions tableOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            string getTableArgs = OperationArguments.GetGetTableArgs(filename, selectClause, dictClause, sortClause, tableOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.GETTABLE;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)DATAFORMAT_TYPE.MV;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, getTableArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Resets the COMMON variables with the 100 most used files in a asynchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string ResetCommonBlocks(CredentialOptions credentialsOptions, DATAFORMAT_TYPE outputFormat, int receiveTimeout = 0)
        {
            string resetCommonBlocksArgs = OperationArguments.GetResetCommonBlocksArgs();
            byte opCode = (byte)OPERATION_CODE.RESETCOMMONBLOCKS;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)DATAFORMAT_TYPE.MV;
            string result = Linkar.ExecuteDirectOperation(credentialsOptions.ToString(), opCode, resetCommonBlocksArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }
    }
}
