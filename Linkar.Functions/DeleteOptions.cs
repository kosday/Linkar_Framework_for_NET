namespace Linkar
{
    /// <summary>
    /// Object that works as an argument in Delete function and defines the function options.
    /// </summary>
    public class DeleteOptions
    {
        private bool _OptimisticLock;
        private RecoverIdType _RecoverIdType;

        /// <summary>
        /// Initializes a new instance of the DeleteOptions class
        /// </summary>
        public DeleteOptions() : this(false)
        { }

        /// <summary>
        /// Initializes a new instance of the DeleteOptions class
        /// </summary>
        /// <param name="optimisticLockControl">In the execution of the Delete function, before updating the record, checks out if the record has not been modified by other user.</param>
        /// <param name="recoverIdType">Specifies the different recovery techniques of deleted codes.</param>
        public DeleteOptions(bool optimisticLockControl, RecoverIdType recoverIdType = null)
        {
            this._OptimisticLock = optimisticLockControl;
            if (recoverIdType == null)
                this._RecoverIdType = new RecoverIdType();
            else
                this._RecoverIdType = recoverIdType;
        }

        /// <summary>
        /// Composes the Delete options string in the way that LinkarSERVER can manage it.
        /// </summary>
        /// <returns>The string ready to be manage by LinkarSERVER.</returns>
        public override string ToString()
        {
            string str = (this._OptimisticLock ? "1" : "0") + DBMV_Mark.AM_str +
                this._RecoverIdType.ToString();

            return str;
        }
    }
}
