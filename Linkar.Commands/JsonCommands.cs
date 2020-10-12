using System.Threading.Tasks;

namespace Linkar.Commands.Direct
{
    /// <summary>
    /// Allows making different operations, through some templates in standard format JSON, synchronously and asynchronously.
    /// </summary>
    public class JsonCommands
    {
        /// <summary>
        /// Allows making different operations, through some templates in standard format JSON, synchronously only.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static string SendCommand(CredentialOptions credentialOptions, string command, int receiveTimeout = 0)
        {
            return DirectFunctions.SendCommand(credentialOptions, command, ENVELOPE_FORMAT.JSON, receiveTimeout);
        }

        /// <summary>
        /// Allows making different operations, through some templates in standard format JSON, in a asynchronous way.
        /// </summary>
        /// <param name="credentialOptions">Object that defines the necessary data to access to the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="command">Content of the operation you want to send.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public static Task<string> SendCommandAsync(CredentialOptions credentialOptions, string command, int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return SendCommand(credentialOptions, command, receiveTimeout);
            });

            task.Start();
            return task;
        }
    }
}
