using System.Threading.Tasks;

namespace Linkar.Functions.Persistent.XML
{
    public partial class LinkarClient
    {
        /// <summary>
        /// Starts the communication with a server allowing making use of the rest of functions until the Close method is executed or the connection with the server gets lost, in a asynchronous way.
        /// </summary>
        /// <param name="credentialOptions">Object with data necessary to access the Linkar Server: Username, Password, EntryPoint, Language, FreeText.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <remarks>
        /// Login is actually a "virtual" operation which creates a new Client Session ID. No DBMS login is performed unless Linkar SERVER determines new Database Sessions are required - these operations are not related.
        /// </remarks> 
        public Task LoginAsync(CredentialOptions credentialOptions, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task(() =>
            {
                this.Login(credentialOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Closes the communication with the server, that previously has been opened with a Login function, ina asynchronous way.
        /// </summary>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// Logout is actually a "virtual" operation which disposes the current Client Session ID. No DBMS logout is performed.
        /// </remarks>
        public Task LogoutAsync(string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task(() =>
            {
                this.Logout(customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Reads one or several records of a file ina asynchronous way with XML input and output format.
        /// </summary>
        /// <param name="filename">File name to read.</param>
        /// <param name="records">A list of item IDs to read.</param>
        /// <param name="dictionaries">List of dictionaries to read, separated by space. If this list is not set, all fields are returned. You may use the format LKFLDx where x is the attribute number.</param>
        /// <param name="readOptions">Object that defines the different reading options of the Function: Calculated, dictClause, conversion, formatSpec, originalRecords.</param>
        /// <param name="xmlFormat">Different XML output formats.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public Task<string> ReadAsync(string filename, string records, string dictionaries = "", ReadOptions readOptions = null,
            XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.Read(filename, records, dictionaries, readOptions, xmlFormat, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Update one or several records of a file, ina asynchronous way with XML input and output format.
        /// </summary>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Buffer of record data to update. Inside this string are the recordIds, the modified records, and the originalRecords.</param>
        /// <param name="updateOptions">Object with write options, including optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="xmlFormat">Different XML output formats.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// Inside the records argument, the recordIds and the modified records always must be specified. But the originalRecords not always.
        /// When <see cref="UpdateOptions">updateOptions</see> argument is specified and the <see cref="UpdateOptions.OptimisticLockControl"/> property is set to true, a copy of the record must be provided before the modification (originalRecords argument)
        /// to use the Optimistic Lock technique. This copy can be obtained from a previous <see cref="ReadAsync"/> operation. The database, before executing the modification, 
        /// reads the record and compares it with the copy in originalRecords, if they are equal the modified record is executed.
        /// But if they are not equal, it means that the record has been modified by other user and its modification will not be saved.
        /// The record will have to be read, modified and saved again.
        /// </remarks>
        public Task<string> UpdateAsync(string filename, string records, UpdateOptions updateOptions = null,
            XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.Update(filename, records, updateOptions, xmlFormat, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Update one or more attributes of one or more file records, ina asynchronous way with XML input and output format.
        /// </summary>
        /// <param name="filename">Name of the file being updated.</param>
        /// <param name="records">Buffer of record data to update. Inside this string are the recordIds, the modified records, and the originalRecords.</param>
        /// <param name="updateOptions">Object with write options, including optimisticLockControl, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="xmlFormat">Different XML output formats.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// Inside the records argument, the recordIds and the modified records always must be specified. But the originalRecords not always.
        /// When <see cref="UpdateOptions">updateOptions</see> argument is specified and the <see cref="UpdateOptions.OptimisticLockControl"/> property is set to true, a copy of the record must be provided before the modification (originalRecords argument)
        /// to use the Optimistic Lock technique. This copy can be obtained from a previous <see cref="ReadAsync"/> operation. The database, before executing the modification, 
        /// reads the record and compares it with the copy in originalRecords, if they are equal the modified record is executed.
        /// But if they are not equal, it means that the record has been modified by other user and its modification will not be saved.
        /// The record will have to be read, modified and saved again.
        /// </remarks>
        public Task<string> UpdatePartialAsync(string filename, string records, UpdateOptions updateOptions = null,
            XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.UpdatePartial(filename, records, updateOptions, xmlFormat, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Creates one or several records of a file, ina asynchronous way with XML input and output format.
        /// </summary>
        /// <param name="filename">The file name where the records are going to be created.</param>
        /// <param name="records">Buffer of records to write. Inside this string are the recordIds, and the records.</param>
        /// <param name="newOptions">Object with write options for the new record(s), including recordIdType, readAfter, calculated, dictionaries, conversion, formatSpec, originalRecords.</param>
        /// <param name="xmlFormat">Different XML output formats.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// Inside the records argument, the records always must be specified. But the recordIds only must be specified when <see cref="NewOptions"/> argument is null, or when the <see cref="RecordIdType"/> argument of the <see cref="NewOptions"/> constructor is null.
        /// </remarks>
        public Task<string> NewAsync(string filename, string records, NewOptions newOptions = null,
            XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.New(filename, records, newOptions, xmlFormat, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Deletes one or several records in file, ina asynchronous way with XML input and output format.
        /// </summary>
        /// <param name="filename">The file name where the records are going to be deleted. DICT in case of deleting a record that belongs to a dictionary.</param>
        /// <param name="records">Buffer of records to be deleted.</param>
        /// <param name="deleteOptions">Object with options to manage how records are deleted, including optimisticLockControl, recoverRecordIdType.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// Inside the records argument, the recordIds always must be specified. But the originalRecords not always.
        /// When <see cref="DeleteOptions">deleteOptions</see> argument is specified and the <see cref="DeleteOptions.OptimisticLockControl"/> property is set to true,
        /// a copy of the record must be provided before the deletion (originalRecords argument) to use the Optimistic Lock technique.
        /// This copy can be obtained from a previous <see cref="ReadAsync"/> operation. The database, before executing the deletion, 
        /// reads the record and compares it with the copy in originalRecords, if they are equal the record is deleted.
        /// But if they are not equal, it means that the record has been modified by other user and the record will not be deleted.
        /// The record will have to be read, and deleted again.
        /// </remarks>
        public Task<string> DeleteAsync(string filename, string records, DeleteOptions deleteOptions = null,
            string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.Delete(filename, records, deleteOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Executes a Query in the Database, ina asynchronous way with XML output format.
        /// </summary>
        /// <param name="filename">Name of file on which the operation is performed. For example LK.ORDERS</param>
        /// <param name="selectClause">Statement fragment specifies the selection condition. For example WITH CUSTOMER = '1'</param>
        /// <param name="sortClause">Statement fragment specifies the selection order. If there is a selection rule, Linkar will execute a SSELECT, otherwise Linkar will execute a SELECT. For example BY CUSTOMER</param>
        /// <param name="dictClause">Space-delimited list of dictionaries to read. If this list is not set, all fields are returned. For example CUSTOMER DATE ITEM. You may use the format LKFLDx where x is the attribute number.</param>
        /// <param name="preSelectClause">An optional command that executes before the main Select</param>
        /// <param name="selectOptions">Object with options to manage how records are selected, including calculated, dictionaries, conversion, formatSpec, originalRecords, onlyItemId, pagination, regPage, numPage.</param>
        /// <param name="xmlFormat">Different XML output formats.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// In the preSelectClause argument these operations can be carried out before executing the Select statement:
        ///  <list type="bullet">
        ///   <item>Previously call to a saved list with the GET.LIST command to use it in the Main Select input</item>
        ///   <item>Make a previous Select to use the result as the Main Select input, with the SELECT or SSELECT commands.In this case the entire sentence must be indicated in the PreselectClause. For example:SSELECT LK.ORDERS WITH CUSTOMER = '1'</item>
        ///   <item>Exploit a Main File index to use the result as a Main Select input, with the SELECTINDEX command. The syntax for all the databases is SELECTINDEX index.name.value. For example SELECTINDEX ITEM,"101691"</item>
        /// </list>
        /// </remarks>
        public Task<string> SelectAsync(string filename, string selectClause = "", string sortClause = "", string dictClause = "", string preSelectClause = "", SelectOptions selectOptions = null,
            XML_FORMAT xmlFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.Select(filename, selectClause, sortClause, dictClause, preSelectClause, selectOptions, xmlFormat, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Executes a subroutine, ina asynchronous way with XML input and output format.
        /// </summary>
        /// <param name="subroutineName">Name of BASIC subroutine to execute.</param>
        /// <param name="argsNumber">Number of arguments</param>
        /// <param name="arguments">The subroutine arguments list. Each argument is a substring separated with the ASCII char DC4 (20).</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public Task<string> SubroutineAsync(string subroutineName, int argsNumber, string arguments, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.Subroutine(subroutineName, argsNumber, arguments, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns the result of executing ICONV() or OCONV() functions from a expression list in the Database, ina asynchronous way with XML output format.
        /// </summary>
        /// <param name="conversionType">Indicates the conversion type, input or output: INPUT=ICONV(); OUTPUT=OCONV()</param>
        /// <param name="expression">The data or expression to convert. May include MV marks (value delimiters), in which case the conversion will execute in each value obeying the original MV mark.</param>
        /// <param name="code">The conversion code. Must obey the Database conversions specifications.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public Task<string> ConversionAsync(CONVERSION_TYPE conversionType, string expression, string code, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.Conversion(conversionType, expression, code, customVars, receiveTimeout); ;
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns the result of executing the FMT function in a expressions list in the Database, ina asynchronous way with XML output format.
        /// </summary>
        /// <param name="expression">The data or expression to format. If multiple values are present, the operation will be performed individually on all values in the expression.</param>
        /// <param name="formatSpec">Specified format</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public Task<string> FormatAsync(string expression, string formatSpec, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.Format(expression, formatSpec, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns all the dictionaries of a file, ina asynchronous way with XML output format.
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public Task<string> DictionariesAsync(string filename, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.Dictionaries(filename, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Allows the execution of any command from the Database ina asynchronous way with XML output format.
        /// </summary>
        /// <param name="statement">The command you want to execute in the Database.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public Task<string> ExecuteAsync(string statement, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.Execute(statement, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Allows getting the server version, ina asynchronous way with XML output format.
        /// </summary>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        /// <remarks>
        /// This function returns the following information
        /// <list type="definition">
        /// <item><term>LKMVCOMPONENTSVERSION</term><description>MV Components version.</description></item>
        /// <item><term>LKSERVERVERSION</term><description>Linkar SERVER version.</description></item>
        /// <item><term>LKCLIENTVERSION</term><description>Used client library version.</description></item>
        /// <item><term>DATABASE</term><description>Database.</description></item>
        /// <item><term>OS</term><description>Operating system.</description></item>
        /// <item><term>DATEZERO</term><description>Date zero base in YYYYMMDD format.</description></item>
        /// <item><term>DATEOUTPUTCONVERSION</term><description>Output conversion for date used by Linkar Schemas.</description></item>
        /// <item><term>TIMEOUTPUTCONVERSION</term><description>Output conversion for time used by Linkar Schemas.</description></item>
        /// <item><term>MVDATETIMESEPARATOR</term><description>DateTime used separator used by Linkar Schemas, for instance 18325,23000.</description></item>
        /// <item><term>MVBOOLTRUE</term><description>Database used char for the Boolean true value used by Linkar Schemas.</description></item>
        /// <item><term>MVBOOLFALSE</term><description>Database used char for the Boolean false value used by Linkar Schemas.</description></item>
        /// <item><term>OUTPUTBOOLTRUE</term><description>Used char for the Boolean true value out of the database used by Linkar Schemas.</description></item>
        /// <item><term>OUTPUTBOOLFALSE</term><description>Used char for the Boolean false value out of the database used by Linkar Schemas.</description></item>
        /// <item><term>MVDECIMALSEPARATOR</term><description>Decimal separator in the database. May be point, comma or none when the database does not store decimal numbers. Used by Linkar Schemas.</description></item>
        /// <item><term>OTHERLANGUAGES</term><description>Languages list separated by commas.</description></item>
        /// <item><term>TABLEROWSEPARATOR</term><description>It is the decimal char that you use to separate the rows in the output table format. By default 11.</description></item>
        /// <item><term>TABLECOLSEPARATOR</term><description>It is the decimal char that you use to separate the columns in the output table format. By default 9.</description></item>
        /// <item><term>CONVERTNUMBOOLJSON</term><description>Switch to create numeric and boolean data in JSON strings. Default is false.</description></item>
        /// </list>
        /// </remarks>
        /// <seealso href="http://kosday.com/Manuals/en_web_linkar/lk_schemas_ep_parameters.html">Schemas Parameter</seealso>
        public Task<string> GetVersionAsync(int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.GetVersion(receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns a list of all the Schemas defined in Linkar Schemas, or the EntryPoint account data files, ina asynchronous way with XML output format.
        /// </summary>
        /// <param name="lkSchemasOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public Task<string> LkSchemasAsync(LkSchemasOptions lkSchemasOptions = null, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.LkSchemas(lkSchemasOptions, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Returns the Schema properties list defined in Linkar Schemas or the file dictionaries, ina asynchronous way with XML output format.
        /// </summary>
        /// <param name="filename">File name to LkProperties</param>
        /// <param name="lkPropertiesOptions">This object defines the different options in base of the asked Schema Type: LKSCHEMAS, SQLMODE o DICTIONARIES.</param>
        /// <param name="outputFormat">Indicates in what format you want to receive the data resulting from the operation: XML, XML_DICT or XML_SCH.</param>
        /// <param name="customVars">Free text sent to the database allows management of additional behaviours in SUB.LK.MAIN.CONTROL.CUSTOM, which is called when this parameter is set.</param>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public Task<string> LkPropertiesAsync(string filename, LkPropertiesOptions lkPropertiesOptions = null, XML_FORMAT outputFormat = XML_FORMAT.XML, string customVars = "", int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.LkProperties(filename, lkPropertiesOptions, outputFormat, customVars, receiveTimeout);
            });

            task.Start();
            return task;
        }

        /// <summary>
        /// Resets the COMMON variables with the 100 most used files ina asynchronous way with XML output format.
        /// </summary>
        /// <param name="receiveTimeout">Maximum time in seconds that the client will wait for a response from the server. Default = 0 to wait indefinitely.</param>
        /// <returns>The results of the operation.</returns>
        public Task<string> ResetCommonBlocksAsync(int receiveTimeout = 0)
        {
            var task = new Task<string>(() =>
            {
                return this.ResetCommonBlocks(receiveTimeout);
            });

            task.Start();
            return task;
        }
    }
}

