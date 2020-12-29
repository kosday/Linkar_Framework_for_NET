using LkFunctPersistent = Linkar.Functions.Persistent;

namespace Linkar.Functions.Persistent.XML
{
    /// <summary>
    /// Linkar.Functions.Persistent.XML library namespace.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc
    {
        // Dummy class necessary for SandCastle can generate doc about namespace
    }

    /// <summary>
    /// XML output formats for Read, Update, New and Select
    /// </summary>
    public enum XML_FORMAT
    {
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
        XML_SCH = 6
    }

    /// <summary>
    /// These functions perform synchronous and asynchronous persistent (establishing permanent session) operations with output format type XML.
    /// </summary>
    public partial class LinkarClient
    {
        private LkFunctPersistent.LinkarClient _LinkarClt;

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
            this._LinkarClt = new LkFunctPersistent.LinkarClient(receiveTimeout);
        }

        /// <summary>
        /// Starts the communication with a server allowing making use of the rest of functions until the Close method is executed or the connection with the server gets lost, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <remarks>
        /// Login is actually a "virtual" operation which creates a new Client Session ID. No DBMS login is performed unless Linkar SERVER determines new Database Sessions are required - these operations are not related.
        /// </remarks> 
        public void Login(CredentialOptions credentialOptions, string customVars = "", int receiveTimeout = 0)
        {
            this._LinkarClt.Login(credentialOptions, customVars, receiveTimeout);
        }

        /// <summary>
        /// Closes the communication with the server, that previously has been opened with a Login function, synchronously only.
        /// </summary>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <remarks>
        /// Logout is actually a "virtual" operation which disposes the current Client Session ID. No DBMS logout is performed.
        /// </remarks>
        public void Logout(string customVars = "", int receiveTimeout = 0)
        {
            this._LinkarClt.Logout(customVars, receiveTimeout);
        }

