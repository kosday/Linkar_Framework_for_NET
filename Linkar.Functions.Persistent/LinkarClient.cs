using System;
using System.Threading.Tasks;

using Linkar.Functions;

namespace Linkar.Functions
{
    /// <summary>
    /// These functions perform synchronous persistent (establishing permanent session) operations with any kind of output format type.
    /// </summary>
    public class LinkarClient
    {
        private ConnectionInfo _ConnectionInfo;

        /// <summary>
        /// SessionID of the connection.
        /// </summary>
        public string SessionID
        {
            get { return this._ConnectionInfo.SessionId; }
        }

        private int _ReceiveTimeout;

        /// <summary>
        /// Initializes a new instance of the LinkarClt class.
        /// </summary>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely. When the receiveTimeout argument is omitted in any operation, the value set here will be applied.</param>
        public LinkarClient(int receiveTimeout = 0)
        {
            this._ReceiveTimeout = receiveTimeout;
            this._ConnectionInfo = null;
        }

        /// <summary>
        /// Starts the communication with a server allowing making use of the rest of functions until the Logout method is executed or the connection with the server gets lost, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        public void Login(CredentialOptions credentialOptions, string customVars = "", int receiveTimeout = 0)
        {
            if (this._ConnectionInfo == null)
            {
                string options = "";
                string loginArgs = customVars + ASCII_Chars.US_chr + options;
                byte byteOpCode = (byte)OPERATION_CODE.LOGIN;
                byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
                byte byteOutputFormat = (byte)DATAFORMAT_TYPE.MV;
                if (receiveTimeout <= 0)
                {
                    if (this._ReceiveTimeout > 0)
                        receiveTimeout = this._ReceiveTimeout;
                }
                ConnectionInfo connectionInfo = new ConnectionInfo("", "", "", credentialOptions);
                string loginResult = Linkar.ExecutePersistentOperation(connectionInfo, byteOpCode, loginArgs, byteInputFormat, byteOutputFormat, receiveTimeout);

                if (!string.IsNullOrEmpty(loginResult))
                {
                    const string RECORD_IDS_KEY = "RECORD_ID";
                    const char FS = '\x1C';
                    const char AM = '\xFE';

                    string sessionId = "";
                    string[] parts = loginResult.Split(FS);
                    if (parts.Length >= 1)
                    {
                        string[] headersList = parts[0].Split(AM);
                        for (int i = 1; i < headersList.Length; i++)
                        {
                            if (headersList[i].ToUpper() == RECORD_IDS_KEY)
                            {
                                sessionId = parts[i];
                                break;
                            }
                        }
                    }

                    string lkConnectionId = connectionInfo.LkConnectionId;
                    string publicKey = connectionInfo.PublicKey;
                    this._ConnectionInfo = new ConnectionInfo(sessionId, lkConnectionId, publicKey, credentialOptions);
                }
            }
        }

        /// <summary>
        /// Closes the communication with the server, that previously has been opened with a Login function, synchronously only.
        /// </summary>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        public void Logout(string customVars = "", int receiveTimeout = 0)
        {
            string logoutArgs = customVars;

            byte byteOpCode = (byte)OPERATION_CODE.LOGOUT;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)DATAFORMAT_TYPE.MV;
            if (receiveTimeout <= 0)
            {
                if (this._ReceiveTimeout > 0)
                    receiveTimeout = this._ReceiveTimeout;
            }
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, byteOpCode, logoutArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            if (!string.IsNullOrEmpty(result))
                this._ConnectionInfo = null;
        }

