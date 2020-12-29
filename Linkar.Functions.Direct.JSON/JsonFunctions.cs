namespace Linkar.Functions.Direct.JSON
{
    /// <summary>
    /// Linkar.Functions.Direct.JSON library namespace.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc
    {
        // Dummy class necessary for SandCastle can generate doc about namespace
    }

    /// <summary>
    /// These functions perform synchronous and asynchronous direct (without establishing permanent session) operations with output format type JSON.
    /// </summary>
    public static partial class Functions
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
        /// Reads one or several records of a file, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name to read.</param>
        /// <param name="records">A list of item IDs to read, separated by the Record Separator character (30). Use StringFunctions.ComposeRecordIds to compose this string</param>
        /// <param name="dictionaries">List of dictionaries to read, separated by space. If this list is not set, all fields are returned.</param>
        /// <param name="readOptions">Object that defines the different reading options of the Function: Calculated, dictClause, conversion, formatSpec, originalRecords.</param>
        /// <param name="jsonFormat">Enum JSON_FORMAT specifies the desired output format: standard JSON, JSON_DICT format, or JSON_SCH format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
        /// 
        /// class Test
        ///     {
        /// 
        ///         public string MyRead()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 ReadOptions options = new ReadOptions(true);
        ///                 result = Functions.Read(credentials,
        ///                     "{" +
        ///                     "  \"RECORDS\": [" +
        ///                     "    {" +
        ///                     "      \"LKITEMID\": \"2\"" +
        ///                     "    }" +
        ///                     "  ]" +
        ///                     "}",
        ///                 "", options);
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
        /// Imports Linkar.Functions.Direct.JSON
        /// 
        /// Class Test
        /// 
        ///     Public Function MyRead() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        ///             Dim options As ReadOptions = New ReadOptions(True);
        ///             result = Functions.Read(credentials,
        ///                     "{" +
        ///                     "  \"RECORDS\": [" +
        ///                     "    {" +
        ///                     "      \"LKITEMID\": \"2\"" +
        ///                     "    }" +
        ///                     "  ]" +
        ///                     "}",
        ///             "", options)			
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
        public static string Read(CredentialOptions credentialOptions, string filename, string records, string dictionaries = "", ReadOptions readOptions = null,
                    JSON_FORMAT jsonFormat = JSON_FORMAT.JSON, string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Read(credentialOptions, filename, records, dictionaries, readOptions, DATAFORMAT_TYPE.JSON, (DATAFORMATCRU_TYPE)jsonFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Update one or several records of a file, synchronously only, with JSON input and output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Buffer of record data to update. Inside this string are the recordIds, the modified records, and the originalRecords. Use StringFunctions.ComposeUpdateBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="updateOptions">Object with write options, including optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="jsonFormat">Enum JSON_FORMAT specifies the desired output format: standard JSON, JSON_DICT format, or JSON_SCH format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
        /// 
        /// class Test
        ///     {
        ///         public string MyUpdate()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        /// 
        ///                 result = Functions.Update(credentials, "LK.CUSTOMERS",
        ///                     "{
        ///                     "  \"RECORDS\": [" +
        ///                     "    {" +
        ///                     "      \"LKITEMID\": \"2\"," +
        ///                     "      \"NAME": \"CUSTOMER 2\"," +
        ///                     "      \"ADDR": \"ADDRESS 2\"," +
        ///                     "      \"PHONE": \"444\"" +
        ///                     "    }" +
        ///                     "  ]" +
        ///                     "}");
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
        /// Imports Linkar.Functions.Direct.JSON
        /// 
        /// Class Test
        /// 
        ///     Public Function MyUpdate() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             result = Functions.Update(credentials, "LK.CUSTOMERS",
        ///                     "{
        ///                     "  \"RECORDS\": [" +
        ///                     "    {" +
        ///                     "      \"LKITEMID\": \"2\"," +
        ///                     "      \"NAME": \"CUSTOMER 2\"," +
        ///                     "      \"ADDR": \"ADDRESS 2\"," +
        ///                     "      \"PHONE": \"444\"" +
        ///                     "    }" +
        ///                     "  ]" +
        ///                     "}")			
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
        /// Inside the records argument, the recordIds and the modified records always must be specified. But the originalRecords not always.
        /// When <see cref="UpdateOptions">updateOptions</see> argument is specified and the <see cref="UpdateOptions.OptimisticLock"/> property is set to true, a copy of the record must be provided before the modification (originalRecords argument)
        /// to use the Optimistic Lock technique. This copy can be obtained from a previous <see cref="Read"/> operation. The database, before executing the modification, 
        /// reads the record and compares it with the copy in originalRecords, if they are equal the modified record is executed.
        /// But if they are not equal, it means that the record has been modified by other user and its modification will not be saved.
        /// The record will have to be read, modified and saved again.
        /// </remarks>
        public static string Update(CredentialOptions credentialOptions, string filename, string records, UpdateOptions updateOptions = null,
                    JSON_FORMAT jsonFormat = JSON_FORMAT.JSON, string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Update(credentialOptions, filename, records, updateOptions, DATAFORMAT_TYPE.JSON, (DATAFORMATCRU_TYPE)jsonFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Creates one or several records of a file, synchronously only, with JSON input and output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">The file name where the records are going to be created.</param>
        /// <param name="records">Buffer of records to write. Inside this string are the recordIds, and the records. Use StringFunctions.ComposeNewBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="newOptions">Object with write options for the new record(s), including recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="jsonFormat">Enum JSON_FORMAT specifies the desired output format: standard JSON, JSON_DICT format, or JSON_SCH format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
        /// 
        /// class Test
        ///     {
        ///         public string MyNew()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        /// 
        ///                 result = Functions.New(credentials, "LK.CUSTOMERS",
        ///                     "{
        ///                     "  \"RECORDS\": [" +
        ///                     "    {" +
        ///                     "      \"LKITEMID\": \"2\"," +
        ///                     "      \"NAME": \"CUSTOMER 2\"," +
        ///                     "      \"ADDR": \"ADDRESS 2\"," +
        ///                     "      \"PHONE": \"444\"" +
        ///                     "    }" +
        ///                     "  ]" +
        ///                     "}");
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
        /// Imports Linkar.Functions.Direct.JSON
        /// 
        /// Class Test
        /// 
        ///     Public Function MyNew() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             result = Functions.New(credentials, "LK.CUSTOMERS",
        ///                     "{
        ///                     "  \"RECORDS\": [" +
        ///                     "    {" +
        ///                     "      \"LKITEMID\": \"2\"," +
        ///                     "      \"NAME": \"CUSTOMER 2\"," +
        ///                     "      \"ADDR": \"ADDRESS 2\"," +
        ///                     "      \"PHONE": \"444\"" +
        ///                     "    }" +
        ///                     "  ]" +
        ///                     "}")	
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
        /// Inside the records argument, the records always must be specified. But the recordIds only must be specified when <see cref="NewOptions"/> argument is null, or when the <see cref="RecordIdType"/> argument of the <see cref="NewOptions"/> constructor is null.
        /// </remarks>
        public static string New(CredentialOptions credentialOptions, string filename, string records, NewOptions newOptions = null,
            JSON_FORMAT jsonFormat = JSON_FORMAT.JSON, string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.New(credentialOptions, filename, records, newOptions, DATAFORMAT_TYPE.JSON, (DATAFORMATCRU_TYPE)jsonFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Deletes one or several records in file, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">The file name where the records are going to be deleted. DICT in case of deleting a record that belongs to a dictionary.</param>
        /// <param name="records">Buffer of records to be deleted. Use StringFunctions.ComposeDeleteBuffer (Linkar.Strings library) function to compose this string.</param>
        /// <param name="deleteOptions">Object with options to manage how records are deleted, including optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
        /// 
        /// class Test
        ///     {
        ///         public string MyDelete()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        /// 
        ///                 result = Functions.Delete(credentials, "LK.CUSTOMERS",
        ///                     "{
        ///                     "  \"RECORDS\": [" +
        ///                     "    {" +
        ///                     "      \"LKITEMID\": \"2\"" +
        ///                     "    }" +
        ///                     "  ]" +
        ///                     "}");
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
        /// Imports Linkar.Functions.Direct.JSON
        /// 
        /// Class Test
        /// 
        ///     Public Function MyDelete() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             result = JSON.Functions.Delete(credentials, "LK.CUSTOMERS",
        ///                     "{
        ///                     "  \"RECORDS\": [" +
        ///                     "    {" +
        ///                     "      \"LKITEMID\": \"2\"" +
        ///                     "    }" +
        ///                     "  ]" +
        ///                     "}")
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
        /// Inside the records argument, the recordIds always must be specified. But the originalRecords not always.
        /// When <see cref="DeleteOptions">deleteOptions</see> argument is specified and the <see cref="DeleteOptions.OptimisticLock"/> property is set to true,
        /// a copy of the record must be provided before the deletion (originalRecords argument) to use the Optimistic Lock technique.
        /// This copy can be obtained from a previous <see cref="Read"/> operation. The database, before executing the deletion, 
        /// reads the record and compares it with the copy in originalRecords, if they are equal the record is deleted.
        /// But if they are not equal, it means that the record has been modified by other user and the record will not be deleted.
        /// The record will have to be read, and deleted again.
        /// </remarks>
        public static string Delete(CredentialOptions credentialOptions, string filename, string records, DeleteOptions deleteOptions = null,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Delete(credentialOptions, filename, records, deleteOptions, DATAFORMAT_TYPE.JSON, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Executes a Query in the Database, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
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
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
        /// 
        /// class Test
        ///     {
        ///         public string MySelect()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 
        ///                 result = Functions.Select(credentials, "LK.CUSTOMERS");
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
        /// Imports Linkar.Functions.Direct.JSON
        /// 
        /// Class Test
        /// 
        ///     Public Function MySelect() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim options As SelectOptions = New SelectOptions(False);
        ///             result = Functions.Select(credentials, "LK.CUSTOMERS")
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
        /// In the preSelectClause argument these operations can be carried out before executing the Select statement:
        ///  <list type="bullet">
        ///   <item>Previously call to a saved list with the GET.LIST command to use it in the Main Select input</item>
        ///   <item>Make a previous Select to use the result as the Main Select input, with the SELECT or SSELECT commands.In this case the entire sentence must be indicated in the PreselectClause. For example:SSELECT LK.ORDERS WITH CUSTOMER = '1'</item>
        ///   <item>Exploit a Main File index to use the result as a Main Select input, with the SELECTINDEX command. The syntax for all the databases is SELECTINDEX index.name.value. For example SELECTINDEX ITEM,"101691"</item>
        /// </list>
        /// </remarks>
        public static string Select(CredentialOptions credentialOptions, string filename, string selectClause = "", string sortClause = "", string dictClause = "", string preSelectClause = "", SelectOptions selectOptions = null,
            JSON_FORMAT jsonFormat = JSON_FORMAT.JSON, string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Select(credentialOptions, filename, selectClause, sortClause, dictClause, preSelectClause, selectOptions, (DATAFORMATCRU_TYPE)jsonFormat, customVars, receiveTimeout);
        }

        /// <summary>
        /// Executes a subroutine, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="subroutineName">Name of BASIC subroutine to execute.</param>
        /// <param name="argsNumber">Number of arguments</param>
        /// <param name="arguments">The subroutine arguments list.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
        /// 
        /// class Test
        ///     {
        ///         public string MySubroutine()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        /// 
        ///                 result = Functions.Subroutine(credentials, "SUB.DEMOLINKAR", 3, 
        ///                     "{" +
        ///                     "  \"ARGUMENTS\": [" +
        ///                     "    {" +
        ///                     "      \"ARGUMENT\": \"0\"" +
        ///                     "    }," +
        ///                     "    {" +
        ///                     "      \"ARGUMENT\": \"aaaa\"" +
        ///                     "    }," +
        ///                     "    {" +
        ///                     "      \"ARGUMENT\": \"\"" +
        ///                     "    }" +
        ///                     "  ]" +
        ///                     "}");
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
        /// Imports Linkar.Functions.Direct.JSON
        /// 
        /// Class Test
        /// 
        ///     Public Function MySubroutine() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             result = Functions.Subroutine(credentials, "SUB.DEMOLINKAR", 3, 
        ///                     "{" +
        ///                     "  \"ARGUMENTS\": [" +
        ///                     "    {" +
        ///                     "      \"ARGUMENT\": \"0\"" +
        ///                     "    }," +
        ///                     "    {" +
        ///                     "      \"ARGUMENT\": \"aaaa\"" +
        ///                     "    }," +
        ///                     "    {" +
        ///                     "      \"ARGUMENT\": \"\"" +
        ///                     "    }" +
        ///                     "  ]" +
        ///                     "}")
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
        public static string Subroutine(CredentialOptions credentialOptions, string subroutineName, int argsNumber, string arguments,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Subroutine(credentialOptions, subroutineName, argsNumber, arguments, DATAFORMAT_TYPE.JSON, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the result of executing ICONV() or OCONV() functions from a expression list in the Database, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="conversionType">Indicates the conversion type, input or output: INPUT=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="expression">The data or expression to convert. May include MV marks (value delimiters), in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. Must obey the Database conversions specifications.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
        /// 
        /// class Test
        ///     {
        ///         public string MyConversion()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        /// 
        ///                 result = Functions.Conversion(credentials, CONVERSION_TYPE.INPUT, "31-12-2017þ01-01-2018", "D2-");
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
        /// Imports Linkar.Functions.Direct.JSON
        /// 
        /// Class Test
        /// 
        ///     Public Function MyConversion() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             result = Functions.Conversion(credentials, CONVERSION_TYPE.INPUT,"31-12-2017þ01-01-2018","D2-")			
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
        public static string Conversion(CredentialOptions credentialOptions, CONVERSION_TYPE conversionType, string expression, string code,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Conversion(credentialOptions, expression, code, conversionType, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the result of executing the FMT function in a expressions list in the Database, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="expression">The data or expression to format. If multiple values are present, the operation will be performed individually on all values in the expression.</param>
        /// <param name="formatSpec">Specified format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
        /// 
        /// class Test
        ///     {
        ///         public string MyFormat()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        /// 
        ///                 result = Functions.Format(credentials, "1þ2", "R#10");
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
        /// Imports Linkar.Functions.Direct.JSON
        /// 
        /// Class Test
        /// 
        ///     Public Function MyFormat() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             result = Functions.Format(credentials, "1þ2","R#10")			
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
        public static string Format(CredentialOptions credentialOptions, string expression, string formatSpec,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Format(credentialOptions, expression, formatSpec, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns all the dictionaries of a file, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="filename">File name</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
        /// 
        /// class Test
        ///     {
        ///         public string MyDictionaries()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        /// 
        ///                 result = Functions.Dictionaries(credentials, "LK.CUSTOMERS");
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
        /// Imports Linkar.Functions.Direct.JSON
        /// 
        /// Class Test
        /// 
        ///     Public Function MyDictionaries() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             result = Functions.Dictionaries(credentials, "LK.CUSTOMERS")			
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
        public static string Dictionaries(CredentialOptions credentialOptions, string filename,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Dictionaries(credentialOptions, filename, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Allows the execution of any command from the Database, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="statement">The command you want to execute in the Database.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
        /// 
        /// class Test
        ///     {
        ///         public string MyExecute()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        /// 
        ///                 result = Functions.Execute(credentials, "WHO");
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
        /// Imports Linkar.Functions.Direct.JSON
        /// 
        /// Class Test
        /// 
        ///     Public Function MyExecute() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             result = Functions.Execute(credentials, "WHO")			
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
        public static string Execute(CredentialOptions credentialOptions, string statement,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.Execute(credentialOptions, statement, DATAFORMAT_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Allows getting the server version, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
        /// 
        /// class Test
        ///     {
        ///         public string MyGetVersion()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        /// 
        ///                 result = Functions.GetVersion(credentials);
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
        /// Imports Linkar.Functions.Direct.JSON
        /// 
        /// Class Test
        /// 
        ///     Public Function MyGetVersion() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             result = Functions.GetVersion(credentials)
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
        public static string GetVersion(CredentialOptions credentialOptions, int receiveTimeout = 0)
        {
            return DirectFunctions.GetVersion(credentialOptions, DATAFORMAT_TYPE.JSON, receiveTimeout);
        }

        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
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
        ///                 result = Functions.LkSchemas(credentials, options);
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
        /// Imports Linkar.Functions.Direct.JSON
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
        ///             result = Functions.LkSchemas(credentials, options)
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
        public static string LkSchemas(CredentialOptions credentialOptions, LkSchemasOptions lkSchemasOptions = null,
             string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.LkSchemas(credentialOptions, lkSchemasOptions, DATAFORMATSCH_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, synchronously only, with JSON output format.
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
        /// using Linkar.Functions.Direct.JSON;
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
        ///                 result = Functions.LkProperties(credentials, "LK.CUSTOMERS", options);
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
        /// Imports Linkar.Functions.Direct.JSON
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
        ///             result = Functions.LkProperties(credentials, "LK.CUSTOMERS",options)			
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
        public static string LkProperties(CredentialOptions credentialOptions, string filename, LkPropertiesOptions lkPropertiesOptions = null,
            string customVars = "", int receiveTimeout = 0)
        {
            return DirectFunctions.LkProperties(credentialOptions, filename, lkPropertiesOptions, DATAFORMATSCH_TYPE.JSON, customVars, receiveTimeout);
        }

        /// <summary>
        /// Resets the COMMON variables with the 100 most used files, synchronously only, with JSON output format.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Functions.Direct.JSON;
        /// 
        /// class Test
        ///     {
        ///         public string MyResetCommonBlocks()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        /// 
        ///                 result = Functions.ResetCommonBlocks(credentials);
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
        /// Imports Linkar.Functions.Direct.JSON
        /// 
        /// Class Test
        /// 
        ///     Public Function MyResetCommonBlocks() As String
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             result = Functions.ResetCommonBlocks(credentials)
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
        public static string ResetCommonBlocks(CredentialOptions credentialOptions, int receiveTimeout = 0)
        {
            return DirectFunctions.ResetCommonBlocks(credentialOptions, DATAFORMAT_TYPE.JSON, receiveTimeout);
        }
    }
}
