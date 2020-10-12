﻿namespace Linkar.Functions.Persistent.JSON
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
        private Functions.LinkarClient _LinkarClt;

        /// <summary>
        /// SessionID of the connection.
        /// </summary>
        public string SessionID
        {
            get { return this._LinkarClt.SessionID; }
        }

        /// <summary>
        /// Initializes a new instance of the LinkarClt class.
        /// </summary>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely. When the receiveTimeout argument is omitted in any operation, the value set here will be applied.</param>
        public LinkarClient(int receiveTimeout = 0)
        {
            this._LinkarClt = new Functions.LinkarClient(receiveTimeout);
        }

        /// <summary>
        /// Starts the communication with a server allowing making use of the rest of functions until the Close method is executed or the connection with the server gets lost, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        public void Login(CredentialOptions credentialOptions, string customVars = "", int receiveTimeout = 0)
        {
            this._LinkarClt.Login(credentialOptions, customVars, receiveTimeout);
        }

        /// <summary>
        /// Closes the communication with the server, that previously has been opened with a Login function, synchronously only.
        /// </summary>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        public void Logout(string customVars = "", int receiveTimeout = 0)
        {
            this._LinkarClt.Logout(customVars, receiveTimeout);
        }

        /// <summary>
        /// Reads one or several records of a file, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="filename">File name to read.</param>
        /// <param name="records">A list of item IDs to read, separated by the Record Separator character (30). Use StringFunctions.ComposeRecordIds to compose this string</param>
        /// <param name="dictionaries">List of dictionaries to read, separated by space. If this list is not set, all fields are returned.</param>
        /// <param name="readOptions">Object that defines the different reading options of the Function: Calculated, dictClause, conversion, formatSpec, originalRecords.</param>
        /// <param name="jsonFormat">Enum JSON_FORMAT specifies the desired output format: standard JSON, JSON_DICT format, or JSON_SCH format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Read(string filename, string records, string dictionaries = "", ReadOptions readOptions = null,
            JSON_FORMAT jsonFormat = JSON_FORMAT.JSON, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Read(filename, records, dictionaries, readOptions, DATAFORMAT_TYPE.JSON, (DATAFORMATCRU_TYPE)jsonFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Update one or several records of a file, synchronously only, with JSON input and output format.
        /// </summary>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Buffer of record data to update. Inside this string are the recordIds, the modified records, and the originalRecords. Use the StringFunctions.ComposeUpdateBuffer function to compose this string.</param>
        /// <param name="updateOptions">Object with write options, including optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="jsonFormat">Enum JSON_FORMAT specifies the desired output format: standard JSON, JSON_DICT format, or JSON_SCH format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Update(string filename, string records, UpdateOptions updateOptions = null,
            JSON_FORMAT jsonFormat = JSON_FORMAT.JSON, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Update(filename, records, updateOptions, DATAFORMAT_TYPE.JSON, (DATAFORMATCRU_TYPE)jsonFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Creates one or several records of a file, synchronously only, with JSON input and output format.
        /// </summary>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Are the records you want to write. Inside this string are the recordIds, and the records. Use StringFunctions.ComposeNewBuffer function to compose this string.</param>
        /// <param name="newOptions">Object with write options for the new record(s), including recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="jsonFormat">Enum JSON_FORMAT specifies the desired output format: standard JSON, JSON_DICT format, or JSON_SCH format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string New(string filename, string records, NewOptions newOptions = null,
            JSON_FORMAT jsonFormat = JSON_FORMAT.JSON, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.New(filename, records, newOptions, DATAFORMAT_TYPE.JSON, (DATAFORMATCRU_TYPE)jsonFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Deletes one or several records in file, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="filename">The file name where the records are going to be deleted. DICT in case of deleting a record that belongs to a dictionary.</param>
        /// <param name="records">The records list to be deleted. Use StringFunctions.ComposeDeleteBuffer function to compose this string.</param>
        /// <param name="deleteOptions">Object with options to manage how records are deleted, including optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Delete(string filename, string records, DeleteOptions deleteOptions = null,
            string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Delete(filename, records, deleteOptions, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Executes a Query in the Database, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="filename">Name of file on which the operation is performed. For example LK.ORDERS</param>
        /// <param name="selectClause">Statement fragment specifies the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="sortClause">Statement fragment specifies the selection order. If there is a selection rule, Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="dictClause">Space-delimited list of dictionaries to read. If this list is not set, all fields are returned. For example CUSTOMER DATE ITEM</param>
        /// <param name="preSelectClause">An optional command that executes before the main Select</param>
        /// <param name="selectOptions">Object with options to manage how records are selected, including calculated, dictionaries, conversion, formatSpec, originalRecords, onlyItemId, pagination, regPage, numPage.</param>
        /// <param name="jsonFormat">Enum JSON_FORMAT specifies the desired output format: standard JSON, JSON_DICT format, or JSON_SCH format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Select(string filename, string selectClause = "", string sortClause = "", string dictClause = "", string preSelectClause = "", SelectOptions selectOptions = null,
            JSON_FORMAT jsonFormat = JSON_FORMAT.JSON, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Select(filename, selectClause, sortClause, dictClause, preSelectClause, selectOptions, (DATAFORMATCRU_TYPE)jsonFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Executes a subroutine, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="subroutineName">Name of BASIC subroutine to execute.</param>
        /// <param name="argsNumber">Number of arguments</param>
        /// <param name="arguments">The subroutine arguments list.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Subroutine(string subroutineName, int argsNumber, string arguments, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Subroutine(subroutineName, argsNumber, arguments, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the result of executing ICONV() or OCONV() functions from a expression list in the Database, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="conversionOptions">Indicates the conversion type, input or output: INPUT=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="expression">The data or expression to convert. May include MV marks (value delimiters), in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. It will have to obey the Database conversions specifications.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Conversion(CONVERSION_TYPE conversionOptions, string expression, string code, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Conversion(conversionOptions, expression, code, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout); ;
        }

        /// <summary>
        /// Returns the result of executing the FMT function in a expressions list in the Database, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="expression">The data or expression to format. If multiple values are present, the operation will be performed individually on all values in the expression.</param>
        /// <param name="formatSpec">Specified format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Format(string expression, string formatSpec, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Format(expression, formatSpec, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns all the dictionaries of a file, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Dictionaries(string filename, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Dictionaries(filename, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Allows the execution of any command from the Database, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="statement">The command you want to execute in the Database.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Execute(string statement, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Execute(statement, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
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
        /// Allows getting the server version, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string GetVersion(int receiveTimeout = 0)
        {
            return this._LinkarClt.GetVersion(DATAFORMAT_TYPE.JSON, receiveTimeout);
        }

        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string LkSchemas(LkSchemasOptions lkSchemasOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.LkSchemas(lkSchemasOptions, DATAFORMATSCH_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string LkProperties(string filename, LkPropertiesOptions lkPropertiesOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.LkProperties(filename, lkPropertiesOptions, DATAFORMATSCH_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Resets the COMMON variables with the 100 most used files, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string ResetCommonBlocks(int receiveTimeout = 0)
        {
            return this._LinkarClt.ResetCommonBlocks(DATAFORMAT_TYPE.JSON, receiveTimeout);
        }
    }
}