        /// <summary>
        /// Reads one or several records of a file in synchronous way.
        /// </summary>
        /// <param name="filename">File name to read.</param>
        /// <param name="recordIds">A list of item IDs to read, separated by the Record Separator character (30). Use StringFunctions.ComposeRecordIds to compose this string</param>
        /// <param name="dictionaries">List of dictionaries to read, separated by space. If this list is not set, all fields are returned.</param>
        /// <param name="readOptions">Object that defines the different reading options of the Function: Calculated, dictClause, conversion, formatSpec, originalRecords.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the record ids: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Read(string filename, string recordIds, string dictionaries = "", ReadOptions readOptions = null,
            DATAFORMAT_TYPE inputFormat = DATAFORMAT_TYPE.MV, DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV, string customVars = "", int receiveTimeout = 0)
        {
            if (this._ConnectionInfo != null)
            {
                string readArgs = OperationArguments.GetReadArgs(filename, recordIds, dictionaries, readOptions, customVars);
                byte opCode = (byte)OPERATION_CODE.READ;
                byte byteInputFormat = (byte)inputFormat;
                byte byteOutputFormat = (byte)outputFormat;
                string connectionInfo = this._ConnectionInfo.ToString();
                string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, readArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
                return result;
            }
            else
                return "";
        }

        /// <summary>
        /// Update one or several records of a file, synchronously only.
        /// </summary>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Buffer of record data to update. Inside this string are the recordIds, the modified records, and the originalRecords. Use the StringFunctions.ComposeUpdateBuffer function to compose this string.</param>
        /// <param name="updateOptions">Object with write options, including optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the resultant writing data: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Update(string filename, string records, UpdateOptions updateOptions = null,
            DATAFORMAT_TYPE inputFormat = DATAFORMAT_TYPE.MV, DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string updateArgs = OperationArguments.GetUpdateArgs(filename, records, updateOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.UPDATE;
            byte byteInputFormat = (byte)inputFormat;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, updateArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Creates one or several records of a file, synchronously only.
        /// </summary>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Are the records you want to write. Inside this string are the recordIds, and the records. Use StringFunctions.ComposeNewBuffer function to compose this string.</param>
        /// <param name="newOptions">Object with write options for the new record(s), including recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="inputFormat">Indicates in what format you wish to send the resultant writing data: MV, XML or JSON.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the Read, New, Update and Select operations: MV, XML, XML_DICT, XML_SCH, JSON, JSON_DICT or JSON_SCH.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string New(string filename, string records, NewOptions newOptions = null,
            DATAFORMAT_TYPE inputFormat = DATAFORMAT_TYPE.MV, DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string newArgs = OperationArguments.GetNewArgs(filename, records, newOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.NEW;
            byte byteInputFormat = (byte)inputFormat;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, newArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Deletes one or several records in file, synchronously only
        /// </summary>
        /// <param name="filename">The file name where the records are going to be deleted. DICT in case of deleting a record that belongs to a dictionary.</param>
        /// <param name="records">The records list to be deleted. Use StringFunctions.ComposeDeleteBuffer function to compose this string.</param>
        /// <param name="deleteOptions">Object with options to manage how records are deleted, including optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Delete(string filename, string records, DeleteOptions deleteOptions = null,
            DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string deleteArgs = OperationArguments.GetDeleteArgs(filename, records, deleteOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.DELETE;
            byte byteInputFormat = (byte)DATAFORMATCRU_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, deleteArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Executes a Query in the Database, synchronously only.
        /// </summary>
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
        public string Select(string filename, string selectClause = "", string sortClause = "", string dictClause = "", string preSelectClause = "", SelectOptions selectOptions = null,
            DATAFORMATCRU_TYPE outputFormat = DATAFORMATCRU_TYPE.MV,
            string customVars = "", int receiveTimeout = 0)
        {
            string selectArgs = OperationArguments.GetSelectArgs(filename, selectClause, sortClause, dictClause, preSelectClause, selectOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.SELECT;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, selectArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Executes a subroutine, synchronously only.
        /// </summary>
        /// <param name="subroutineName">Name of BASIC subroutine to execute.</param>
        /// <param name="argsNumber">Number of arguments</param>
        /// <param name="arguments">The subroutine arguments list.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Subroutine(string subroutineName, int argsNumber, string arguments, DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV, string customVars = "", int receiveTimeout = 0)
        {
            string subroutineArgs = OperationArguments.GetSubroutineArgs(subroutineName, argsNumber, arguments, customVars);
            byte opCode = (byte)OPERATION_CODE.SUBROUTINE;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, subroutineArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns the result of executing ICONV() or OCONV() functions from a expression list in the Database, synchronously only.
        /// </summary>
        /// <param name="conversionOptions">Indicates the conversion type, input or output: INPUT=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="expression">The data or expression to convert. May include MV marks (value delimiters), in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. It will have to obey the Database conversions specifications.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Conversion(CONVERSION_TYPE conversionOptions, string expression, string code, DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV, string customVars = "", int receiveTimeout = 0)
        {
            string conversionArgs = OperationArguments.GetConversionArgs(code, expression, conversionOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.CONVERSION;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, conversionArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns the result of executing the FMT function in a expressions list in the Database, synchronously only.
        /// </summary>
        /// <param name="expression">The data or expression to format. If multiple values are present, the operation will be performed individually on all values in the expression.</param>
        /// <param name="formatSpec">Specified format</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Format(string expression, string formatSpec, DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV, string customVars = "", int receiveTimeout = 0)
        {
            string formatArgs = OperationArguments.GetFormatArgs(formatSpec, expression, customVars);
            byte opCode = (byte)OPERATION_CODE.FORMAT;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, formatArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns all the dictionaries of a file, synchronously only.
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Dictionaries(string filename, DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV, string customVars = "", int receiveTimeout = 0)
        {
            string dictionariesArgs = OperationArguments.GetDictionariesArgs(filename, customVars);
            byte opCode = (byte)OPERATION_CODE.DICTIONARIES;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, dictionariesArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Allows the execution of any command from the Database synchronously only.
        /// </summary>
        /// <param name="statement">The command you want to execute in the Database.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string Execute(string statement, DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV, string customVars = "", int receiveTimeout = 0)
        {
            string executeArgs = OperationArguments.GetExecuteArgs(statement, customVars);
            byte opCode = (byte)OPERATION_CODE.EXECUTE;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, executeArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
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
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string GetVersion(DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV, int receiveTimeout = 0)
        {
            string versionArgs = OperationArguments.GetVersionArgs();
            byte opCode = (byte)OPERATION_CODE.VERSION;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, versionArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, synchronously only.
        /// </summary>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML, JSON or TABLE.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string LkSchemas(LkSchemasOptions lkSchemasOptions = null, DATAFORMATSCH_TYPE outputFormat = DATAFORMATSCH_TYPE.MV, string customVars = "", int receiveTimeout = 0)
        {
            string lkSchemasArgs = OperationArguments.GetLkSchemasArgs(lkSchemasOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.LKSCHEMAS;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, lkSchemasArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, synchronously only.
        /// </summary>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML, JSON or TABLE.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string LkProperties(string filename, LkPropertiesOptions lkPropertiesOptions = null, DATAFORMATSCH_TYPE outputFormat = DATAFORMATSCH_TYPE.MV, string customVars = "", int receiveTimeout = 0)
        {
            string lkPropertiesArgs = OperationArguments.GetLkPropertiesArgs(filename, lkPropertiesOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.LKPROPERTIES;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, lkPropertiesArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Returns a query result in a table format, synchronously only.
        /// </summary>
        /// <param name="filename">File or table name defined in Linkar Schemas. Table notation is: MainTable[.MVTable[.SVTable]]</param>
        /// <param name="selectClause">Statement fragment specifies the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="dictClause">Space-delimited list of dictionaries to read. If this list is not set, all fields are returned. For example CUSTOMER DATE ITEM</param>
        /// <param name="sortClause">Statement fragment specifies the selection order. If there is a selection rule Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="tableOptions">Different function options: rowHeaders, rowProperties, onlyVisibe, usePropertyNames, repeatValues, applyConversion, applyFormat, calculated, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string GetTable(string filename, string selectClause = "", string dictClause = "", string sortClause = "", TableOptions tableOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            string getTableArgs = OperationArguments.GetGetTableArgs(filename, selectClause, dictClause, sortClause, tableOptions, customVars);
            byte opCode = (byte)OPERATION_CODE.GETTABLE;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)DATAFORMAT_TYPE.MV;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, getTableArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Resets the COMMON variables with the 100 most used files in a asynchronous way.
        /// </summary>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: MV, XML or JSON.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string ResetCommonBlocks(DATAFORMAT_TYPE outputFormat = DATAFORMAT_TYPE.MV, int receiveTimeout = 0)
        {
            string resetCommonBlocksArgs = OperationArguments.GetResetCommonBlocksArgs();
            byte opCode = (byte)OPERATION_CODE.RESETCOMMONBLOCKS;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)outputFormat;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, resetCommonBlocksArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }
    }
}
