using System;
using System.Collections.Generic;
using System.Text;

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
        public int RecordCount { get; }
        
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
            this.RecordCount = 0;
        }

        /// <summary>
        /// Initializes a new instance of the LkDataCRUD class.
        /// </summary>
        /// <param name="crudOperationResult">The string result of the CRUD operation execution.</param>
        public LkDataCRUD(string crudOperationResult) : base(crudOperationResult)
        {
            this.RecordCount = StringFunctions.ExtractRecordCount(crudOperationResult);

            string[] lstIdDicts = StringFunctions.ExtractRecordsIdDicts(crudOperationResult);
            string[] lstDictionaries = StringFunctions.ExtractRecordsDicts(crudOperationResult);
            string[] lstCalculatedDicts = StringFunctions.ExtractRecordsCalculatedDicts(crudOperationResult);
            this.LkRecords = new LkItems(lstIdDicts, lstDictionaries, lstCalculatedDicts);

            string[] lstRecords = StringFunctions.ExtractRecords(crudOperationResult);
            string[] lstRecordIds = StringFunctions.ExtractRecordIds(crudOperationResult);
            string[] lstOriginalRecords = StringFunctions.ExtractOriginalRecords(crudOperationResult);
            for (int i = 0; i < lstRecordIds.Length; i++)
            {
                string record = (lstRecords.Length == lstRecordIds.Length ? lstRecords[i] : "");
                string originalRecord = (lstOriginalRecords.Length == lstRecordIds.Length ? lstOriginalRecords[i] : "");
                LkItem lkRecord = new LkItem(lstRecordIds[i], record, originalRecord);
                this.LkRecords.Add(lkRecord);
            }
        }
    }
}
