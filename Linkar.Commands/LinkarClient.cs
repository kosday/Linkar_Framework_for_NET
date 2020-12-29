using System.Threading.Tasks;

namespace Linkar.Commands.Persistent
{
    /// <summary>
    /// Linkar.Commands.Persistent library namespace.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc
    {
        // Dummy class necessary for SandCastle can generate doc about namespace
    }

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
        /// Starts the communication with a server allowing making use of the rest of functions until the Close method is executed or the connection with the server gets lost, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <remarks>
        /// Login is actually a "virtual" operation which creates a new Client Session ID. No DBMS login is performed unless Linkar SERVER determines new Database Sessions are required. These operations are not related.
        /// </remarks> 
        public void Login(CredentialOptions credentialOptions, string customVars = "", int receiveTimeout = 0)
        {
            if (this._ConnectionInfo == null)
            {
                string options = "";
                string US_str = "\x1F";
                string loginArgs = customVars + US_str + options;
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
        /// <remarks>
        /// Logout is actually a "virtual" operation which disposes the current Client Session ID. No DBMS logout is performed.
        /// </remarks>
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
        /// Allows a variety of operations using standard templates (XML, JSON), synchronously only.
        /// </summary>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="commandFormat">Indicates in what format you are doing the operation: XML or JSON.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public string SendCommand(string command, ENVELOPE_FORMAT commandFormat = ENVELOPE_FORMAT.XML, int receiveTimeout = 0)
        {
            string customVars = "";
            string options = "";
            string US_str = "\x1F";
            string sendCommandArgs = customVars + US_str + options + US_str + command;
            byte opCode;
            if (commandFormat == ENVELOPE_FORMAT.JSON)
                opCode = (byte)OPERATION_CODE.COMMAND_JSON;
            else
                opCode = (byte)OPERATION_CODE.COMMAND_XML;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)DATAFORMAT_TYPE.MV;
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, sendCommandArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Allows a variety of operations using standard JSON templates, in a asynchronous way.
        /// </summary>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="commandFormat">Indicates in what format you are doing the operation: XML or JSON.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public Task<string> SendCommandAsync(string command, ENVELOPE_FORMAT commandFormat = ENVELOPE_FORMAT.XML, int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return SendCommand(command, commandFormat, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Allows a variety of operations using standard JSON templates, synchronously only.
        /// </summary>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Commands.Persistent;
        /// 
        /// class Test
        ///     {
        ///         public string MySendCommand()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        ///                 string command =
        ///                     "{" +
        ///                     "	\"NAME\" : \"READ\"," +
        ///                     "	\"COMMAND\" :" + 
        ///                     "	{" +
        ///                     "		\"CALCULATED\" : \"True\" ," +
        ///                     "		\"OUTPUT_FORMAT\" : \"JSON_DICT\" ," +
        ///                     "		\"FILE_NAME\" : \"LK.CUSTOMERS\" ," +
        ///                     "		\"RECORDS\" : [" +
        ///                     "			{ \"LKITEMID\" : \"2\" }" +
        ///                     "		]" +
        ///                     "	}" +
        ///                     "}";
        ///                 result = client.SendJsonCommand(command);
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
        /// using Linkar.Commands.Persistent;
        /// 
        /// Class Test
        /// 
        ///     Public Function MySendCommand() As String
        /// 
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        ///             string command =
        ///                     "{" +
        ///                     "	\"NAME\" : \"READ\"," +
        ///                     "	\"COMMAND\" :" + 
        ///                     "	{" +
        ///                     "		\"CALCULATED\" : \"True\" ," +
        ///                     "		\"OUTPUT_FORMAT\" : \"JSON_DICT\" ," +
        ///                     "		\"FILE_NAME\" : \"LK.CUSTOMERS\" ," +
        ///                     "		\"RECORDS\" : [" +
        ///                     "			{ \"LKITEMID\" : \"2\" }" +
        ///                     "		]" +
        ///                     "	}" +
        ///                     "}"
        ///             result = client.SendJsonCommand(command)
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
        public string SendJsonCommand(string command, int receiveTimeout = 0)
        {
            return SendCommand(command, ENVELOPE_FORMAT.JSON, receiveTimeout);
        }

        /// <summary>
        /// Allows a variety of operations using standard JSON templates, in a asynchronous way.
        /// </summary>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Commands.Persistent;
        /// 
        /// class Test
        ///     {
        ///         public string MySendCommand()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        ///                 string command =
        ///                     "{" +
        ///                     "	\"NAME\" : \"READ\"," +
        ///                     "	\"COMMAND\" :" + 
        ///                     "	{" +
        ///                     "		\"CALCULATED\" : \"True\" ," +
        ///                     "		\"OUTPUT_FORMAT\" : \"JSON_DICT\" ," +
        ///                     "		\"FILE_NAME\" : \"LK.CUSTOMERS\" ," +
        ///                     "		\"RECORDS\" : [" +
        ///                     "			{ \"LKITEMID\" : \"2\" }" +
        ///                     "		]" +
        ///                     "	}" +
        ///                     "}";
        ///                 result = client.SendJsonCommandAsync(command).Result;
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
        /// using Linkar.Commands.Persistent;
        /// 
        /// Class Test
        /// 
        ///     Public Function MySendCommand() As String
        /// 
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        ///             string command =
        ///                     "{" +
        ///                     "	\"NAME\" : \"READ\"," +
        ///                     "	\"COMMAND\" :" + 
        ///                     "	{" +
        ///                     "		\"CALCULATED\" : \"True\" ," +
        ///                     "		\"OUTPUT_FORMAT\" : \"JSON_DICT\" ," +
        ///                     "		\"FILE_NAME\" : \"LK.CUSTOMERS\" ," +
        ///                     "		\"RECORDS\" : [" +
        ///                     "			{ \"LKITEMID\" : \"2\" }" +
        ///                     "		]" +
        ///                     "	}" +
        ///                     "}"
        ///             result = client.SendJsonCommandAsync(command).Result
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
        public Task<string> SendJsonCommandAsync(string command, int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return SendJsonCommand(command, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Allows a variety of operations using standard XML templates, synchronously only.
        /// </summary>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Commands.Persistent;
        /// 
        /// class Test
        ///     {
        ///         public string MySendCommand()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        ///                 string command =
        ///                     "&lt;COMMAND NAME=\"READ\"&gt;" +
        ///                     "   &lt;CALCULATED&gt;True&lt;/CALCULATED&gt;" +
        ///                     "   &lt;OUTPUT_FORMAT&gt;XML_DICT&lt;/OUTPUT_FORMAT&gt;" +
        ///                     "   &lt;FILE_NAME&gt;LK.CUSTOMERS&lt;/FILE_NAME&gt;" +
        ///                     "   &lt;RECORDS&gt;" +
        ///                     "       &lt;RECORD&gt;" +
        ///                     "           &lt;LKITEMID&gt;2&lt;/LKITEMID&gt;" + 
        ///                     "       &lt;/RECORD&gt;" +
        ///                     "   &lt;/RECORDS&gt;" +
        ///                     "&lt;/COMMAND&gt;"
        ///                 result = client.SendXmlCommand(command);
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
        /// using Linkar.Commands.Persistent;
        /// 
        /// Class Test
        /// 
        ///     Public Function MySendCommand() As String
        /// 
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        ///             string command = 
        ///                     "&lt;COMMAND NAME=\"READ\"&gt;" +
        ///                     "   &lt;CALCULATED&gt;True&lt;/CALCULATED&gt;" +
        ///                     "   &lt;OUTPUT_FORMAT&gt;XML_DICT&lt;/OUTPUT_FORMAT&gt;" +
        ///                     "   &lt;FILE_NAME&gt;LK.CUSTOMERS&lt;/FILE_NAME&gt;" +
        ///                     "   &lt;RECORDS&gt;" +
        ///                     "       &lt;RECORD&gt;" +
        ///                     "           &lt;LKITEMID&gt;2&lt;/LKITEMID&gt;" + 
        ///                     "       &lt;/RECORD&gt;" +
        ///                     "   &lt;/RECORDS&gt;" +
        ///                     "&lt;/COMMAND&gt;
        ///             result = client.SendXmlCommand(command)
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
        public string SendXmlCommand(string command, int receiveTimeout = 0)
        {
            return SendCommand(command, ENVELOPE_FORMAT.XML, receiveTimeout);
        }

        /// <summary>
        /// Allows a variety of asynchronous operations using standard XML templates.
        /// </summary>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Commands.Persistent;
        /// 
        /// class Test
        ///     {
        ///         public string MySendCommand()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
        ///                 LinkarClient client = new LinkarClient();
        ///                 client.Login(credentials);
        ///                 string command =
        ///                     "&lt;COMMAND NAME=\"READ\"&gt;" +
        ///                     "   &lt;CALCULATED&gt;True&lt;/CALCULATED&gt;" +
        ///                     "   &lt;OUTPUT_FORMAT&gt;XML_DICT&lt;/OUTPUT_FORMAT&gt;" +
        ///                     "   &lt;FILE_NAME&gt;LK.CUSTOMERS&lt;/FILE_NAME&gt;" +
        ///                     "   &lt;RECORDS&gt;" +
        ///                     "       &lt;RECORD&gt;" +
        ///                     "           &lt;LKITEMID&gt;2&lt;/LKITEMID&gt;" + 
        ///                     "       &lt;/RECORD&gt;" +
        ///                     "   &lt;/RECORDS&gt;" +
        ///                     "&lt;/COMMAND&gt;"
        ///                 result = client.SendXmlCommandAsync(command).Result;
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
        /// using Linkar.Commands.Persistent;
        /// 
        /// Class Test
        /// 
        ///     Public Function MySendCommand() As String
        /// 
        ///         Dim result As String = ""
        /// 
        ///         Try
        ///             Dim credentials As CredentialOptions = New CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin")
        /// 
        ///             Dim client As LinkarClient = New LinkarClient()
        /// 
        ///             client.Login(credentials)
        ///             string command = 
        ///                     "&lt;COMMAND NAME=\"READ\"&gt;" +
        ///                     "   &lt;CALCULATED&gt;True&lt;/CALCULATED&gt;" +
        ///                     "   &lt;OUTPUT_FORMAT&gt;XML_DICT&lt;/OUTPUT_FORMAT&gt;" +
        ///                     "   &lt;FILE_NAME&gt;LK.CUSTOMERS&lt;/FILE_NAME&gt;" +
        ///                     "   &lt;RECORDS&gt;" +
        ///                     "       &lt;RECORD&gt;" +
        ///                     "           &lt;LKITEMID&gt;2&lt;/LKITEMID&gt;" + 
        ///                     "       &lt;/RECORD&gt;" +
        ///                     "   &lt;/RECORDS&gt;" +
        ///                     "&lt;/COMMAND&gt;
        ///             result = client.SendXmlCommandAsync(command).Result
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
        public Task<string> SendXmlCommandAsync(string command, int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return SendXmlCommand(command, receiveTimeout);
            });

            task.Start();
            return task;
        }
    }
}
