namespace Linkar.Commands
{
    /// <summary>
    /// The codes of each operation
    /// </summary>
    public enum OPERATION_CODE
    {
        NONE = 0,
        LOGIN = 1, LOGOUT = 8, VERSION = 9,

        COMMAND_XML = 150, COMMAND_JSON = 151,
    };

    /// <summary>
    /// Used by the SendCommand operations to indicate in which format the operation is being performed.
    /// </summary>
    public enum ENVELOPE_FORMAT
    {
        /// <summary>
        /// The operation is specified in XML format.
        /// </summary>
        XML,

        /// <summary>
        /// The operation is specified in JSON format.
        /// </summary>
        JSON
    };

    /// <summary>
    /// Output format type for all operations, except Read, New, Update, Select, LkSchemas, LkProperties and GetTable
    /// Also The input format type for New, Update and Delete operations.
    /// </summary>
    public enum DATAFORMAT_TYPE
    {
        /// <summary>
        /// Show the results of the operation in MV format.
        /// </summary>
        MV = 1,

        /// <summary>
        /// Show the results of the operation in XML format.
        /// </summary>
        XML = 2,

        /// <summary>
        /// Show the results of the operation in JSON format.
        /// </summary>
        JSON = 3
    };
}