        /// <summary>
        /// Reads one or several records of a file, synchronously only, with XML output format.
        /// </summary>
        /// <param name="filename">File name to read.</param>
        /// <param name="records">A list of item IDs to read, separated by the Record Separator character (30). Use StringFunctions.ComposeRecordIds to compose this string</param>
        /// <param name="dictionaries">List of dictionaries to read, separated by space. If this list is not set, all fields are returned.</param>
        /// <param name="readOptions">Object that defines the different reading options of the Function: Calculated, dictClause, conversion, formatSpec, originalRecords.</param>
        /// <param name="xmlFormat">Different XML output formats.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
        /// 
        /// class Test
        ///     {
        ///         public string MyRead()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        ///                 ReadOptions options = new ReadOptions(true);
        ///                 result = client.Read("LK.CUSTOMERS",
        ///                     "&lt;?xml version=\"1.0\" encoding=\"utf-16\"?&gt;" + 
        ///                     "&lt;LINKAR&gt;" +
        ///                     "  &lt;RECORDS&gt;" +
        ///                     "    &lt;RECORD&gt;" +
        ///                     "      &lt;LKITEMID&gt;2&lt;/LKITEMID&gt;" +
        ///                     "    &lt;/RECORD&gt;" +
        ///                     "  &lt;/RECORDS&gt;" +
        ///                     "&lt;/LINKAR&gt;",
        ///                 "", options);
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
        /// Imports Linkar.Functions.Persistent.XML
        /// 
        /// Class Test
        /// 
        ///     Public Function MyRead() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        ///             Dim options As ReadOptions = New ReadOptions(True);
        ///             result = client.Read("LK.CUSTOMERS",
        ///                 "&lt;?xml version=\"1.0\" encoding=\"utf-16\"?&gt;" + 
        ///                 "&lt;LINKAR&gt;" +
        ///                 "  &lt;RECORDS&gt;" +
        ///                 "    &lt;RECORD&gt;" +
        ///                 "      &lt;LKITEMID&gt;2&lt;/LKITEMID&gt;" +
        ///                 "    &lt;/RECORD&gt;" +
        ///                 "  &lt;/RECORDS&gt;" +
        ///                 "&lt;/LINKAR&gt;",
        ///             "", options)
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
        public string Read(string filename, string records, string dictionaries = "", ReadOptions readOptions = null,
            XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Read(filename, records, dictionaries, readOptions, DATAFORMAT_TYPE.XML, (DATAFORMATCRU_TYPE)xmlFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Update one or several records of a file, synchronously only, with XML input and output format.
        /// </summary>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Buffer of record data to update. Inside this string are the recordIds, the modified records, and the originalRecords. Use StringFunctions.ComposeUpdateBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="updateOptions">Object with write options, including optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="xmlFormat">Different XML output formats.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
        /// 
        /// class Test
        ///     {
        ///         public string MyUpdate()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        ///                 
        ///                 result = client.Update("LK.CUSTOMERS", 
        ///                     "&lt;?xml version=\"1.0\" encoding=\"utf-16\"?&gt;" +
        ///                     "&lt;LINKAR&gt;" +
        ///                     "  &lt;RECORDS&gt;" +
        ///                     "    &lt;RECORD&gt;" +
        ///                     "      &lt;LKITEMID&gt;2&lt;/LKITEMID&gt;" +
        ///                     "      &lt;NAME&gt;CUSTOMER 2&lt;/NAME&gt;" +
        ///                     "      &lt;ADDR&gt;ADDRESS 2&lt;/ADDR&gt;" +
        ///                     "      &lt;PHONE&gt;444&lt;/PHONE&gt;" +
        ///                     "    &lt;/RECORD&gt;" +
        ///                     "  &lt;/RECORDS&gt;" +
        ///                     "&lt;/LINKAR&gt;");
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
        /// Imports Linkar.Functions.Persistent.XML
        /// 
        /// Class Test
        /// 
        ///     Public Function MyUpdate() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        ///             
        ///             result = client.Update("LK.CUSTOMERS",
        ///                 "&lt;?xml version=\"1.0\" encoding=\"utf-16\"?&gt;" +
        ///                 "&lt;LINKAR&gt;" +
        ///                 "  &lt;RECORDS&gt;" +
        ///                 "    &lt;RECORD&gt;" +
        ///                 "      &lt;LKITEMID&gt;2&lt;/LKITEMID&gt;" +
        ///                 "      &lt;NAME&gt;CUSTOMER 2&lt;/NAME&gt;" +
        ///                 "      &lt;ADDR&gt;ADDRESS 2&lt;/ADDR&gt;" +
        ///                 "      &lt;PHONE&gt;444&lt;/PHONE&gt;" +
        ///                 "    &lt;/RECORD&gt;" +
        ///                 "  &lt;/RECORDS&gt;" +
        ///                 "&lt;/LINKAR&gt;")
        /// 
        ///             client.Logout()
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
        /// Inside the records argument, the recordIds and the modified records always must be specified. But the originalRecords not always.
        /// When <see cref="UpdateOptions">updateOptions</see> argument is specified and the <see cref="UpdateOptions.OptimisticLock"/> property is set to true, a copy of the record must be provided before the modification (originalRecords argument)
        /// to use the Optimistic Lock technique. This copy can be obtained from a previous <see cref="Read"/> operation. The database, before executing the modification, 
        /// reads the record and compares it with the copy in originalRecords, if they are equal the modified record is executed.
        /// But if they are not equal, it means that the record has been modified by other user and its modification will not be saved.
        /// The record will have to be read, modified and saved again.
        /// </remarks>
        public string Update(string filename, string records, UpdateOptions updateOptions = null,
            XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Update(filename, records, updateOptions, DATAFORMAT_TYPE.XML, (DATAFORMATCRU_TYPE)xmlFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Creates one or several records of a file, synchronously only, with XML input and output format.
        /// </summary>
        /// <param name="filename">The file name where the records are going to be created.</param>
        /// <param name="records">Buffer of records to write. Inside this string are the recordIds, and the records. Use StringFunctions.ComposeNewBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="newOptions">Object with write options for the new record(s), including recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="xmlFormat">Different XML output formats.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
        /// 
        /// class Test
        ///     {
        ///         public string MyNew()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        /// 
        ///                 result = client.New("LK.CUSTOMERS", 
        ///                     "&lt;?xml version=\"1.0\" encoding=\"utf-16\"?&gt;" +
        ///                     "&lt;LINKAR&gt;" +
        ///                     "  &lt;RECORDS&gt;" +
        ///                     "    &lt;RECORD&gt;" +
        ///                     "      &lt;LKITEMID&gt;2&lt;/LKITEMID&gt;" +
        ///                     "      &lt;NAME&gt;CUSTOMER 2&lt;/NAME&gt;" +
        ///                     "      &lt;ADDR&gt;ADDRESS 2&lt;/ADDR&gt;" +
        ///                     "      &lt;PHONE&gt;444&lt;/PHONE&gt;" +
        ///                     "    &lt;/RECORD&gt;" +
        ///                     "  &lt;/RECORDS&gt;" +
        ///                     "&lt;/LINKAR&gt;");
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
        /// Imports Linkar.Functions.Persistent.XML
        /// 
        /// Class Test
        /// 
        ///     Public Function MyNew() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        /// 
        ///             result = client.New("LK.CUSTOMERS",
        ///                 "&lt;?xml version=\"1.0\" encoding=\"utf-16\"?&gt;" +
        ///                 "&lt;LINKAR&gt;" +
        ///                 "  &lt;RECORDS&gt;" +
        ///                 "    &lt;RECORD&gt;" +
        ///                 "      &lt;LKITEMID&gt;2&lt;/LKITEMID&gt;" +
        ///                 "      &lt;NAME&gt;CUSTOMER 2&lt;/NAME&gt;" +
        ///                 "      &lt;ADDR&gt;ADDRESS 2&lt;/ADDR&gt;" +
        ///                 "      &lt;PHONE&gt;444&lt;/PHONE&gt;" +
        ///                 "    &lt;/RECORD&gt;" +
        ///                 "  &lt;/RECORDS&gt;" +
        ///                 "&lt;/LINKAR&gt;")
        /// 
        ///             client.Logout()
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
        /// Inside the records argument, the records always must be specified. But the recordIds only must be specified when <see cref="NewOptions"/> argument is null, or when the <see cref="RecordIdType"/> argument of the <see cref="NewOptions"/> constructor is null.
        /// </remarks>
        public string New(string filename, string records, NewOptions newOptions = null,
            XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.New(filename, records, newOptions, DATAFORMAT_TYPE.XML, (DATAFORMATCRU_TYPE)xmlFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Deletes one or several records in file, synchronously only, with XML output format.
        /// </summary>
        /// <param name="filename">The file name where the records are going to be deleted. DICT in case of deleting a record that belongs to a dictionary.</param>
        /// <param name="records">Buffer of records to be deleted. Use StringFunctions.ComposeDeleteBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="deleteOptions">Object with options to manage how records are deleted, including optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
        /// 
        /// class Test
        ///     {
        ///         public string MyDelete()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        /// 
        ///                 result = client.Delete("LK.CUSTOMERS",
        ///                     "&lt;?xml version=\"1.0\" encoding=\"utf-16\"?&gt;" +
        ///                     "&lt;LINKAR&gt;" +
        ///                     "  &lt;RECORDS&gt;" +
        ///                     "    &lt;RECORD&gt;" +
        ///                     "      &lt;LKITEMID&gt;2&lt;/LKITEMID&gt;" +
        ///                     "    &lt;/RECORD&gt;" +
        ///                     "  &lt;/RECORDS&gt;" +
        ///                     "&lt;/LINKAR&gt;");
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
        /// Imports Linkar.Functions.Persistent.XML
        /// 
        /// Class Test
        /// 
        ///     Public Function MyDelete() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        /// 
        ///             result = client.Delete("LK.CUSTOMERS",
        ///                 "&lt;?xml version=\"1.0\" encoding=\"utf-16\"?&gt;" +
        ///                 "&lt;LINKAR&gt;" +
        ///                 "  &lt;RECORDS&gt;" +
        ///                 "    &lt;RECORD&gt;" +
        ///                 "      &lt;LKITEMID&gt;2&lt;/LKITEMID&gt;" +
        ///                 "    &lt;/RECORD&gt;" +
        ///                 "  &lt;/RECORDS&gt;" +
        ///                 "&lt;/LINKAR&gt;")
        /// 
        ///             client.Logout()
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
        /// Inside the records argument, the recordIds always must be specified. But the originalRecords not always.
        /// When <see cref="DeleteOptions">deleteOptions</see> argument is specified and the <see cref="DeleteOptions.OptimisticLock"/> property is set to true,
        /// a copy of the record must be provided before the deletion (originalRecords argument) to use the Optimistic Lock technique.
        /// This copy can be obtained from a previous <see cref="Read"/> operation. The database, before executing the deletion, 
        /// reads the record and compares it with the copy in originalRecords, if they are equal the record is deleted.
        /// But if they are not equal, it means that the record has been modified by other user and the record will not be deleted.
        /// The record will have to be read, and deleted again.
        /// </remarks>
        public string Delete(string filename, string records, DeleteOptions deleteOptions = null,
            string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Delete(filename, records, deleteOptions, DATAFORMAT_TYPE.XML, DATAFORMAT_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Executes a Query in the Database, synchronously only, with XML output format.
        /// </summary>
        /// <param name="filename">Name of file on which the operation is performed. For example LK.ORDERS</param>
        /// <param name="selectClause">Statement fragment specifies the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="sortClause">Statement fragment specifies the selection order. If there is a selection rule, Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="dictClause">Space-delimited list of dictionaries to read. If this list is not set, all fields are returned. For example CUSTOMER DATE ITEM</param>
        /// <param name="preSelectClause">An optional command that executes before the main Select</param>
        /// <param name="selectOptions">Object with options to manage how records are selected, including calculated, dictionaries, conversion, formatSpec, originalRecords, onlyItemId, pagination, regPage, numPage.</param>
        /// <param name="xmlFormat">Different XML output formats.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
        /// 
        /// class Test
        ///     {
        ///         public string MySelect()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        ///                 
        ///                 result = client.SelectAsync("LK.CUSTOMERS").Result;
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
        /// Imports Linkar.Functions.Persistent.XML
        /// 
        /// Class Test
        /// 
        ///     Public Function MySelect() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        ///             
        ///             result = client.SelectAsync("LK.CUSTOMERS").Result
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
        /// In the preSelectClause argument these operations can be carried out before executing the Select statement:
        ///  <list type="bullet">
        ///   <item>Previously call to a saved list with the GET.LIST command to use it in the Main Select input</item>
        ///   <item>Make a previous Select to use the result as the Main Select input, with the SELECT or SSELECT commands.In this case the entire sentence must be indicated in the PreselectClause. For example:SSELECT LK.ORDERS WITH CUSTOMER = '1'</item>
        ///   <item>Exploit a Main File index to use the result as a Main Select input, with the SELECTINDEX command. The syntax for all the databases is SELECTINDEX index.name.value. For example SELECTINDEX ITEM,"101691"</item>
        /// </list>
        /// </remarks>
        public string Select(string filename, string selectClause = "", string sortClause = "", string dictClause = "", string preSelectClause = "", SelectOptions selectOptions = null,
            XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Select(filename, selectClause, sortClause, dictClause, preSelectClause, selectOptions, (DATAFORMATCRU_TYPE)xmlFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Executes a subroutine, synchronously only, with XML output format.
        /// </summary>
        /// <param name="subroutineName">Name of BASIC subroutine to execute.</param>
        /// <param name="argsNumber">Number of arguments</param>
        /// <param name="arguments">The subroutine arguments list.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
        /// 
        /// class Test
        ///     {
        ///         public string MySubroutine()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        /// 
        ///                 result = client.SubroutineAsync("SUB.DEMOLINKAR", 3,
        ///                     "&lt;?xml version=\"1.0\" encoding=\"utf-16\"?&gt;" +
        ///                     "&lt;LINKAR&gt;" +
        ///                     "  &lt;ARGUMENTS&gt;" +
        ///                     "    &lt;ARGUMENT&gt;0&lt;/ARGUMENT&gt;" +
        ///                     "    &lt;ARGUMENT&gt;aaaa&lt;/ARGUMENT&gt;" +
        ///                     "    &lt;ARGUMENT&gt;&lt;/ARGUMENT&gt;" +
        ///                     "  &lt;/ARGUMENTS&gt;" +
        ///                     "&lt;/LINKAR&gt;").Result;
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
        /// Imports Linkar.Functions.Persistent.XML
        /// 
        /// Class Test
        /// 
        ///     Public Function MySubroutine() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        /// 
        ///             result = client.SubroutineAsync("SUB.DEMOLINKAR", 3,
        ///                 "&lt;?xml version=\"1.0\" encoding=\"utf-16\"?&gt;" +
        ///                 "&lt;LINKAR&gt;" +
        ///                 "  &lt;ARGUMENTS&gt;" +
        ///                 "    &lt;ARGUMENT&gt;0&lt;/ARGUMENT&gt;" +
        ///                 "    &lt;ARGUMENT&gt;aaaa&lt;/ARGUMENT&gt;" +
        ///                 "    &lt;ARGUMENT&gt;&lt;/ARGUMENT&gt;" +
        ///                 "  &lt;/ARGUMENTS&gt;" +
        ///                 "&lt;/LINKAR&gt;").Result
        /// 
        ///             client.Logout()
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
        public string Subroutine(string subroutineName, int argsNumber, string arguments, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Subroutine(subroutineName, argsNumber, arguments, DATAFORMAT_TYPE.XML, DATAFORMAT_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the result of executing ICONV() or OCONV() functions from a expression list in the Database, synchronously only, with XML output format.
        /// </summary>
        /// <param name="conversionType">Indicates the conversion type, input or output: INPUT=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="expression">The data or expression to convert. May include MV marks (value delimiters), in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. Must obey the Database conversions specifications.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
        /// 
        /// class Test
        ///     {
        ///         public string MyConversion()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        /// 
        ///                 result = client.ConversionAsync(CONVERSION_TYPE.INPUT, "31-12-2017þ01-01-2018", "D2-").Result;
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
        /// Imports Linkar.Functions.Persistent.XML
        /// 
        /// Class Test
        /// 
        ///     Public Function MyConversion() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        /// 
        ///             result = client.ConversionAsync(CONVERSION_TYPE.INPUT, "31-12-2017þ01-01-2018", "D2-").Result
        /// 
        ///             client.Logout()
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
        public string Conversion(CONVERSION_TYPE conversionType, string expression, string code, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Conversion(conversionType, expression, code, DATAFORMAT_TYPE.XML, customVars, receiveTimeout); ;
        }

        /// <summary>
        /// Returns the result of executing the FMT function in a expressions list in the Database, synchronously only, with XML output format.
        /// </summary>
        /// <param name="expression">The data or expression to format. If multiple values are present, the operation will be performed individually on all values in the expression.</param>
        /// <param name="formatSpec">Specified format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
        /// 
        /// class Test
        ///     {
        ///         public string MyFormat()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        /// 
        ///                 result = client.FormatAsync("1þ2", "R#10").Result;
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
        /// Imports Linkar.Functions.Persistent.XML
        /// 
        /// Class Test
        /// 
        ///     Public Function MyFormat() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        /// 
        ///             result = client.FormatAsync("1þ2", "R#10").Result
        /// 
        ///             client.Logout()
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
        public string Format(string expression, string formatSpec, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Format(expression, formatSpec, DATAFORMAT_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns all the dictionaries of a file, synchronously only, with XML output format.
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
        /// 
        /// class Test
        ///     {
        ///         public string MyDictionaries()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        /// 
        ///                 result = client.DictionariesAsync("LK.CUSTOMERS").Result;
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
        /// Imports Linkar.Functions.Persistent.XML
        /// 
        /// Class Test
        /// 
        ///     Public Function MyDictionaries() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        /// 
        ///             result = client.DictionariesAsync("LK.CUSTOMERS").Result
        /// 
        ///             client.Logout()
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
        public string Dictionaries(string filename, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Dictionaries(filename, DATAFORMAT_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Allows the execution of any command from the Database, synchronously only, with XML output format.
        /// </summary>
        /// <param name="statement">The command you want to execute in the Database.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
        /// 
        /// class Test
        ///     {
        ///         public string MyExecute()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        /// 
        ///                 result = client.ExecuteAsync("WHO").Result;
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
        /// Imports Linkar.Functions.Persistent.XML
        /// 
        /// Class Test
        /// 
        ///     Public Function MyExecute() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        /// 
        ///             result = client.ExecuteAsync("WHO").Result
        /// 
        ///             client.Logout()
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
        public string Execute(string statement, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.Execute(statement, DATAFORMAT_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Allows getting the client version.
        /// </summary>
        /// <returns>The results of the operation.</returns>
        public string GetLocalVersion()
        {
            return this._LinkarClt.GetLocalVersion();
        }

        /// <summary>
        /// Allows getting the server version, synchronously only, with XML output format.
        /// </summary>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
        /// 
        /// class Test
        ///     {
        ///         public string MyGetVersion()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        /// 
        ///                 result = client.GetVersionAsync().Result;
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
        /// Imports Linkar.Functions.Persistent.XML
        /// 
        /// Class Test
        /// 
        ///     Public Function MyGetVersion() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        /// 
        ///             result = client.GetVersionAsync().Result
        /// 
        ///             client.Logout()
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
        /// This function returns the following information
        /// <list type="definition">
        /// <item><term>LKMVCOMPONENTSVERSION</term><description>MV Components version.</description></item>
        /// <item><term>LKSERVERVERSION</term><description>Linkar SERVER version.</description></item>
        /// <item><term>LKCLIENTVERSION</term><description>Used client library version.</description></item>
        /// <item><term>DATABASE</term><description>Database.</description></item>
        /// <item><term>OS</term><description>Operating system.</description></item>
        /// <item><term>DATEZERO</term><description>Date zero base in YYYYMMDD format.</description></item>
        /// <item><term>DATEOUTPUTCONVERSION</term><description>Output conversion for date used by Linkar Schemas.</description></item>
        /// <item><term>TIMEOUTPUTCONVERSION</term><description>Output conversion for time used by Linkar Schemas.</description></item>
        /// <item><term>MVDATETIMESEPARATOR</term><description>DateTime used separator used by Linkar Schemas, for instance 18325,23000.</description></item>
        /// <item><term>MVBOOLTRUE</term><description>Database used char for the Boolean true value used by Linkar Schemas.</description></item>
        /// <item><term>MVBOOLFALSE</term><description>Database used char for the Boolean false value used by Linkar Schemas.</description></item>
        /// <item><term>OUTPUTBOOLTRUE</term><description>Used char for the Boolean true value out of the database used by Linkar Schemas.</description></item>
        /// <item><term>OUTPUTBOOLFALSE</term><description>Used char for the Boolean false value out of the database used by Linkar Schemas.</description></item>
        /// <item><term>MVDECIMALSEPARATOR</term><description>Decimal separator in the database. May be point, comma or none when the database does not store decimal numbers. Used by Linkar Schemas.</description></item>
        /// <item><term>OTHERLANGUAGES</term><description>Languages list separated by commas.</description></item>
        /// <item><term>TABLEROWSEPARATOR</term><description>It is the decimal char that you use to separate the rows in the output table format. By default 11.</description></item>
        /// <item><term>TABLECOLSEPARATOR</term><description>It is the decimal char that you use to separate the columns in the output table format. By default 9.</description></item>
        /// </list>
        /// </remarks>
        /// <seealso href="http://kosday.com/Manuals/en_web_linkar/lk_schemas_ep_parameters.html">Schemas Parameter</seealso>
        public string GetVersion(int receiveTimeout = 0)
        {
            return this._LinkarClt.GetVersion(DATAFORMAT_TYPE.XML, receiveTimeout);
        }

        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, synchronously only, with XML output format.
        /// </summary>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
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
        /// Imports Linkar.Functions.Persistent.XML
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
        ///             result = client.LkSchemasAsync(options).Result
        ///             client.Logout()
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
        /// </example>
        public string LkSchemas(LkSchemasOptions lkSchemasOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.LkSchemas(lkSchemasOptions, DATAFORMATSCH_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, synchronously only, with XML output format.
        /// </summary>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
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
        /// Imports Linkar.Functions.Persistent.XML
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
        ///             result = client.LkPropertiesAsync("LK.CUSTOMERS",options).Result
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
        public string LkProperties(string filename, LkPropertiesOptions lkPropertiesOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            return this._LinkarClt.LkProperties(filename, lkPropertiesOptions, DATAFORMATSCH_TYPE.XML, customVars, receiveTimeout);
        }

        /// <summary>
        /// Resets the COMMON variables with the 100 most used files, synchronously only, with XML output format.
        /// </summary>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Persistent.XML;
        /// 
        /// class Test
        ///     {
        ///         public string MyResetCommonBlocks()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        /// 
        ///                 result = client.ResetCommonBlocksAsync().Result;
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
        /// Imports Linkar.Functions.Persistent.XML
        /// 
        /// Class Test
        /// 
        ///     Public Function MyResetCommonBlocks() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        /// 
        ///             result = client.ResetCommonBlocksAsync().Result
        /// 
        ///             client.Logout()
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
        public string ResetCommonBlocks(int receiveTimeout = 0)
        {
            return this._LinkarClt.ResetCommonBlocks(DATAFORMAT_TYPE.XML, receiveTimeout);
        }
    }
}

