using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkar.LkData
{
    /// <summary>
    /// This class is to implement List of the LkItems.
    /// </summary>
    public class LkItems : List<LkItem>
    {
        private string[] _LstDictsId = new string[0];
        private string[] _LstDicts = new string[0];
        private string[] _LstDictsCalculated = new string[0];

        /// <summary>
        /// Array with the dictionary names for record Ids.
        /// The same array for each LkItem that is stored in the list.
        /// </summary>
        public string[] LstDictsId { get => _LstDictsId; }

        /// <summary>
        /// Array with the dictionarty names for record fields.
        /// The same array for each LkItem that is stored in the list.
        /// </summary>
        public string[] LstDicts { get => _LstDicts; }

        /// <summary>
        /// Array with the dictionary names for calculated fields of the record.
        /// The same array for each LkItem that is stored in the list.
        /// </summary>
        public string[] LstDictsCalculated { get => _LstDictsCalculated; }

        /// <summary>
        /// Initializes a new instance of the LkItem class.
        /// </summary>
        public LkItems()
        { }

        /// <summary>
        /// Initializes a new instance of the LkItem class.
        /// </summary>
        /// <param name="lstDictsId">Array with the dictionary names for record Ids. The same array for each LkItem that is stored in the list.</param>
        /// <param name="lstDicts">Array with the dictionarty names for record fields. The same array for each LkItem that is stored in the list.<param>
        /// <param name="lstDictsCalculated">Array with the dictionary names for calculated fields of the record. The same array for each LkItem that is stored in the list.</param>
        public LkItems(string[] lstIdDicts, string[] lstDictionaries, string[] lstCalculatedDicts = null)
        {
            this._LstDictsId = lstIdDicts;
            this._LstDicts = lstDictionaries;
            if (lstCalculatedDicts == null)
                this._LstDictsCalculated = new string[0];
            else
                this._LstDictsCalculated = lstCalculatedDicts;
        }

        /// <summary>
        /// Indexer to get a LkItem using its RecordId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LkItem this[string id]
        {
            get
            {
                for (int i = 0; i < Count; i++)
                    if (base[i].RecordId == id)
                        return base[i];

                return null;
            }
        }

        /// <summary>
        /// Adds a new LkItem to the list. The dictionaries arrays of the list, will be copied to the LkItem added.
        /// </summary>
        /// <param name="lkItem"></param>
        public new void Add(LkItem lkItem)
        {
            if (!string.IsNullOrEmpty(lkItem.RecordId) && !Exists(obj => obj.RecordId == lkItem.RecordId))
            {
                lkItem._LstDictsId = this._LstDictsId;
                lkItem._LstDicts = this._LstDicts;
                lkItem._LstDictsCalculated = this._LstDictsCalculated;
                base.Add(lkItem);
            }
        }

        /// <summary>
        /// Creates and adds LkItem with specific recordIds to the list.
        /// </summary>
        /// <param name="recordIds">Array with the list of recordIds</param>
        public void Add(params string[] recordIds)
        {
            foreach (string id in recordIds)
            {
                LkItem lkRecord = new LkItem(id);
                Add(lkRecord);
            }
        }

        /// <summary>
        /// Removes the LkItem specified by its recordID from the list.
        /// </summary>
        /// <param name="recordId"></param>
        public void RemoveId(string recordId)
        {
            LkItem itemToRemove = null;
            for (int i = 0; i < base.Count; i++)
            {
                if (base[i].RecordId == recordId)
                {
                    itemToRemove = base[i];
                    break;
                }
            }
            if (itemToRemove != null)
                base.Remove(itemToRemove);

        }

        /// <summary>
        /// Composes the final buffer string of the all record in the list that will be readed, in MV Read operations, with the RecordId information.
        /// </summary>
        /// <returns>The final string buffer for MV Read operations.</returns>
        public string ComposeReadBuffer()
        {
            string buf = "";
            for (int i = 0; i < Count; i++)
            {
                if (i > 0)
                    buf += ASCII_Chars.RS_chr;
                buf += base[i].RecordId;
            }

            return buf;
        }

        /// <summary>
        /// Composes the final buffer string of the all records in the list that will be updated, in MV Update operations, with the RecordId, the Record, and optionally the OriginalRecord information.
        /// </summary>
        /// <param name="includeOriginalBuffer">Determines if the OriginalRecord must be include or not in the final buffer string.</param>
        /// <returns>The final string buffer for MV Update operations.</returns>
        public string ComposeUpdateBuffer(bool includeOriginalBuffer = false)
        {
            string buf = "";
            for (int i = 0; i < Count; i++)
            {
                if (i > 0)
                    buf += ASCII_Chars.RS_chr;
                buf += base[i].RecordId;
            }

            buf += ASCII_Chars.FS_chr;

            for (int i = 0; i < Count; i++)
            {
                if (i > 0)
                    buf += ASCII_Chars.RS_chr;
                buf += base[i].Record;
            }

            if (includeOriginalBuffer)
            {
                buf += ASCII_Chars.FS_chr;

                for (int i = 0; i < Count; i++)
                {
                    if (i > 0)
                        buf += ASCII_Chars.RS_chr;
                    buf += base[i].OriginalRecord;
                }
            }

            return buf;
        }

        /// <summary>
        /// Composes the final buffer string of the all records that will be created, in MV New operations, with the RecordId and the Record information.
        /// </summary>
        /// <returns>The final string buffer for MV New operations.</returns>
        public string ComposeNewBuffer()
        {
            return ComposeUpdateBuffer(false);
        }

        /// <summary>
        /// Composes the final buffer string of the all records that will be deleted, in MV Delete operations, with the RecordId and optionally with the OriginalRecord information.
        /// </summary>
        /// <param name="includeOriginalBuffer">Determines if the OriginalRecord must be include or not in the final buffer string.</param>
        /// <returns>The final string buffer for MV Delete operations.</returns>
        public string ComposeDeleteBuffer(bool includeOriginalBuffer = false)
        {
            string buf = "";
            for (int i = 0; i < Count; i++)
            {
                if (i > 0)
                    buf += ASCII_Chars.RS_chr;
                buf += base[i].RecordId;
            }

            if (includeOriginalBuffer)
            {
                buf += ASCII_Chars.FS_chr;

                for (int i = 0; i < Count; i++)
                {
                    if (i > 0)
                        buf += ASCII_Chars.RS_chr;
                    buf += base[i].OriginalRecord;
                }
            }

            return buf;
        }
    }
}
