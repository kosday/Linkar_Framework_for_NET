using System;
using System.Collections.Generic;
using System.Text;

namespace Linkar
{
    /// <summary>
    /// Contains the necessary information to stablished a permanent session with LinkarSERVER. Used by Login operation and Permanent operations.
    /// </summary>
    public class ConnectionInfo
    {
        private const char FS = '\x1C'; // ASCII FS

        private CredentialOptions _CredentialOptions;

        public string SessionId { get; private set; }
        public string LkConnectionId { get; private set; }
        public string PublicKey { get; private set; }

        /// <summary>
        /// Initializes a new instance of the CredentialsOptions class
        /// </summary>
        public ConnectionInfo()
        {
            this.SessionId = "";
            this.LkConnectionId = "";
            this.PublicKey = "";
            this._CredentialOptions = new CredentialOptions();
        }

        /// <summary>
        /// Initializes a new instance of the CredentialsOptions class
        /// </summary>
        /// <param name="sessionId">A unique Identifier for the stablished session in LinkarSERVER. This value is set after Login operation.</param>
        /// <param name="lkConnectionId">Internal LinkarSERVER ID to keep the session. This value is set after Login operation.</param>
        /// <param name="publicKey">The public key used to encrypt transmission data between LinkarCLIENT and LinkarSERVER. This value is set after Login operation.</param>
        /// <param name="crdOptions">The CredentialOptions object with the necessary information to connect to the Database.</param>
        public ConnectionInfo(string sessionId, string lkConnectionId, string publicKey, CredentialOptions crdOptions)
        {
            this.SessionId = sessionId;
            this.LkConnectionId = lkConnectionId;
            this.PublicKey = publicKey;
            this._CredentialOptions = crdOptions;
        }

        /// <summary>
        /// Converts a ConnectionInfo object to string that can be managed by LinkarSERVER.
        /// </summary>
        /// <returns>The conversion to string of ConnectionInfo object</returns>
        public override string ToString()
        {
            string connInfo = this._CredentialOptions.ToString() + FS + this.SessionId + FS + LkConnectionId + FS + PublicKey;
            return connInfo;
        }
    }
}
