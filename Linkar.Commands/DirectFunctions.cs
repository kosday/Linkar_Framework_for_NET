using System;
using System.Collections.Generic;
using System.Text;

namespace Linkar.Commands
{
    class DirectFunctions
    {
        /// <summary>
        /// Allows a variety of operations using standard templates (XML, JSON), synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="commandFormat">Indicates in what format you are doing the operation: XML or JSON.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string SendCommand(CredentialOptions credentialOptions, string command, ENVELOPE_FORMAT commandFormat = ENVELOPE_FORMAT.XML, int receiveTimeout = 0)
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
            string result = Linkar.ExecuteDirectOperation(credentialOptions, opCode, sendCommandArgs, byteInputFormat, byteOutputFormat, receiveTimeout);
            return result;
        }
    }
}
