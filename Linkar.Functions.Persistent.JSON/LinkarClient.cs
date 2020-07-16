namespace Linkar.Functions.Persistent.JSON
{
    /// <summary>
    /// JSON output formats for Read, Update, New and Select
    /// </summary>
    public enum JSON_FORMAT
    {
        /// <summary>
        /// Show the results of the operation in JSON format.
        /// </summary>
        JSON = 3,

        /// <summary>
        /// Show the results of the operation in JSON_DICT format, using the dictionaries.
        /// </summary>
        JSON_DICT = 7,

        /// <summary>
        /// Show the results of the operation in JSON_SCH format, using the schema properties..
        /// </summary>
        JSON_SCH = 8
    }

    /// <summary>
    /// These functions perform synchronous and asynchronous persistent (establishing permanent session) operations with output format type JSON.
    /// </summary
    public partial class LinkarClient
    {
        private Functions.LinkarClient _LinkarClient;

        /// <summary>
        /// A unique Identifier for the stablished session in LinkarSERVER. This value is set after Login operation.
        /// </summary>
        public string SessionId
        {
            get
            {
                if (this._LinkarClient != null)
                    return this._LinkarClient.SessionId;
                else
                    return "";
            }
        }

        /// <summary>
        /// The public key used to encrypt transmission data between LinkarCLIENT and LinkarSERVER. This value is set after Login operation.
        /// </summary>
        public string PublicKey
        {
            get
            {
                if (this._LinkarClient != null)
                    return this._LinkarClient.PublicKey;
                else
                    return "";
            }
        }

        /// <summary>
        /// Internal LinkarSERVER ID to keep the session. This value is set after Login operation.
        /// </summary>
        public string LkConnectionId
        {
            get
            {
                if (this._LinkarClient != null)
                    return this._LinkarClient.LkConnectionId;
                else
                    return "";
            }
        }

        /// <summary>
        /// Initializes a new instance of the LinkarClient class.
        /// </summary>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely). When the receiveTimeout argument is omitted in any operation, the value set here will be applied.</param>
        public LinkarClient(int receiveTimeout = 0)
        {
            this._LinkarClient = new Functions.LinkarClient(receiveTimeout);
        }

        /// <summary>
        /// Starts the communication with a server allowing making use of the rest of functions until the Close method is executed or the connection with the server gets lost, in a synchronous way.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        public void Login(CredentialOptions credentialOptions, string customVars = "", int receiveTimeout = 0)
        {
            this._LinkarClient.Login(credentialOptions, customVars, receiveTimeout);
        }

        /// <summary>
        /// Closes the communication with the server, that previously has been opened with a Login function, in a synchronous way.
        /// </summary>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        public void Logout(string customVars = "", int receiveTimeout = 0)
        {
            this._LinkarClient.Logout(customVars, receiveTimeout);
        }

        /// <summary>
        /// Reads one or several records of a file in a synchronous way with JSON output format.
        /// </summary>
        /// <param name="filename">File name to read.</param>
        /// <param name="records">The records codes list to read, separated by the Record Separator character (30). Use StringFunctions.ComposeRecordIds to compose this string</param>
        /// <param name="dictionaries">List of dictionaries to read, separated by space. If dictionaries are not indicated the function will read the complete buffer.</param>
        /// <param name="readOptions">Object that defines the different reading options of the Function: Calculated, dictClause, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">'s a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string Read(string filename, string records, string dictionaries = "", ReadOptions readOptions = null,
            JSON_FORMAT xmlFormat = JSON_FORMAT.JSON, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.Read(filename, records, dictionaries, readOptions, (DATAFORMATCRU_TYPE)xmlFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Update one or several records of a file, in a synchronous way with JSON input and output format.
        /// </summary>
        /// <param name="filename">File name where you are going to write.</param>
        /// <param name="records">The records to be updated. Inside this string are the recordIds, the records, and the originalRecords. Use StringFunctions.ComposeUpdateBuffer function to compose this string.</param>
        /// <param name="updateOptions">Object that defines the different writing options of the Function: optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string Update(string filename, string records, UpdateOptions updateOptions = null,
            JSON_FORMAT xmlFormat = JSON_FORMAT.JSON, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.Update(filename, records, updateOptions, DATAFORMAT_TYPE.JSON, (DATAFORMATCRU_TYPE)xmlFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Creates one or several records of a file, in a synchronous way with JSON input and output format.
        /// </summary>
        /// <param name="filename">File name where you are going to write.</param>
        /// <param name="records">The records to be written. Inside this string are the recordIds, and the records. Use StringFunctions.ComposeNewBuffer function to compose this string.</param>
        /// <param name="newOptions">Object that defines the following writing options of the Function: recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string New(string filename, string records, NewOptions newOptions = null,
            JSON_FORMAT xmlFormat = JSON_FORMAT.JSON, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.New(filename, records, newOptions, DATAFORMAT_TYPE.JSON, (DATAFORMATCRU_TYPE)xmlFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Deletes one or several records in file, in a synchronous way with JSON output format.
        /// </summary>
        /// <param name="filename">The file name where the records are going to be deleted. DICT in case of deleting a record that belongs to a dictionary.</param>
        /// <param name="records">The records list to be deleted. Use StringFunctions.ComposeDeleteBuffer function to compose this string.</param>
        /// <param name="deleteOptions">Object that defines the different Function options: optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string Delete(string filename, string records, DeleteOptions deleteOptions = null,
            string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.Delete(filename, records, deleteOptions, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Executes a Query in the Database, in a synchronous way with JSON output format.
        /// </summary>
        /// <param name="filename">File name where the select operation will be perform. For example LK.ORDERS</param>
        /// <param name="selectClause">Fragment of the phrase that indicate the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="sortClause">Fragment of the phrase that indicates the selection order. If there is a selection rule, Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="dictClause">Is the list of dictionaries to read, separated by space. If dictionaries are not indicated the function will read the complete buffer. For example CUSTOMER DATE ITEM</param>
        /// <param name="preSelectClause">An optional statement that will execute before the main Select</param>
        /// <param name="selectOptions">Object that defines the different reading options of the Function: calculated, dictionaries, conversion, formatSpec, originalRecords, onlyItemId, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string Select(string filename, string selectClause = "", string sortClause = "", string dictClause = "", string preSelectClause = "", SelectOptions selectOptions = null,
            JSON_FORMAT xmlFormat = JSON_FORMAT.JSON, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.Select(filename, selectClause, sortClause, dictClause, preSelectClause, selectOptions, (DATAFORMATCRU_TYPE)xmlFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Executes a subroutine, in a synchronous way with JSON output format.
        /// </summary>
        /// <param name="subroutineName">Subroutine name to execute.</param>
        /// <param name="argsNumber">Number of arguments</param>
        /// <param name="arguments">The subroutine arguments list.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string Subroutine(string subroutineName, int argsNumber, string arguments, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.Subroutine(subroutineName, argsNumber, arguments, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the result of executing ICONV() or OCONV() functions from a expression list in the Database, in a synchronous way with JSON output format.
        /// </summary>
        /// <param name="conversionOptions">Indicates the conversion type, input or output: Input=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="expression">The data or expression to convert. It can have MV marks, in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. It will have to obey the Database conversions specifications.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string Conversion(CONVERSION_TYPE conversionOptions, string expression, string code, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.Conversion(conversionOptions, expression, code, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout); ;
        }

        /// <summary>
        /// Returns the result of executing the FMT function in a expressions list in the Database, in a synchronous way with JSON output format.
        /// </summary>
        /// <param name="expression">The data or expression to format. It can contain MV marks, in which case the conversion in each value will be executed according to the original MV mark.</param>
        /// <param name="formatSpec">Specified format</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string Format(string expression, string formatSpec, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.Format(expression, formatSpec, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns all the dictionaries of a file, in a synchronous way with JSON output format.
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string Dictionaries(string filename, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.Dictionaries(filename, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Allows the execution of any command from the Database in a synchronous way with JSON output format.
        /// </summary>
        /// <param name="statement">The command to execute in the Database.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string Execute(string statement, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.Execute(statement, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Allows getting the client version.
        /// </summary>
        /// <returns>The results of the operation.</returns>
        public static string GetLocalVersion()
        {
            return Functions.LinkarClient.GetLocalVersion();
        }

        /// <summary>
        /// Allows getting the server version, in a synchronous way with JSON output format.
        /// </summary>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string GetVersion(int receiveTimeout = 0)
        {
            return this._LinkarClient.GetVersion(DATAFORMAT_TYPE.JSON, receiveTimeout);
        }

        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, in a synchronous way with JSON output format.
        /// </summary>
        /// <param name="lkSchemaOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMA, SQLMODE or DICTIONARY.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string LkSchemas(LkSchemaOptions lkSchemaOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.LkSchemas(lkSchemaOptions, DATAFORMATSCH_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, in a synchronous way with JSON output format.
        /// </summary>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMA, SQLMODE or DICTIONARY.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string LkProperties(string filename, LkPropertiesOptions lkPropertiesOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.LkProperties(filename, lkPropertiesOptions, DATAFORMATSCH_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns a query result in a table format, in a synchronous way.
        /// </summary>
        /// <param name="filename">File or table name defined in Linkar Schemas. Table notation is: MainTable[.MVTable[.SVTable]]</param>
        /// <param name="selectClause">Fragment of the phrase that indicate the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="dictClause">Is the list of dictionaries to read, separated by space. If dictionaries are not indicated the function will read the complete buffer. For example CUSTOMER DATE ITEM</param>
        /// <param name="sortClause">Fragment of the phrase that indicates the selection order. If there is a selection rule Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="tableOptions">Different function options: rowHeaders, rowProperties, onlyVisibe, usePropertyNames, repeatValues, applyConversion, applyFormat, calculated, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database for custom processing. SUB.LK.MAIN.CONTROL.CUSTOM will be called if this parameter has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string GetTable(string filename, string selectClause = "", string dictClause = "", string sortClause = "", OperationOptions tableOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClient.GetTable(filename, selectClause, dictClause, sortClause, tableOptions, customVars, receiveTimeout);
        }

        /// <summary>
        /// Resets the COMMON variables with the 100 most used files in a synchronous way with JSON output format.
        /// </summary>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will wait for a response from the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string ResetCommonBlocks(int receiveTimeout = 0)
        {
            return this._LinkarClient.ResetCommonBlocks(DATAFORMAT_TYPE.JSON, receiveTimeout);
        }
    }
}
