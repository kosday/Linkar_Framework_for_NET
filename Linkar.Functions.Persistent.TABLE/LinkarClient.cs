using System;

namespace Linkar.Functions.Persistent.TABLE
{
    /// <summary>
    /// These functions perform synchronous and asynchronous persistent (establishing permanent session) operations with output format type TABLE.
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
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely). When the receiveTimeout argument is omitted in any operation, the value set here will be applied.</param>
        public LinkarClient(int receiveTimeout = 0)
        {
            this._LinkarClt = new Functions.LinkarClient(receiveTimeout);
        }

        /// <summary>
        /// Starts the communication with a server allowing making use of the rest of functions until the Close method is executed or the connection with the server gets lost, in a synchronous way.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        public void Login(CredentialOptions credentialOptions, string customVars = "", int receiveTimeout = 0)
        {
            this._LinkarClt.Login(credentialOptions, customVars, receiveTimeout);
        }

        /// <summary>
        /// Closes the communication with the server, that previously has been opened with a Login function, in a synchronous way.
        /// </summary>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        public void Logout(string customVars = "", int receiveTimeout = 0)
        {
            this._LinkarClt.Logout(customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, synchronously only, with TABLE output format.
        /// </summary>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string LkSchemas(LkSchemasOptions lkSchemasOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.LkSchemas(lkSchemasOptions, DATAFORMATSCH_TYPE.TABLE, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, synchronously only, with TABLE output format.
        /// </summary>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string LkProperties(string filename, LkPropertiesOptions lkPropertiesOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.LkProperties(filename, lkPropertiesOptions, DATAFORMATSCH_TYPE.TABLE, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns a query result in a table format, synchronously only, with TABLE output format.
        /// </summary>
        /// <param name="filename">File or table name defined in Linkar Schemas. Table notation is: MainTable[.MVTable[.SVTable]]</param>
        /// <param name="selectClause">Fragment of the phrase that indicate the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="dictClause">Is the list of dictionaries to read, separated by space. If dictionaries are not indicated the function will read the complete buffer. For example CUSTOMER DATE ITEM</param>
        /// <param name="sortClause">Fragment of the phrase that indicates the selection order. If there is a selection rule Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="tableOptions">Different function options: rowHeaders, rowProperties, onlyVisibe, usePropertyNames, repeatValues, applyConversion, applyFormat, calculated, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">The maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public string GetTable(string filename, string selectClause = "", string dictClause = "", string sortClause = "", TableOptions tableOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.GetTable(filename, selectClause, dictClause, sortClause, tableOptions, customVars, receiveTimeout);
        }
    }
}
