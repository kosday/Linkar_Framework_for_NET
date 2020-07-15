namespace Linkar.LkData
{
    /// <summary>
    /// Class to management the result of the operations Execute.
    /// </summary>
    public class LkDataExecute : LkData
    {
        public string Capturing { get; }
        public string Returning { get; }

        /// <summary>
        /// Initializes a new instance of the LkDataExecute class.
        /// </summary>
        /// <param name="executeResult">The string result of the Execute operation execution.</param>
        public LkDataExecute(string executeResult) : base(executeResult)
        {
            this.Capturing = StringFunctions.ExtractCapturing(executeResult);
            this.Returning = StringFunctions.ExtractReturning(executeResult);
        }
    }
}
