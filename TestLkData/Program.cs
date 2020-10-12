using System;

using Linkar;
using Linkar.Functions.Persistent.MV;
using Linkar.LkData;

namespace TestLkData
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CredentialOptions crdOptions = new CredentialOptions("192.168.100.101", "QMEP1", 11301, "admin", "admin", "", "");
                LinkarClient lkClt = new LinkarClient(60);
                lkClt.Login(crdOptions);
                string filename = "LK.CUSTOMERS";

                Console.WriteLine("NEW OPERATION (NEW98 and NEW)");
                //FIX: The word "CODE" should not be used for "ItemID". Please change this reference, the dict item, and all related references.
                LkItems lstLkRecords = new LkItems(new string[] { "CODE" }, new string[] { "NAME", "ADDRRESS" });

                // RECORD1 creation
                string record1 = "CUSTOMER NEW98" + DBMV_Mark.AM_str + "ADDRESS NEW98" + DBMV_Mark.AM_str + "998 - 998 - 998";
                LkItem lkRecord1 = new LkItem("NEW98", record1);
                lstLkRecords.Add(lkRecord1);

                // RECORD2 creation
                LkItem lkRecord2 = new LkItem("NEW99");
                lstLkRecords.Add(lkRecord2);
                lkRecord2["NAME"] = "CUSTOMER NEW99"; // Attribute 1 value
                lkRecord2["ADDRRESS", 1] = "ADDRESS NEW99"; // Attribute 2, Multivalue 1
                lkRecord2["ADDRRESS", 2] = "STATE COUNTRY"; // Attribute 2, Multivalue 2
                lkRecord2[3] = "999 - 999 - 999"; // Attribute3 value

                string records = lstLkRecords.ComposeNewBuffer();
                NewOptions newOptions = new NewOptions(null, true, false, false, false, true); // ReadAfter and OriginalRecords
                string newResult = lkClt.New(filename, records, newOptions);
                LkDataCRUD lkData = new LkDataCRUD(newResult);
                Console.WriteLine("TOTAL RECORDS: " + lkData.TotalItems);
                PrintErrors(lkData.Errors);
                PrintRecords(lkData.LkRecords);

                lkRecord1 = lkData.LkRecords["NEW98"];
                lkData.LkRecords.RemoveId("NEW98");

                // After CRUD Operation we always get real dictionaries
                lkData.LkRecords["NEW99"]["NAME"] = "CUSTOMER UPDATE99";
                lkData.LkRecords["NEW99"]["ADDR"] = "ADDRESS UPDATE 99";
                lkData.LkRecords["NEW99"]["PHONE"] = "(1) 999 - 999 - 999";

                Console.WriteLine();
                Console.WriteLine("UPDATE OPERATION (NEW99)");
                bool OptimisticLockControl = true;
                UpdateOptions updateOptions = new UpdateOptions(OptimisticLockControl, true, false, false, false, true); // OptimisticLockControl, ReadAfter and OriginalRecords           
                records = lkData.LkRecords.ComposeUpdateBuffer(OptimisticLockControl);
                string updateResult = lkClt.Update(filename, records, updateOptions);
                lkData = new LkDataCRUD(updateResult);
                PrintErrors(lkData.Errors);
                PrintRecords(lkData.LkRecords);

                Console.WriteLine();
                Console.WriteLine("READ OPERATION (NEW98 and NEW99)");
                string recordIds = StringFunctions.ComposeRecordIds("NEW98", "NEW99");
                ReadOptions readOptions = new ReadOptions(false, false, false, OptimisticLockControl);
                string dictionaries = "";
                string readResult = lkClt.Read(filename, recordIds, dictionaries, readOptions);
                LkDataCRUD lkDataRead = new LkDataCRUD(readResult);
                Console.WriteLine("TOTAL RECORDS: " + lkDataRead.TotalItems);
                lkRecord1 = lkDataRead.LkRecords[0];
                PrintRecord(lkRecord1);
                lkRecord2 = lkDataRead.LkRecords["NEW99"];
                PrintRecord(lkRecord2);
                string id = lkRecord2.RecordId;
                Console.WriteLine("record2.RecordId: " + id);
                id = lkRecord2["@ID"];
                Console.WriteLine("record2[\"@ID\"]: " + id);
                id = lkRecord2["CODE"];
                Console.WriteLine("record2[\"CODE\"]: " + id);
                string name = lkRecord2["NAME"];
                Console.WriteLine("record2[\"NAME\" , 1]: " + name);
                string addressLine1 = lkRecord2["ADDR", 1];
                Console.WriteLine("record2[\"ADDR\" , 2]: " + addressLine1);
                string addressLine2 = lkRecord2["ADDR", 2];
                Console.WriteLine("record2[\"ADDR\" , 2]: " + addressLine2);
                name = lkDataRead.LkRecords[1]["NAME"];
                Console.WriteLine("lkReadResult.LkRecords[1][\"NAME\"]: " + name);

                Console.WriteLine();
                Console.WriteLine("DELETE OPERATION (NEW98 and NEW99)");
                OptimisticLockControl = true;
                DeleteOptions deleteOptions = new DeleteOptions(OptimisticLockControl); // OptimisticLockControl
                lkData.LkRecords.Add(lkRecord1);
                records = lkData.LkRecords.ComposeDeleteBuffer(OptimisticLockControl);
                string deleteResult = lkClt.Delete(filename, records, deleteOptions);
                lkData = new LkDataCRUD(deleteResult);
                PrintErrors(lkData.Errors);
                PrintRecords(lkData.LkRecords);

                Console.WriteLine();
                Console.WriteLine("SUBROUTINE OPERATION");
                string subArgs = StringFunctions.ComposeSubroutineArgs("0", "aaaaaaa", "");
                string subroutineResult = lkClt.Subroutine("SUB.DEMOLINKAR", 3, subArgs);
                LkDataSubroutine lkDataSubroutine = new LkDataSubroutine(subroutineResult);
                PrintErrors(lkDataSubroutine.Errors);
                for (int i = 0; i < lkDataSubroutine.Arguments.Length; i++)
                    Console.WriteLine("Arg " + (i + 1).ToString() + " " + lkDataSubroutine.Arguments[i]);

                Console.WriteLine();
                Console.WriteLine("EXECUTE WHO");
                string executeResult = lkClt.Execute("WHO");
                LkDataExecute lkDataExecute = new LkDataExecute(executeResult);
                PrintErrors(lkDataExecute.Errors);
                Console.WriteLine("CAPTURING: " + lkDataExecute.Capturing);
                Console.WriteLine("RETURNING: " + lkDataExecute.Returning);

                lkClt.Logout();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void PrintErrors(string[] errors)
        {
            foreach (string error in errors)
                Console.WriteLine(StringFunctions.FormatError(error));
        }

        static void PrintRecord(LkItem lkItem)
        {
            Console.WriteLine("RecordId: " + lkItem.RecordId + " Record:" + lkItem.Record);
        }

        static void PrintRecords(LkItems lkItems)
        {
            foreach (LkItem lkItem in lkItems)
                PrintRecord(lkItem);
        }
    }
}
