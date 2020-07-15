using System;

namespace Linkar.LkData
{
    /// <summary>
    /// A LkItem is compose of three items: RecordId, Record and OriginalRecord. Depending on the operation, the three items may be present, or only some of them.
    /// Each LkItem can hold a list of dictionaries (for real fields, for ID fields, and for calculated fields)
    /// </summary>
    public class LkItem
    {
        internal string[] _LstDictsId;
        internal string[] _LstDicts;
        internal string[] _LstDictsCalculated;

        /// <summary>
        /// Array with the dictionary names for record Ids.
        /// </summary>
        public string[] LstDictsId { get => _LstDictsId; }

        /// <summary>
        /// Array with the dictionarty names for record fields.
        /// </summary>
        public string[] LstDicts { get => _LstDicts; }

        /// <summary>
        /// Array with the dictionary names for calculated fields of the record.
        /// </summary>
        public string[] LstDictsCalculated { get => _LstDictsCalculated; }

        /// <summary>
        /// The ID of the record.
        /// </summary>
        public string RecordId;
        
        /// <summary>
        /// The content of a record from database.
        /// </summary>
        public string Record;

        /// <summary>
        /// A copy of the original record to be used in operations where the optimistic lock option is enabled.
        /// </summary>
        public string OriginalRecord;

        /// <summary>
        /// The content of calculated fields from database.
        /// </summary>
        public string Calculated;

        /// <summary>
        /// Initializes a new instance of the LkItem class.
        /// </summary>
        public LkItem()
        {
            this._LstDictsId = new string[0];
            this._LstDicts = new string[0];
            this._LstDictsCalculated = new string[0];
            this.RecordId = "";
            this.Record = "";
            this.OriginalRecord = "";
            this.Calculated = "";
        }

        /// <summary>
        /// Initializes a new instance of the LkItem class.
        /// </summary>
        /// <param name="recordId">The ID of the record.</param>
        /// <param name="record">The content of a record from database.</param>
        /// <param name="originalRecord">A copy of the original record to be used in operations where the optimistic lock option is enabled.</param>
        /// <param name="lstDictsId">Optionally, array with the dictionary names for record Ids.</param>
        /// <param name="lstDicts">Optionally, array with the dictionarty names for record fields.<param>
        /// <param name="lstDictsCalculated">Optionally, array with the dictionary names for calculated fields of the record.</param>
        public LkItem(string recordId, string record = "", string originalRecord = "", string[] lstDictsId = null, string[] lstDicts = null, string[] lstDictsCalculated = null)
        {
            this.RecordId = recordId;
            this.Record = record;
            this.OriginalRecord = originalRecord;
            this.Calculated = "";
            if (lstDictsId == null)
                this._LstDictsId = new string[0];
            else
                this._LstDictsId = lstDictsId;
            if (lstDicts == null)
                this._LstDicts = new string[0];
            else
                this._LstDicts = lstDicts;
            if (lstDictsCalculated == null)
                this._LstDictsCalculated = new string[0];
            else
                this._LstDictsCalculated = lstDictsCalculated;
        }

        /// <summary>
        /// Indexer that set or get fields, multivalues or subvalues from the record.
        /// </summary>
        /// <param name="field">The field number to get or set.</param>
        /// <param name="mv">The multivalue number to get or set.</param>
        /// <param name="sv">The subvalue number to get or set.</param>
        /// <returns>The extrated value.</returns>
        public string this[int field, int mv = 0, int sv = 0]
        {
            get { return MvOperations.LkExtract(this.Record, field, mv, sv); }
            set { this.Record = MvOperations.LkReplace(this.Record, value, field, mv, sv); }
        }

        /// <summary>
        /// Indexer that usign the dictionary name can set or get fields, multivalues or subvalues from the record.
        /// </summary>
        /// <param name="dictName">The dictionary name to get or set.</param>
        /// <param name="mv">The multivalue number to get or set.</param>
        /// <param name="sv">The subvalue number to get or set.</param>
        /// <returns>The extrated value.</returns>
        public string this[string dictName, int mv = 0, int sv = 0]
        {
            get
            {
                for (int i = 0; i < this._LstDictsId.Length; i++)
                    if (this._LstDictsId[i] == dictName)
                    {
                        return this.RecordId;
                    }
                for (int i = 0; i < this._LstDicts.Length; i++)
                    if (this._LstDicts[i] == dictName)
                    {
                        return MvOperations.LkExtract(this.Record, (i + 1), mv, sv);
                    }
                for (int i = 0; i < this._LstDictsCalculated.Length; i++)
                    if (this._LstDictsCalculated[i] == dictName)
                    {
                        return MvOperations.LkExtract(this.Calculated, (i + 1), mv, sv);
                    }
                throw new Exception("Dictionary name not found");
            }

            set
            {
                if (this._LstDictsId.Length == 0)
                    throw new Exception("Dictionaries ID List Empty");
                for (int i = 0; i < this._LstDictsId.Length; i++)
                    if (this._LstDictsId[i] == dictName)
                    {
                        this.RecordId = value;
                        return;
                    }
                if (this._LstDictsId.Length == 0)
                    throw new Exception("Dictionaries List Empty");
                for (int i = 0; i < this._LstDicts.Length; i++)
                    if (this._LstDicts[i] == dictName)
                    {
                        this.Record = MvOperations.LkReplace(this.Record, value, (i + 1), mv, sv);
                        return;
                    }
                throw new Exception("Dictionary name not found");
            }
        }

        /// <summary>
        /// Composes the final buffer string of the record that will be readed, in MV Read operations, with the RecordId information.
        /// </summary>
        /// <returns>The final string buffer for MV Read operations.</returns>
        public string ComposeReadBuffer()
        {
            return this.RecordId;
        }

        /// <summary>
        /// Composes the final buffer string of the record that will be updated, in MV Update operations, with the RecordId, the Record, and optionally the OriginalRecord information.
        /// </summary>
        /// <param name="includeOriginalBuffer">Determines if the OriginalRecord must be include or not in the final buffer string.</param>
        /// <returns>The final string buffer for MV Update operations.</returns>
        public string ComposeUpdateBuffer(bool includeOriginalBuffer = false)
        {
            return StringFunctions.ComposeUpdateBuffer(this.RecordId, this.Record, this.OriginalRecord);
        }

        /// <summary>
        /// Composes the final buffer string of the record that will be created, in MV New operations, with the RecordId and the Record information.
        /// </summary>
        /// <returns>The final string buffer for MV New operations.</returns>
        public string ComposeNewBuffer()
        {
            return StringFunctions.ComposeNewBuffer(this.RecordId, this.Record);
        }

        /// <summary>
        /// Composes the final buffer string of the record that will be deleted, in MV Delete operations, with the RecordId and optionally with the OriginalRecord information.
        /// </summary>
        /// <param name="includeOriginalBuffer">Determines if the OriginalRecord must be include or not in the final buffer string.</param>
        /// <returns>The final string buffer for MV Delete operations.</returns>
        public string ComposeDeleteBuffer(bool includeOriginalBuffer = false)
        {
            if (includeOriginalBuffer)
                return StringFunctions.ComposeDeleteBuffer(this.RecordId, this.OriginalRecord);
            else
                return StringFunctions.ComposeDeleteBuffer(this.RecordId);
        }
    }
}
