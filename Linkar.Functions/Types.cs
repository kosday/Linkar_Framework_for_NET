using System;
using System.Collections.Generic;
using System.Text;

namespace Linkar
{
    public enum OPERATION_CODE
    {
        NONE = 0,
        LOGIN = 1, READ = 2, UPDATE = 3, NEW = 4, DELETE = 5, CONVERSION = 6, FORMAT = 7, LOGOUT = 8, VERSION = 9,
        SELECT = 10, SUBROUTINE = 11, EXECUTE = 12, DICTIONARIES = 13,
        LKSCHEMA = 14, LKPROPERTIES = 15, GETTABLE = 16, RESETCOMMONBLOCKS = 17,

        COMMAND_XML = 150, COMMAND_JSON = 151,
    };

    /// <summary>
    /// Output format type for all operations, except Read, New, Update, Select, LkSchemas, LkProperties and GetTable
    /// Also the input format type for New, Update and Delete operations.
    /// </summary>
    public enum DATAFORMAT_TYPE
    {
        MV = 1,
        XML = 2,
        JSON = 3
    };

    /// <summary>
    /// Output format type for Read, New, Update and Select operations.
    /// </summary>
    public enum DATAFORMATCRU_TYPE
    {
        MV = 1,
        XML = 2,
        JSON = 3,
        XML_DICT = 5,
        XML_SCH = 6,
        JSON_DICT = 7,
        JSON_SCH = 8
    };

    /// <summary>
    /// Output format type for LkSchemas and LkProperties operations.
    /// </summary>
    public enum DATAFORMATSCH_TYPE
    {
        MV = 1,
        XML = 2,
        JSON = 3,
        TABLE = 4
    };

    public enum CONVERSION_TYPE
    {
        INPUT,
        OUTPUT
    };

    public enum ENVELOPE_FORMAT
    {
        XML,
        JSON
    };


}
