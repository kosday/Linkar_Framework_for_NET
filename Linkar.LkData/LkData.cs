using System;
using System.Collections.Generic;
using System.Text;

using Linkar;

namespace Linkar.LkData
{
    /// <summary>
    /// Abstract class with common properties of all derived class.
    /// </summary>
    public abstract class LkData
    {
        /// <summary>
        /// The string that is obtained as result from the operation execution.
        /// </summary>
        protected string _OperationResult;

        /// <summary>
        /// List of the error of the operation execution.
        /// </summary>
        public string[] Errors { get; }

        /// <summary>
        /// Initializes a new instance of the LkData class.
        /// </summary>
        /// <param name="opResult">The string result of the operation execution.</param>
        public LkData(string opResult)
        {
            this._OperationResult = opResult;
            this.Errors = StringFunctions.ExtractErrors(opResult);
        }
    }

    /// <summary>
    /// Class to management the result of the operations Read, Update, New, Delete, Select and Dictionaries.
    /// </summary>
    public class LkDataCRUD : LkData
    {
        /// <summary>
        /// Number of the 
        /// </summary>
        public int TotalItems { get; }
        
        /// <summary>
        /// LkItem list from the CRUD operation execution.
        /// </summary>
        public LkItems LkRecords;

        /// <summary>
        /// Initializes a new instance of the LkDataCRUD class.
        /// </summary>
        public LkDataCRUD() : base("")
        {
            this.LkRecords = new LkItems();
            this.TotalItems = 0;
        }

        /// <summary>
        /// Initializes a new instance of the LkDataCRUD class.
        /// </summary>
        /// <param name="crudOperationResult">The string result of the CRUD operation execution.</param>
        public LkDataCRUD(string crudOperationResult) : base(crudOperationResult)
        {
            this.TotalItems = StringFunctions.ExtractTotalRecords(crudOperationResult);

            string[] lstIdDicts = StringFunctions.ExtractRecordsIdDicts(crudOperationResult);
            string[] lstDictionaries = StringFunctions.ExtractRecordsDicts(crudOperationResult);
            string[] lstCalculatedDicts = StringFunctions.ExtractRecordsCalculatedDicts(crudOperationResult);
            this.LkRecords = new LkItems(lstIdDicts, lstDictionaries, lstCalculatedDicts);

            string[] lstRecords = StringFunctions.ExtractRecords(crudOperationResult);
            string[] lstRecordIds = StringFunctions.ExtractRecordIds(crudOperationResult);
            string[] lstOriginalRecords = StringFunctions.ExtractOriginalRecords(crudOperationResult);
            string[] lstRecordsCalculated = StringFunctions.ExtractRecordsCalculated(crudOperationResult);
            for (int i = 0; i < lstRecordIds.Length; i++)
            {
                string record = (lstRecords.Length == lstRecordIds.Length ? lstRecords[i] : "");
                string originalRecord = (lstOriginalRecords.Length == lstRecordIds.Length ? lstOriginalRecords[i] : "");
                string calculateds = (lstRecordsCalculated.Length == lstRecordIds.Length ? lstRecordsCalculated[i] : "");
                LkItem lkRecord = new LkItem(lstRecordIds[i], record, calculateds, originalRecord);
                this.LkRecords.Add(lkRecord);
            }
        }
    }

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

    /// <summary>
    /// Class to management the result of the operations Conversion.
    /// </summary>
    public class LkDataConversion : LkData
    {
        public string Conversion { get; }

        /// <summary>
        /// Initializes a new instance of the LkDataCRUD class.
        /// </summary>
        /// <param name="conversionResult">The string result of the Conversion operation execution.</param>
        public LkDataConversion(string conversionResult) : base(conversionResult)
        {
            this.Conversion = StringFunctions.ExtractConversion(conversionResult);
        }
    }

    /// <summary>
    /// Class to management the result of the operations Format.
    /// </summary>
    public class LkDataFormat : LkData
    {
        public string Format { get; }

        /// <summary>
        /// Initializes a new instance of the LkDataCRUD class.
        /// </summary>
        /// <param name="formatResult">The string result of the Format operation execution.</param>
        public LkDataFormat(string formatResult) : base(formatResult)
        {
            this.Format = StringFunctions.ExtractFormat(formatResult);
        }
    }

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

    /// <summary>
    /// Class to management the result of the operations LkSchemas and LkProperties.
    /// </summary>
    public class LkDataSchProp : LkDataCRUD
    {
        public string[] RowProperties { get; }
        public string[] RowHeaders { get; }

        /// <summary>
        /// Initializes a new instance of the LkDataSchProp class.
        /// </summary>
        /// <param name="lkSchemasResult">The string result of the Lkchemas or LkProperties operation execution.</param>
        public LkDataSchProp(string lkSchemasResult) : base(lkSchemasResult)
        {
            this.RowProperties = StringFunctions.ExtractRowProperties(lkSchemasResult);
            this.RowHeaders = StringFunctions.ExtractRowHeaders(lkSchemasResult);
        }
    }
}
