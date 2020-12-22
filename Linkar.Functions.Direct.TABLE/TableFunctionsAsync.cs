using System.Threading.Tasks;

namespace Linkar.Functions.Direct.TABLE
{
    public partial class Functions
    {
        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, in a asynchronous way with TABLE output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.TABLE;
        /// 
        /// class Test
        ///     {
        ///         public string MyLkSchemas()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LkSchemasOptions options = new LkSchemasOptions(RowHeaders.TYPE.MAINLABEL, false, false);
        ///                 result = Functions.LkSchemasAsync(credentials, options).Result;
        ///             }
        ///             catch (Exception ex)
        ///             {
        ///                 string error = ex.Message;
        ///                 // Do something
        ///             }
        ///             return result;
        ///         }
        ///     }
        /// </code>
        /// <code lang="VB">
        /// Imports Linkar
        /// Imports Linkar.Functions.Direct.TABLE
        /// 
        /// Class Test
        /// 
        ///     Public Function MyLkSchemas() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim options As LkSchemasOptions = New LkSchemasOptions(RowHeaders.TYPE.MAINLABEL, False, False);
        ///             result = Functions.LkSchemasAsync(credentials, options).Result
        ///     Catch ex As Exception
        ///         Dim[error] As String = ex.Message
        /// 			' Do something
        /// 
        ///         End Try
        /// 
        ///         Return result
        ///   End Function
        /// End Class
        /// </code>
        /// </example>
        /// <remarks>
        /// TABLE output format uses the defined control characters in <see href="http://kosday.com/Manuals/en_web_linkar/lk_schemas_ep_parameters.html">EntryPoints Parameters</see> Table Row Separator and Column Row Separator.
        /// <para>By default:
        /// <list type="bullet">
        /// <item>TAB char (9) for columns.</item>
        /// <item>VT char (11) for rows.</item>
        /// </list>
        /// </para>
        /// </remarks>
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
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.TABLE;
        /// 
        /// class Test
        ///     {
        ///         public string MyLkProperties()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LkPropertiesOptions options = new LkPropertiesOptions(RowHeaders.TYPE.MAINLABEL, false, false, false);
        ///                 result = Functions.LkPropertiesAsync(credentials, "LK.CUSTOMERS", options).Result;
        ///             }
        ///             catch (Exception ex)
        ///             {
        ///                 string error = ex.Message;
        ///                 // Do something
        ///             }
        ///             return result;
        ///         }
        ///     }
        /// </code>
        /// <code lang="VB">
        /// Imports Linkar
        /// Imports Linkar.Functions.Direct.TABLE
        /// 
        /// Class Test
        /// 
        ///     Public Function MyLkProperties() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim options As LkPropertiesOptions = New LkPropertiesOptions(RowHeaders.TYPE.MAINLABEL, False, False, False);
        ///             result = Functions.LkPropertiesAsync(credentials, "LK.CUSTOMERS",options).Result
        /// 		Catch ex As Exception
        /// 
        ///             Dim[error] As String = ex.Message
        /// 			' Do something
        /// 		End Try
        /// 
        ///         Return result
        ///   End Function
        /// End Class
        /// </code>
        /// </example>
        /// <remarks>
        /// TABLE output format uses the defined control characters in <see href="http://kosday.com/Manuals/en_web_linkar/lk_schemas_ep_parameters.html">EntryPoints Parameters</see> Table Row Separator and Column Row Separator.
        /// <para>By default:
        /// <list type="bullet">
        /// <item>TAB char (9) for columns.</item>
        /// <item>VT char (11) for rows.</item>
        /// </list>
        /// </para>
        /// </remarks>
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
        /// Returns a query result in a table format, synchronously only, in a asynchronous way with TABLE output format.
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
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.TABLE;
        /// 
        /// class Test
        ///     {
        ///         public string MyGetTable()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 TableOptions options = new TableOptions(RowHeaders.TYPE.MAINLABEL, false, false, false, false, false, false, false);
        ///                 result = Functions.GetTableAsync(credentials, "LK.CUSTOMERS", options).Result;
        ///             }
        ///             catch (Exception ex)
        ///             {
        ///                 string error = ex.Message;
        ///                 // Do something
        ///             }
        ///             return result;
        ///         }
        ///     }
        /// </code>
        /// <code lang="VB">
        /// Imports Linkar
        /// Imports Linkar.Functions.Direct.TABLE
        /// 
        /// Class Test
        /// 
        ///     Public Function MyGetTable() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim options As TableOptions = New TableOptions(RowHeaders.TYPE.MAINLABEL, False, False, False, False, False, False, False);
        ///             result = Functions.GetTableAsync(credentials, "LK.CUSTOMERS",options).Result
        /// 		Catch ex As Exception
        /// 
        ///             Dim[error] As String = ex.Message
        /// 			' Do something
        /// 		End Try
        /// 
        ///         Return result
        ///   End Function
        /// End Class
        /// </code>
        /// </example>
        /// <remarks>
        /// TABLE output format uses the defined control characters in <see href="http://kosday.com/Manuals/en_web_linkar/lk_schemas_ep_parameters.html">EntryPoints Parameters</see> Table Row Separator and Column Row Separator.
        /// <para>By default:
        /// <list type="bullet">
        /// <item>TAB char (9) for columns.</item>
        /// <item>VT char (11) for rows.</item>
        /// </list>
        /// </para>
        /// </remarks>
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
