using System.Threading.Tasks;

namespace Linkar.Commands
{
    /// <summary>
    /// Linkar.Commands library namespace.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc
    {
        // Dummy class necessary for SandCastle can generate doc about namespace
    }

    /// <summary>
    /// These functions perform synchronous direct (without establishing permanent session) operations with any kind of output format type.
    /// </summary>
    public class DirectCommands
    {
        /// <summary>
        /// Allows a variety of direct operations using standard templates (XML, JSON), synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="commandFormat">Indicates in what format you are doing the operation: XML or JSON.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string SendCommand(CredentialOptions credentialOptions, string command, ENVELOPE_FORMAT commandFormat = ENVELOPE_FORMAT.XML, int receiveTimeout = 0)
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
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, sendCommandArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }

        /// <summary>
        /// Allows a variety of direct operations using standard JSON or XML templates, asynchronously.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="commandFormat">Indicates in what format you are doing the operation: XML or JSON.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> SendCommandAsync(CredentialOptions credentialOptions, string command, ENVELOPE_FORMAT commandFormat = ENVELOPE_FORMAT.XML, int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return SendCommand(credentialOptions, command, commandFormat, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Allows a variety of direct operations using standard JSON templates, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Commands.Direct;
        /// 
        /// class Test
        ///     {
        ///         public string MySendCommand()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
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
        ///                 result = DirectCommands.SendJsonCommand(credentials, command);
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
        /// using Linkar.Commands.Direct;
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
        ///             result = DirectCommands.SendJsonCommand(credentials, command)
        ///         Catch ex As Exception
        ///             Dim[error] As String = ex.Message
        /// 			' Do something
        /// 		End Try
        /// 
        ///         Return result
        ///   End Function
        /// End Class
        /// </code>
        /// </example>
        public static string SendJsonCommand(CredentialOptions credentialOptions, string command, int receiveTimeout = 0)
        {
            return SendCommand(credentialOptions, command, ENVELOPE_FORMAT.JSON, receiveTimeout);
        }

        /// <summary>
        /// Allows a variety of direct operations using standard JSON templates, asynchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Commands.Direct;
        /// 
        /// class Test
        ///     {
        ///         public string MySendCommand()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
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
        ///                 result = DirectCommands.SendJsonCommandAsync(credentials, command).Result;
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
        /// using Linkar.Commands.Direct;
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
        ///             result = DirectCommands.SendJsonCommandAsync(credentials, command).Result
        ///         Catch ex As Exception
        ///             Dim[error] As String = ex.Message
        /// 			' Do something
        /// 		End Try
        /// 
        ///         Return result
        ///   End Function
        /// End Class
        /// </code>
        /// </example>
        public static Task<string> SendJsonCommandAsync(CredentialOptions credentialOptions, string command, int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return SendJsonCommand(credentialOptions, command, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Allows a variety of direct operations using standard XML templates, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param> 
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Commands.Direct;
        /// 
        /// class Test
        ///     {
        ///         public string MySendCommand()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
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
        ///                     "&lt;/COMMAND&gt;";
        ///                 result = DirectCommands.SendXmlCommand(credentials, command);
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
        /// using Linkar.Commands.Direct;
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
        ///                     "&lt;/COMMAND&gt;"
        ///             result = DirectCommands.SendXmlCommand(credentials, command)
        ///             
        ///         Catch ex As Exception
        ///             Dim[error] As String = ex.Message
        /// 			' Do something
        /// 		End Try
        /// 
        ///         Return result
        ///   End Function
        /// End Class
        /// </code>
        /// </example>
        public static string SendXmlCommand(CredentialOptions credentialOptions, string command, int receiveTimeout = 0)
        {
            return SendCommand(credentialOptions, command, ENVELOPE_FORMAT.XML, receiveTimeout);
        }

        /// <summary>
        /// Allows a variety of asynchronous direct operations using standard XML templates, asynchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <example>
        /// <code lang="CS">
        /// using Linkar;
        /// using Linkar.Commands.Direct;
        /// 
        /// class Test
        ///     {
        ///         public string MySendCommand()
        ///         {
        ///             string result = "";
        ///             try
        ///             {
        ///                 CredentialOptions credentials = new CredentialOptions("127.0.0.1", "EPNAME", 11300, "admin", "admin");
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
        ///                     "&lt;/COMMAND&gt;";
        ///                 result = DirectCommands.SendXmlCommandAsync(credentials, command).Result;
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
        /// using Linkar.Commands.Direct;
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
        ///                     "&lt;/COMMAND&gt;"
        ///             result = DirectCommands.SendXmlCommandAsync(credentials, command).Result
        ///             
        ///         Catch ex As Exception
        ///             Dim[error] As String = ex.Message
        /// 			' Do something
        /// 		End Try
        /// 
        ///         Return result
        ///   End Function
        /// End Class
        /// </code>
        /// </example>
        public static Task<string> SendXmlCommandAsync(CredentialOptions credentialOptions, string command, int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return SendXmlCommand(credentialOptions, command, receiveTimeout);
            });

            task.Start();
            return task;
        }
    }
}
