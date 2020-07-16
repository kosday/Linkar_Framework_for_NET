namespace Linkar.Functions.Direct
{
    /// <summary>
    /// These functions perform synchronous and asynchronous direct (without establishing permanent session) operations with output format type XML.
    /// </summary>
    public static partial class XmlFunctions
    {
        /// <summary>
        /// XML output formats for Read, Update, New and Select
        /// </summary>
        public enum XML_FORMAT {
            /// <summary>
            /// Show the results of the operation in XML format.
            /// </summary>
            XML = 2,

            /// <summary>
            /// Show the results of the operation in XML_DICT format, using the dictionaries.
            /// </summary>
            XML_DICT = 5,

            /// <summary>
            /// Show the results of the operation in XML_SCH format, using the schema properties.
            /// </summary>
            XML_SCH = 6 }

        /// <summary>
        /// Reads one or several records of a file in a synchronous way with XML output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name to read.</param>
        /// <param name="records">The records codes list to read, separated by the Record Separator character (30). Use StringFunctions.ComposeRecordIds to compose this string</param>
        /// <param name="dictionaries">List of dictionaries to read, separated by space. If dictionaries are not indicated the function will read the complete buffer.</param>
        /// <param name="readOptions">Object that defines the different reading options of the Function: Calculated, dictClause, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">'s a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Read(CredentialOptions credentialOptions, string filename, string records, string dictionaries = "", ReadOptions readOptions = null,
            XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Read(credentialOptions, filename, records, dictionaries, readOptions, (DATAFORMATCRU_TYPE)xmlFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Update one or several records of a file, in a synchronous way with XML input and output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name where you are going to write.</param>
        /// <param name="records">The records to be updated. Inside this string are the recordIds, the records, and the originalRecords. Use StringFunctions.ComposeUpdateBuffer function to compose this string.</param>
        /// <param name="updateOptions">Object that defines the different writing options of the Function: optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Update(CredentialOptions credentialOptions, string filename, string records, UpdateOptions updateOptions = null,
            XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Update(credentialOptions, filename, records, updateOptions, DATAFORMAT_TYPE.XML, (DATAFORMATCRU_TYPE)xmlFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Creates one or several records of a file, in a synchronous way with XML input and output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name where you are going to write.</param>
        /// <param name="records">The records to be written. Inside this string are the recordIds, and the records. Use StringFunctions.ComposeNewBuffer function to compose this string.</param>
        /// <param name="newOptions">Object that defines the following writing options of the Function: recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string New(CredentialOptions credentialOptions, string filename, string records, NewOptions newOptions = null,
            XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.New(credentialOptions, filename, records, newOptions, DATAFORMAT_TYPE.XML, (DATAFORMATCRU_TYPE)xmlFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Deletes one or several records in file, in a synchronous way with XML output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">The file name where the records are going to be deleted. DICT in case of deleting a record that belongs to a dictionary.</param>
        /// <param name="records">The records list to be deleted. Use StringFunctions.ComposeDeleteBuffer function to compose this string.</param>
        /// <param name="deleteOptions">Object that defines the different Function options: optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Delete(CredentialOptions credentialOptions, string filename, string records, DeleteOptions deleteOptions = null,
        string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Delete(credentialOptions, filename, records, deleteOptions, DATAFORMAT_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Executes a Query in the Database, in a synchronous way with XML output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name where the select operation will be perform. For example LK.ORDERS</param>
        /// <param name="selectClause">Fragment of the phrase that indicate the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="sortClause">Fragment of the phrase that indicates the selection order. If there is a selection rule, Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="dictClause">Is the list of dictionaries to read, separated by space. If dictionaries are not indicated the function will read the complete buffer. For example CUSTOMER DATE ITEM</param>
        /// <param name="preSelectClause">An optional statement that will execute before the main Select</param>
        /// <param name="selectOptions">Object that defines the different reading options of the Function: calculated, dictionaries, conversion, formatSpec, originalRecords, onlyItemId, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Select(CredentialOptions credentialOptions, string filename, string selectClause = "", string sortClause = "", string dictClause = "", string preSelectClause = "", SelectOptions selectOptions = null,
        XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Select(credentialOptions, filename, selectClause, sortClause, dictClause, preSelectClause, selectOptions, (DATAFORMATCRU_TYPE)xmlFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Executes a subroutine, in a synchronous way with XML output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="subroutineName">Subroutine name to execute.</param>
        /// <param name="argsNumber">Number of arguments</param>
        /// <param name="arguments">The subroutine arguments list.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Subroutine(CredentialOptions credentialOptions, string subroutineName, int argsNumber, string arguments,
        string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Subroutine(credentialOptions, subroutineName, argsNumber, arguments, DATAFORMAT_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the result of executing ICONV() or OCONV() functions from a expression list in the Database, in a synchronous way with XML output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="conversionOptions">Indicates the conversion type, input or output: Input=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="expression">The data or expression to convert. It can have MV marks, in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. It will have to obey the Database conversions specifications.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Conversion(CredentialOptions credentialOptions, CONVERSION_TYPE conversionOptions, string expression, string code,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Conversion(credentialOptions, expression, code, conversionOptions, DATAFORMAT_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the result of executing the FMT function in a expressions list in the Database, in a synchronous way with XML output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="expression">The data or expression to format. It can contain MV marks, in which case the conversion in each value will be executed according to the original MV mark.</param>
        /// <param name="formatSpec">Specified format</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Format(CredentialOptions credentialOptions, string expression, string formatSpec,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Format(credentialOptions, expression, formatSpec, DATAFORMAT_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns all the dictionaries of a file, in a synchronous way with XML output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Dictionaries(CredentialOptions credentialOptions, string filename,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Dictionaries(credentialOptions, filename, DATAFORMAT_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Allows the execution of any command from the Database in a synchronous way with XML output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="statement">The command to execute in the Database.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string Execute(CredentialOptions credentialOptions, string statement,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Execute(credentialOptions, statement, DATAFORMAT_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Allows getting the server version, in a synchronous way with XML output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string GetVersion(CredentialOptions credentialOptions, int receiveTimeout = 0)
        {
            return DirectFunctions.GetVersion(credentialOptions, DATAFORMAT_TYPE.XML, receiveTimeout);
        }

        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, in a synchronous way with XML output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="lkSchemaOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMA, SQLMODE or DICTIONARY.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string LkSchemas(CredentialOptions credentialOptions, LkSchemaOptions lkSchemaOptions = null,
             string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.LkSchemas(credentialOptions, lkSchemaOptions, DATAFORMATSCH_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, in a synchronous way with XML output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMA, SQLMODE or DICTIONARY.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string LkProperties(CredentialOptions credentialOptions, string filename, LkPropertiesOptions lkPropertiesOptions = null,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.LkProperties(credentialOptions, filename, lkPropertiesOptions, DATAFORMATSCH_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns a query result in a table format, in a synchronous way.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File or table name defined in Linkar Schemas. Table notation is: MainTable[.MVTable[.SVTable]]</param>
        /// <param name="selectClause">Fragment of the phrase that indicate the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="dictClause">Is the list of dictionaries to read, separated by space. If dictionaries are not indicated the function will read the complete buffer. For example CUSTOMER DATE ITEM</param>
        /// <param name="sortClause">Fragment of the phrase that indicates the selection order. If there is a selection rule Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="tableOptions">Different function options: rowHeaders, rowProperties, onlyVisibe, usePropertyNames, repeatValues, applyConversion, applyFormat, calculated, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string GetTable(CredentialOptions credentialOptions, string filename, string selectClause = "", string dictClause = "", string sortClause = "",
            OperationOptions tableOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.GetTable(credentialOptions, filename, selectClause, dictClause, sortClause, tableOptions, customVars, receiveTimeout);
        }

        /// <summary>
        /// Resets the COMMON variables with the 100 most used files in a synchronous way with XML output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static string ResetCommonBlocks(CredentialOptions credentialOptions, int receiveTimeout = 0)
        {
            return DirectFunctions.ResetCommonBlocks(credentialOptions, DATAFORMAT_TYPE.XML, receiveTimeout);
        }
    }

}
