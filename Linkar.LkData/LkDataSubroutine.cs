namespace Linkar.LkData
{
    /// <summary>
    /// Initializes a new instance of the LkDataSubroutine class.
    /// </summary>
    public class LkDataSubroutine : LkData
    {
        /// <summary>
        /// Argument list of the Subroutine operation execution.
        /// </summary>
        public string[] Arguments { get; }

        /// <summary>
        /// Initializes a new instance of the LkDataCRUD class.
        /// </summary>
        /// <param name="subroutineResult">The string result of the Subroutine operation execution.</param>
        public LkDataSubroutine(string subroutineResult) : base(subroutineResult)
        {
            this.Arguments = StringFunctions.ExtractSubroutineArgs(subroutineResult);
        }
    }
}
