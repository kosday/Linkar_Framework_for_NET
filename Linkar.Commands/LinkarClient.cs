using System;
using System.Threading.Tasks;

namespace Linkar.Commands.Persistent
{
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
        public void Login(CredentialOptions credentialOptions, string customVars = "", int receiveTimeout = 0)
        {
            if (this._ConnectionInfo == null)
            {
                string options = "";
                string loginArgs = customVars + ASCII_Chars.US_chr + options;
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
            string sendCommandArgs = customVars + ASCII_Chars.US_str + options + ASCII_Chars.US_str + command;
            byte opCode;
            if (commandFormat == ENVELOPE_FORMAT.JSON)
                opCode = (byte)OPERATION_CODE.COMMAND_JSON;
            else
                opCode = (byte)OPERATION_CODE.COMMAND_XML;
            byte byteInputFormat = (byte)DATAFORMAT_TYPE.MV;
            byte byteOutputFormat = (byte)DATAFORMAT_TYPE.MV;
            string connectionInfo = this._ConnectionInfo.ToString();
            string result = Linkar.ExecutePersistentOperation(this._ConnectionInfo, opCode, sendCommandArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }
    }
}
