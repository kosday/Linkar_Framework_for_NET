namespace Linkar.Functions.Direct
{
    /// <summary>
    /// Linkar.Functions.Direct library namespace.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc
    {
        // Dummy class necessary for SandCastle can generate doc about namespace
    }

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
        /// <param name="dictionaries">List of dictionaries to read, separated by space. If this list is not set, all fields are returned. You may use the format LKFLDx where x is the attribute number.</param>
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
        /// <param name="records">Buffer of record data to update. Inside this string are the recordIds, the modified records, and the originalRecords. Use StringFunctions.ComposeUpdateBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="updateOptions">Object with write options, including optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the resultant writing data: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// Inside the records argument, the recordIds and the modified records always must be specified. But the originalRecords not always.
        /// When <see cref="UpdateOptions">updateOptions</see> argument is specified and the <see cref="UpdateOptions.OptimisticLockControl"/> property is set to true, a copy of the record must be provided before the modification (originalRecords argument)
        /// to use the Optimistic Lock technique. This copy can be obtained from a previous <see cref="Read"/> operation. The database, before executing the modification, 
        /// reads the record and compares it with the copy in originalRecords, if they are equal the modified record is executed.
        /// But if they are not equal, it means that the record has been modified by other user and its modification will not be saved.
        /// The record will have to be read, modified and saved again.
        /// </remarks>
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
        /// Update one or more attributes of one or more file records, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Buffer of record data to update. Inside this string are the recordIds, the modified records, and the originalRecords. Use StringFunctions.ComposeUpdateBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="dictionaries">List of dictionaries to write, separated by space. In MV output format is mandatory. You may use the format LKFLDx where x is the attribute number.</param>
        /// <param name="updateOptions">Object with write options, including optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the resultant writing data: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// Inside the records argument, the recordIds and the modified records always must be specified. But the originalRecords not always.
        /// When <see cref="UpdateOptions">updateOptions</see> argument is specified and the <see cref="UpdateOptions.OptimisticLockControl"/> property is set to true, a copy of the record must be provided before the modification (originalRecords argument)
        /// to use the Optimistic Lock technique. This copy can be obtained from a previous <see cref="Read"/> operation. The database, before executing the modification, 
        /// reads the record and compares it with the copy in originalRecords, if they are equal the modified record is executed.
        /// But if they are not equal, it means that the record has been modified by other user and its modification will not be saved.
        /// The record will have to be read, modified and saved again.
        /// </remarks>
        public static string UpdatePartial(CredentialOptions credentialOptions, string filename, string records, string dictionaries = "", UpdateOptions updateOptions = null,
            DATAFORMAT_TYPE inputFormat = DATAFORMAT_TYPE.MV, DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string updateArgs = OperationArguments.GetUpdatePartialArgs(filename, records, dictionaries, updateOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.UPDATEPARTIAL;
            byte byteInputFormat = (byte)inputFormat;
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, updateArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Creates one or several records of a file, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">The file name where the records are going to be created.</param>
        /// <param name="records">Buffer of records to write. Inside this string are the recordIds, and the records. Use StringFunctions.ComposeNewBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="newOptions">Object with write options for the new record(s), including recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the resultant writing data: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// Inside the records argument, the records always must be specified. But the recordIds only must be specified when <see cref="NewOptions"/> argument is null, or when the <see cref="RecordIdType"/> argument of the <see cref="NewOptions"/> constructor is null.
        /// </remarks>
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
        /// <param name="records">Buffer of records to be deleted. Use StringFunctions.ComposeDeleteBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="deleteOptions">Object with options to manage how records are deleted, including optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the resultant writing data: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// Inside the records argument, the recordIds always must be specified. But the originalRecords not always.
        /// When <see cref="DeleteOptions">deleteOptions</see> argument is specified and the <see cref="DeleteOptions.OptimisticLockControl"/> property is set to true,
        /// a copy of the record must be provided before the deletion to use the Optimistic Lock technique.
        /// This copy can be obtained from a previous <see cref="Read"/> operation. The database, before executing the deletion, 
        /// reads the record and compares it with the copy in originalRecords, if they are equal the record is deleted.
        /// But if they are not equal, it means that the record has been modified by other user and the record will not be deleted.
        /// The record will have to be read, and deleted again.
        /// </remarks>
        public static string Delete(CredentialOptions credentialOptions, string filename, string records, DeleteOptions deleteOptions = null,
            DATAFORMAT_TYPE inputFormat = DATAFORMAT_TYPE.MV, DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string deleteArgs = OperationArguments.GetDeleteArgs(filename, records, deleteOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.DELETE;
            byte byteInputFormat = (byte)inputFormat;
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
        /// <param name="dictClause">Space-delimited list of dictionaries to read. If this list is not set, all fields are returned. For example CUSTOMER DATE ITEM. You may use the format LKFLDx where x is the attribute number.</param>
        /// <param name="preSelectClause">An optional command that executes before the main Select</param>
        /// <param name="selectOptions">Object with options to manage how records are selected, including calculated, dictionaries, conversion, formatSpec, originalRecords, onlyItemId, pagination, regPage, numPage.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// In the preSelectClause argument these operations can be carried out before executing the Select statement:
        ///  <list type="bullet">
        ///   <item>Previously call to a saved list with the GET.LIST command to use it in the Main Select input</item>
        ///   <item>Make a previous Select to use the result as the Main Select input, with the SELECT or SSELECT commands.In this case the entire sentence must be indicated in the PreselectClause. For example:SSELECT LK.ORDERS WITH CUSTOMER = '1'</item>
        ///   <item>Exploit a Main File index to use the result as a Main Select input, with the SELECTINDEX command. The syntax for all the databases is SELECTINDEX index.name.value. For example SELECTINDEX ITEM,"101691"</item>
        /// </list>
        /// </remarks>
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
        /// <param name="argsNumber">Number of arguments.</param>
        /// <param name="arguments">The subroutine arguments list. Each argument is a substring separated with the ASCII char DC4 (20).</param>
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
        /// <param name="conversionType">Indicates the conversion type, input or output: INPUT=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="expression">The data or expression to convert. May include MV marks (value delimiters), in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. Must obey the Database conversions specifications.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string Conversion(CredentialOptions credentialOptions, string expression, string code, CONVERSION_TYPE conversionType,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string conversionArgs = OperationArguments.GetConversionArgs(expression, code, conversionType, customVars);
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
        /// <remarks>
        /// This function returns the following information
        /// <list type="definition">
        /// <item><term>LKMVCOMPONENTSVERSION</term><description>MV Components version.</description></item>
        /// <item><term>LKSERVERVERSION</term><description>Linkar SERVER version.</description></item>
        /// <item><term>LKCLIENTVERSION</term><description>Used client library version.</description></item>
        /// <item><term>DATABASE</term><description>Database.</description></item>
        /// <item><term>OS</term><description>Operating system.</description></item>
        /// <item><term>DATEZERO</term><description>Date zero base in YYYYMMDD format.</description></item>
        /// <item><term>DATEOUTPUTCONVERSION</term><description>Output conversion for date used by Linkar Schemas.</description></item>
        /// <item><term>TIMEOUTPUTCONVERSION</term><description>Output conversion for time used by Linkar Schemas.</description></item>
        /// <item><term>MVDATETIMESEPARATOR</term><description>DateTime used separator used by Linkar Schemas, for instance 18325,23000.</description></item>
        /// <item><term>MVBOOLTRUE</term><description>Database used char for the Boolean true value used by Linkar Schemas.</description></item>
        /// <item><term>MVBOOLFALSE</term><description>Database used char for the Boolean false value used by Linkar Schemas.</description></item>
        /// <item><term>OUTPUTBOOLTRUE</term><description>Used char for the Boolean true value out of the database used by Linkar Schemas.</description></item>
        /// <item><term>OUTPUTBOOLFALSE</term><description>Used char for the Boolean false value out of the database used by Linkar Schemas.</description></item>
        /// <item><term>MVDECIMALSEPARATOR</term><description>Decimal separator in the database. May be point, comma or none when the database does not store decimal numbers. Used by Linkar Schemas.</description></item>
        /// <item><term>OTHERLANGUAGES</term><description>Languages list separated by commas.</description></item>
        /// <item><term>TABLEROWSEPARATOR</term><description>It is the decimal char that you use to separate the rows in the output table format. By default 11.</description></item>
        /// <item><term>TABLECOLSEPARATOR</term><description>It is the decimal char that you use to separate the columns in the output table format. By default 9.</description></item>
        /// <item><term>CONVERTNUMBOOLJSON</term><description>Switch to create numeric and boolean data in JSON strings. Default is false.</description></item>
        /// </list>
        /// </remarks>
        /// <seealso href="http://kosday.com/Manuals/en_web_linkar/lk_schemas_ep_parameters.html">Schemas Parameter</seealso>
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
        /// <param name="credential0Options">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML, JSON or TABLE.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// TABLE output format uses the defined control characters in <see href="http://kosday.com/Manuals/en_web_linkar/lk_schemas_ep_parameters.html">EntryPoints Parameters</see> Table Row Separator and Column Row Separator.
        /// <para>By default:
        /// <list type="bullet">
        /// <item>TAB char (9) for columns.</item>
        /// <item>VT char (11) for rows.</item>
        /// </list>
        /// </para>
        /// </remarks>
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
        /// <param name="filename">File name to LkProperties.</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT, JSON_SCH or TABLE.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// TABLE output format uses the defined control characters in <see href="http://kosday.com/Manuals/en_web_linkar/lk_schemas_ep_parameters.html">EntryPoints Parameters</see> Table Row Separator and Column Row Separator.
        /// <para>By default:
        /// <list type="bullet">
        /// <item>TAB char (9) for columns.</item>
        /// <item>VT char (11) for rows.</item>
        /// </list>
        /// </para>
        /// </remarks>
        public static string LkProperties(CredentialOptions credentialOptions, string filename, LkPropertiesOptions lkPropertiesOptions = null,
            DATAFORMATSCHPROP_TYPE outputFormat = DATAFORMATSCHPROP_TYPE.MV,
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
        /// <param name="dictClause">Space-delimited list of dictionaries to read. If this list is not set, all fields are returned. For example CUSTOMER DATE ITEM. In NONE mode you may use the format LKFLDx where x is the attribute number.</param>
        /// <param name="sortClause">Statement fragment specifies the selection order. If there is a selection rule Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="tableOptions">Detailed options to be used, including: rowHeaders, rowProperties, onlyVisibe, usePropertyNames, repeatValues, applyConversion, applyFormat, calculated, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// TABLE output format uses the defined control characters in <see href="http://kosday.com/Manuals/en_web_linkar/lk_schemas_ep_parameters.html">EntryPoints Parameters</see> Table Row Separator and Column Row Separator.
        /// <para>By default:
        /// <list type="bullet">
        /// <item>TAB char (9) for columns.</item>
        /// <item>VT char (11) for rows.</item>
        /// </list>
        /// </para>
        /// </remarks>
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
        /// Resets the COMMON variables with the 100 most used files, synchronously only.
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
            byte byteOutputFormat = (byte)outputFormat;
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, resetCommonBlocksArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }
    }
}
