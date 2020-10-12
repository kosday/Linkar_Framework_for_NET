using System.Threading.Tasks;

namespace Linkar.Functions.Direct.TABLE
{
    public partial class Functions
    {
        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, in a asynchronous way with TABLE output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> LkSchemasAsync(CredentialOptions credentialOptions, LkSchemasOptions lkSchemasOptions = null,
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
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, in a asynchronous way with TABLE output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
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
        /// Returns a query result in a table format, in a synchronous way, in a asynchronous way with TABLE output format.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File or table name defined in Linkar Schemas. Table notation is: MainTable[.MVTable[.SVTable]]</param>
        /// <param name="selectClause">Fragment of the phrase that indicate the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="dictClause">Is the list of dictionaries to read, separated by space. If dictionaries are not indicated the function will read the complete buffer. For example CUSTOMER DATE ITEM</param>
        /// <param name="sortClause">Fragment of the phrase that indicates the selection order. If there is a selection rule Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="tableOptions">Different function options: rowHeaders, rowProperties, onlyVisibe, usePropertyNames, repeatValues, applyConversion, applyFormat, calculated, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> GetTableAsync(CredentialOptions credentialOptions, string filename, string selectClause = "", string dictClause = "", string sortClause = "",
            TableOptions tableOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return GetTable(credentialOptions, filename, selectClause, dictClause, sortClause, tableOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }
    }
}
