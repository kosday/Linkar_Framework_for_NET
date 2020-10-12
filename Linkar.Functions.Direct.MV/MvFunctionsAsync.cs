using System.Threading.Tasks;

using Linkar;

namespace Linkar.Functions.Direct.MV
{
    public static partial class Functions
    {
        /// <summary>
        /// Reads one or several records of a file in asynchronous way with MV output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name to read.</param>
        /// <param name="recordIds">The records codes list to read, separated by the Record Separator character (30). Use StringFunctions.ComposeRecordIds to compose this string</param>
        /// <param name="dictionaries">List of dictionaries to read, separated by space. If dictionaries are not indicated the function will read the complete buffer.</param>
        /// <param name="readOptions">Object that defines the different reading options of the Function: Calculated, dictClause, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> ReadAsync(CredentialOptions credentialOptions, string filename, string recordIds, string dictionaries = "", ReadOptions readOptions = null,
            string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return Read(credentialOptions, filename, recordIds, dictionaries, readOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Update one or several records of a file, in a asynchronous way with MV input and output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name where you are going to write.</param>
        /// <param name="records">Are the records you want to update. Inside this string are the recordIds, the records, and the originalRecords. Use StringFunctions.ComposeUpdateBuffer function to compose this string.</param>
        /// <param name="updateOptions">Object that defines the different writing options of the Function: optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> UpdateAsync(CredentialOptions credentialOptions, string filename, string records, UpdateOptions updateOptions = null,
            string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return Update(credentialOptions, filename, records, updateOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Creates one or several records of a file, in a asynchronous way with MV input and output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name where you are going to write.</param>
        /// <param name="records">Are the records you want to write. Inside this string are the recordIds, and the records. Use StringFunctions.ComposeNewBuffer function to compose this string.</param>
        /// <param name="newOptions">Object that defines the following writing options of the Function: recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> NewAsync(CredentialOptions credentialOptions, string filename, string records, NewOptions newOptions = null,
            string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return New(credentialOptions, filename, records, newOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Deletes one or several records in file, in a asynchronous way with MV output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">The file name where the records are going to be deleted. DICT in case of deleting a record that belongs to a dictionary.</param>
        /// <param name="records">The records list to be deleted. Use StringFunctions.ComposeDeleteBuffer function to compose this string.</param>
        /// <param name="deleteOptions">Object that defines the different Function options: optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> DeleteAsync(CredentialOptions credentialOptions, string filename, string records, DeleteOptions deleteOptions = null,
        string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return Delete(credentialOptions, filename, records, deleteOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Executes a Query in the Database, in a asynchronous way with MV output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name where the select operation will be perform. For example LK.ORDERS</param>
        /// <param name="selectClause">Fragment of the phrase that indicate the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="sortClause">Fragment of the phrase that indicates the selection order. If there is a selection rule, Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="dictClause">Space-delimited list of dictionaries to read. If dictionaries are not indicated the function will read the complete buffer. For example CUSTOMER DATE ITEM</param>
        /// <param name="preSelectClause">An optional command that executes before the main Select</param>
        /// <param name="selectOptions">Object that defines the different reading options of the Function: calculated, dictionaries, conversion, formatSpec, originalRecords, onlyItemId, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> SelectAsync(CredentialOptions credentialOptions, string filename, string selectClause = "", string sortClause = "", string dictClause = "", string preSelectClause = "", SelectOptions selectOptions = null,
        string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return Select(credentialOptions, filename, selectClause, sortClause, dictClause, preSelectClause, selectOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Executes a subroutine, in a asynchronous way with MV output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="subroutineName">Subroutine name you want to execute.</param>
        /// <param name="argsNumber">Number of arguments</param>
        /// <param name="arguments">The subroutine arguments list.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> SubroutineAsync(CredentialOptions credentialOptions, string subroutineName, int argsNumber, string arguments,
            string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return Subroutine(credentialOptions, subroutineName, argsNumber, arguments, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns the result of executing ICONV() or OCONV() functions from a expression list in the Database, in a asynchronous way with MV output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="conversionOptions">Indicates the conversion type, input or output: INPUT=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="expression">The data or expression to convert. It can have MV marks, in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. It will have to obey the Database conversions specifications.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> ConversionAsync(CredentialOptions credentialOptions, CONVERSION_TYPE conversionOptions, string expression, string code,
                string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return Conversion(credentialOptions, conversionOptions, expression, code, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns the result of executing the FMT function in a expressions list in the Database, in a asynchronous way with MV output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="expression">The data or expression to format. It can contain MV marks, in which case the conversion in each value will be executed according to the original MV mark.</param>
        /// <param name="formatSpec">Specified format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> FormatAsync(CredentialOptions credentialOptions, string expression, string formatSpec,
            string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return Format(credentialOptions, expression, formatSpec, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns all the dictionaries of a file, in a asynchronous way with MV output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> DictionariesAsync(CredentialOptions credentialOptions, string filename,
            string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return Dictionaries(credentialOptions, filename, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Allows the execution of any command from the Database in a asynchronous way with MV output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="statement">The command you want to execute in the Database.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> ExecuteAsync(CredentialOptions credentialOptions, string statement,
            string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return Execute(credentialOptions, statement, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Allows getting the server version, in a asynchronous way with MV output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> GetVersionAsync(CredentialOptions credentialOptions, int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return GetVersion(credentialOptions, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, in a asynchronous way with MV output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> LkSchemaAsync(CredentialOptions credentialOptions, LkSchemasOptions lkSchemasOptions = null,
             string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return LkSchemas(credentialOptions, lkSchemasOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, in a asynchronous way with MV output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> LkPropertiesAsync(CredentialOptions credentialOptions, string filename, LkPropertiesOptions lkPropertiesOptions = null,
        string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return LkProperties(credentialOptions, filename, lkPropertiesOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Resets the COMMON variables with the 100 most used files in a asynchronous way with MV output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> ResetCommonBlocksAsync(CredentialOptions credentialOptions, int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return ResetCommonBlocks(credentialOptions, receiveTimeout);
            });

            task.Start();
            return task;
        }
    }
}
