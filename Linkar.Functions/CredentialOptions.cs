using System;
using System.Collections.Generic;
using System.Text;

namespace Linkar
{
    /// <summary>
    /// Contains the necessary information to connect to the Database.
    /// </summary>
    public class CredentialOptions
    {
        private const char FS = '\x1C'; // ASCII FS

        public string Host { get; private set; }
        public string EntryPoint { get; private set; }
        public int Port { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Language { get; private set; }
        public string FreeText { get; private set; }
        public string PluginId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the CredentialsOptions class
        /// </summary>
        public CredentialOptions()
        {
            this.Host = "";
            this.EntryPoint = "";
            this.Port = 0;
            this.Username = "";
            this.Password = "";
            this.Language = "";
            this.FreeText = "";
            this.PluginId = "";
        }

        /// <summary>
        /// Initializes a new instance of the CredentialsOptions class
        /// </summary>
        /// <param name="host">Address or hostname where Linkar Server is listening.</param>
        /// <param name="entrypoint">The EntryPoint Name defined in Linkar Server.</param>
        /// <param name="port">Port number where the EntryPoint keeps listening.</param>
        /// <param name="username">Linkar Server username.</param>
        /// <param name="password">Password of the user Linkar Server.</param>
        /// <param name="language">Used to make the database routines know in which language they must answer. The Error messages coming from the Database are in English by default, but you can customize</param>
        /// <param name="freeText">Free text that will appear in the Linkar MANAGER to identify in an easy way who is making the petition. For example if the call is made from a ERP, here we can write "MyERP".</param>
        /// <param name="pluginId">Internal code to enable its use in Linkar Server. Used by Plugin developers.</param>
        public CredentialOptions(string host, string entrypoint, int port, string username, string password, string language, string freeText, string pluginId = "")
        {
            this.Host = host;
            this.EntryPoint = entrypoint;
            this.Port = port;
            this.Username = username;
            this.Password = password;
            this.Language = language;
            this.FreeText = freeText;
            this.PluginId = pluginId;
        }
        
        /// <summary>
        /// Builds a CredentialOptions object from string
        /// </summary>
        /// <param name="credentialOptions"></param>
        /// <returns></returns>
        public static CredentialOptions FromString(string credentialOptions)
        {
            CredentialOptions credentialOptions = new CredentialOptions();
            string[] credentialOptionsItems = credentialOptions.Split(FS);
            if (credentialOptionsItems.Length == 8)
            {
                int port;
                if (int.TryParse(credentialOptionsItems[2], out port))
                {
                    credentialOptions.Host = credentialOptionsItems[0];
                    credentialOptions.EntryPoint = credentialOptionsItems[1];
                    credentialOptions.Port = port;
                    credentialOptions.Username = credentialOptionsItems[3];
                    credentialOptions.Password = credentialOptionsItems[4];
                    credentialOptions.Language = credentialOptionsItems[5];
                    credentialOptions.FreeText = credentialOptionsItems[6];
                    credentialOptions.PluginId = credentialOptionsItems[7];
                }
            }
            return credentialOptions;
        }

        /// <summary>
        /// Converts a CredentialOptions object to string that can be managed by LinkarSERVER.
        /// </summary>
        /// <returns>The conversion to string of CredentialOptions object.</returns>
        public override string ToString()
        {
            string str = this.Host + FS +
             this.EntryPoint + FS +
             this.Port + FS +
             this.Username + FS +
             this.Password + FS +
             this.Language + FS +
             this.FreeText + FS +
             this.PluginId;
            return str;
        }

    }
}
