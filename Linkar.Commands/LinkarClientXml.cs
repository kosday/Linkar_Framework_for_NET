using System.Threading.Tasks;

using LkCmdPersistent = Linkar.Commands.Persistent;

namespace Linkar.Commands.Persistent.Xml
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkarClient
    {
        private LkCmdPersistent.LinkarClient _LinkarClt;

        /// <summary>
        /// Initializes a new instance of the LinkarClt class.
        /// </summary>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely). When the receiveTimeout argument is omitted in any operation, the value set here will be applied.</param>
        public LinkarClient(int receiveTimeout = 0)
        {
            this._LinkarClt = new LkCmdPersistent.LinkarClient(receiveTimeout);
        }

        /// <summary>
        /// Starts the communication with a server allowing making use of the rest of functions until the Close method is executed or the connection with the server gets lost, in a synchronous way.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        public void Login(CredentialOptions credentialOptions, string customVars = "", int receiveTimeout = 0)
        {
            this._LinkarClt.Login(credentialOptions, customVars, receiveTimeout);
        }

        /// <summary>
        /// Closes the communication with the server, that previously has been opened with a Login function, in a synchronous way.
        /// </summary>
        /// <param name="customVars">It's a free text that will travel until the database to make the admin being able to manage additional behaviours in the standard routine SUB.LK.MAIN.CONTROL.CUSTOM. This routine will be called if the argument has content.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        public void Logout(string customVars = "", int receiveTimeout = 0)
        {
            this._LinkarClt.Logout(customVars, receiveTimeout);
        }

        /// <summary>
        /// Allows making different operations, through some templates in standard format XML, in a synchronous way.
        /// </summary>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>        /// <returns>The results of the operation.</returns>
        /// <returns>The results of the operation.</returns>
        public string SendCommand(string command, int receiveTimeout = 0)
        {
            return this._LinkarClt.SendCommand(command, ENVELOPE_FORMAT.XML, receiveTimeout);
        }

        /// <summary>
        /// Allows making different operations, through some templates in standard format XML, in a asynchronous way.
        /// </summary>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public Task<string> SendCommandAsync(string command, int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.SendCommand(command, receiveTimeout);
            });

            task.Start();
            return task;
        }
    }
}
