using System.Threading.Tasks;

namespace Linkar.Functions.Persistent.TABLE
{
    public partial class LinkarClient
    {
        /// <summary>
        /// /// Starts the communication with a server allowing making use of the rest of functions until the Close method is executed or the connection with the server gets lost, in a asynchronous way.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <remarks>
        /// Login is actually a "virtual" operation which creates a new Client Session ID. No DBMS login is performed unless Linkar SERVER determines new Database Sessions are required - these operations are not related.
        /// </remarks> 
        public Task LoginAsync(CredentialOptions credentialOptions, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task(() =>
            {
                this.Login(credentialOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Closes the communication with the server, that previously has been opened with a Login function, in a asynchronous way.
        /// </summary>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// Logout is actually a "virtual" operation which disposes the current Client Session ID. No DBMS logout is performed.
        /// </remarks>
        public Task LogoutAsync(string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task(() =>
            {
                this.Logout(customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, in a asynchronous way with TABLE output format.
        /// </summary>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.TABLE;
        /// 
        /// class Test
        ///     {
        ///         public string MyLkSchemas()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        ///                 LkSchemasOptions options = new LkSchemasOptions(RowHeaders.TYPE.MAINLABEL, false, false);
        ///                 result = client.LkSchemasAsync(options).Result;
        ///                 client.Logout();
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
        /// Imports Linkar.Functions.Persistent.TABLE
        /// 
        /// Class Test
        /// 
        ///     Public Function MyLkSchemas() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        ///             Dim options As LkSchemasOptions = New LkSchemasOptions(RowHeaders.TYPE.MAINLABEL, False, False);
        ///         result = client.LkSchemasAsync(options).Result
        ///         client.Logout()
        /// 
        ///         Catch ex As Exception
        /// 
        ///             Dim[error] As String = ex.Message
        /// 			' Do something
        /// 		End Try
        /// 
        ///         Return result
        ///   End Function
        /// End Class
        /// </code>
        /// </example>        /// <remarks>
        /// TABLE output format uses the defined control characters in <see href="http://kosday.com/Manuals/en_web_linkar/lk_schemas_ep_parameters.html">EntryPoints Parameters</see> Table Row Separator and Column Row Separator.
        /// <para>By default:
        /// <list type="bullet">
        /// <item>TAB char (9) for columns.</item>
        /// <item>VT char (11) for rows.</item>
        /// </list>
        /// </para>
        /// </remarks>
        public Task<string> LkSchemasAsync(LkSchemasOptions lkSchemasOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.LkSchemas(lkSchemasOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, in a asynchronous way with TABLE output format.
        /// </summary>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.TABLE;
        /// 
        /// class Test
        ///     {
        ///         public string MyLkProperties()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        ///                 LkPropertiesOptions options = new LkPropertiesOptions(RowHeaders.TYPE.MAINLABEL, false, false, false);
        ///                 result = client.LkPropertiesAsync("LK.CUSTOMERS", options).Result;
        ///                 client.Logout();
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
        /// Imports Linkar.Functions.Persistent.TABLE
        /// 
        /// Class Test
        /// 
        ///     Public Function MyLkProperties() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        ///             Dim options As LkPropertiesOptions = New LkPropertiesOptions(RowHeaders.TYPE.MAINLABEL, False, False, False);
        ///         result = client.LkPropertiesAsync("LK.CUSTOMERS",options).Result
        /// 			client.Logout()
        ///         Catch ex As Exception
        ///             Dim[error] As String = ex.Message
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
        public Task<string> LkPropertiesAsync(string filename, LkPropertiesOptions lkPropertiesOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.LkProperties(filename, lkPropertiesOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns a query result in a table format, synchronously only, with TABLE output format.
        /// </summary>
        /// <param name="filename">File or table name defined in Linkar Schemas. Table notation is: MainTable[.MVTable[.SVTable]]</param>
        /// <param name="selectClause">Statement fragment specifies the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="dictClause">Space-delimited list of dictionaries to read. If this list is not set, all fields are returned. For example CUSTOMER DATE ITEM. In NONE mode you may use the format LKFLDx where x is the attribute number.</param>
        /// <param name="sortClause">Statement fragment specifies the selection order. If there is a selection rule Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="tableOptions">Detailed options to be used, including: rowHeaders, rowProperties, onlyVisibe, usePropertyNames, repeatValues, applyConversion, applyFormat, calculated, pagination, regPage, numPage.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.TABLE;
        /// 
        /// class Test
        ///     {
        ///         public string MyGetTable()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        ///                 TableOptions options = new TableOptions(RowHeaders.TYPE.MAINLABEL, false, false, false, false, false, false, false);
        ///                 result = client.GetTableAsync("LK.CUSTOMERS", options).Result;
        ///                 client.Logout();
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
        /// Imports Linkar.Functions.Persistent.TABLE
        /// 
        /// Class Test
        /// 
        ///     Public Function MyGetTable() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        ///             Dim options As TableOptions = New TableOptions(RowHeaders.TYPE.MAINLABEL, False, False, False, False, False, False, False);
        ///         result = client.GetTableAsync("LK.CUSTOMERS",options).Result
        /// 			client.Logout()
        ///         Catch ex As Exception
        ///             Dim[error] As String = ex.Message
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
        public Task<string> GetTableAsync(string filename, string selectClause = "", string dictClause = "", string sortClause = "", TableOptions tableOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.GetTable(filename, selectClause, dictClause, sortClause, tableOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }
    }
}
