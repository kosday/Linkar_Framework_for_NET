using System;
using System.Threading.Tasks;

using Linkar;
using Linkar.Functions.Direct.MV;
using Linkar.Functions.Persistent.MV;

namespace Test
{
    class Program
    {
        static CredentialOptions crdOptions;
        static string filename;

        static int testReadOperations = 10;
        static int inputReadRequest;
        static int outputReadRequest;

        static void SyncExample()
        {
            Console.WriteLine("Async Demo");
            for (int i = 1; i <= testReadOperations;  i++)
                ReadRecorSync(i);
        }

        static void ReadRecorSync(int i)
        {
            string id = i.ToString();
            string result = Functions.Read(crdOptions, filename, id);
            string record = StringFunctions.ExtractRecords(result)[0];
            Console.WriteLine(">>>> Id: " + id + " Record: " + record);
        }

        static void AsyncExample()
        {
            Console.WriteLine("Async Demo");
            inputReadRequest = 0;
            outputReadRequest = 0;

            for (int i = 1; i <= testReadOperations; i++)
                ReadRecordAsync(i);

            while (outputReadRequest < testReadOperations)
                Console.WriteLine("Waiting... inputRequest: " + inputReadRequest + " outputRequest" + outputReadRequest);

            Console.WriteLine("Waiting... inputRequest: " + inputReadRequest + " outputRequest" + outputReadRequest);
            Console.WriteLine("All request received");
            Console.ReadKey();
        }

        static async void ReadRecordAsync(int i)
        {
            inputReadRequest++;
            string id = i.ToString();
            string result = await Functions.ReadAsync(crdOptions, filename, id);
            string record = StringFunctions.ExtractRecords(result)[0];
            Console.WriteLine(">>>> Id: " + id + " Record: " + record);
            outputReadRequest++;
        }

        static void Main(string[] args)
        {
            //crdOptions = new CredentialOptions("192.168.100.101", "QMEP1", 11301, "admin", "admin", "", "");
            crdOptions = new CredentialOptions("192.168.100.100", "QMWINQ", 11300, "admin", "1234", "", "");
            filename = "LK.CUSTOMERS";

            try
            {
                SyncExample();
                AsyncExample();

                string recordsIds = "1";
                string dictionaries = "";

                ReadOptions readOptions = new ReadOptions(true);

                //READ MV STATIC
                Console.WriteLine("READ (Direct)");
                string result = Functions.Read(crdOptions, filename, recordsIds, dictionaries, readOptions);
                string record = StringFunctions.ExtractRecords(result)[0];
                Console.WriteLine("RECORD: " + record);
                Console.WriteLine();

                LinkarClient lkClte = new LinkarClient();

                //LOGIN
                Console.WriteLine("LOGIN");
                lkClte.Login(crdOptions);

                //READ
                Console.WriteLine("READ");
                result = lkClte.Read(filename, recordsIds, dictionaries, readOptions);
                string[] errors = StringFunctions.ExtractErrors(result);
                if (errors.Length > 0)
                    PrintErrors(errors);
                else
                {
                    record = StringFunctions.ExtractRecords(result)[0];
                    Console.WriteLine("RECORD: " + record);
                    Console.WriteLine();
                }

                //NEW
                Console.WriteLine("NEW");
                string recordIds = StringFunctions.ComposeRecordIds("TEST99");
                record = MvOperations.LkReplace(record, "CUSTOMER TESTA99", 1);
                NewOptions newOptions = new NewOptions(null, true); // ReadAfter
                string newBuffer = StringFunctions.ComposeNewBuffer(recordIds, record);
                result = lkClte.New(filename, newBuffer, newOptions);
                errors = StringFunctions.ExtractErrors(result);
                if (errors.Length > 0)
                    PrintErrors(errors);
                else
                {
                    record = StringFunctions.ExtractRecords(result)[0];
                    Console.WriteLine("NEW RECORD: " + record);
                    Console.WriteLine();
                }
                PrintErrors(errors);

                //DELETE
                Console.WriteLine("DELETE");
                recordIds = StringFunctions.ComposeRecordIds("TEST97", "TEST98", "TEST99"); // TEST97 and TEST98 not exists
                result = lkClte.Delete(filename, recordIds);
                errors = StringFunctions.ExtractErrors(result);
                if (errors.Length > 0)
                    PrintErrors(errors);

                string[] lstRecordIds = StringFunctions.ExtractRecordIds(result);
                foreach (string id in lstRecordIds)
                    Console.WriteLine("ID: " + id + " DELETED");

                //LOGOUT
                lkClte.Logout();
            }
            catch (LkException lkex)
            {
                Console.WriteLine("Error Code: " + lkex.ErrorCode);
                Console.WriteLine("Error Message: " + lkex.ErrorMessage);
                Console.WriteLine("Internal Error Code: " + lkex.InternalCode);
                Console.WriteLine("Internal Error Message: " + lkex.InternalMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        static void PrintErrors(string[] errors)
        {
            foreach (string error in errors)
                Console.WriteLine(StringFunctions.FormatError(error));
        }
    }
}
