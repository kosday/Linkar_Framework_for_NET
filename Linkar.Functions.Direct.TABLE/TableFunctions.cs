namespace Linkar.Functions.Direct.TABLE
{
    /// <summary>
    /// Namespace for Linkar.Functions.Direct.TABLE library
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc
    {
        // Dummy class necessary for SandCastle can generate doc about namespace
    }

    public static partial class Functions
    {
        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, synchronously only, with TABLE output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string LkSchemas(CredentialOptions credentialOptions, LkSchemasOptions lkSchemasOptions = null,
             string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.LkSchemas(credentialOptions, lkSchemasOptions, DATAFORMATSCH_TYPE.TABLE, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, synchronously only, with TABLE output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string LkProperties(CredentialOptions credentialOptions, string filename, LkPropertiesOptions lkPropertiesOptions = null,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.LkProperties(credentialOptions, filename, lkPropertiesOptions, DATAFORMATSCH_TYPE.TABLE, customVars, receiveTimeout);
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
            return DirectFunctions.GetTable(credentialOptions, filename, selectClause, dictClause, sortClause, tableOptions, customVars, receiveTimeout);
        }

    }
}
