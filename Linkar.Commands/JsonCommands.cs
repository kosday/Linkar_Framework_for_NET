using System.Threading.Tasks;

using Linkar.Functions.Direct;

namespace Linkar.Commands.Direct
{
    /// <summary>
    /// Allows making different operations, through some templates in standar format JSON, in a synchronous and synchronous way.
    /// </summary>
    public class JsonCommands
    {
        /// <summary>
        /// Allows making different operations, through some templates in standar format JSON, in a synchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>        /// <returns>The results of the operation.</returns>
        /// <returns>The results of the operation.</returns>
        public static string SendCommand(CredentialOptions credentialsOptions, string command, int receiveTimeout = 0)
        {
            return DirectFunctions.SendCommand(credentialsOptions, command, ENVELOPE_FORMAT.JSON, receiveTimeout);
        }

        /// <summary>
        /// Allows making different operations, through some templates in standar format JSON, in a asynchronous way.
        /// </summary>
        /// <param name="credentialsOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">It's the maximum time in seconds that the client will keep waiting the answer by the server. By default 0 (wait indefinitely).</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> SendCommandAsync(CredentialOptions credentialsOptions, string command, int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return SendCommand(credentialsOptions, command, receiveTimeout);
            });

            task.Start();
            return task;
        }
    }
}
