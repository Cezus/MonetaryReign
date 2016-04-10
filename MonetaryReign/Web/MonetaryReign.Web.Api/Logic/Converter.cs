using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using MonetaryReign.Model.Entities;
using MonetaryReign.Web.Api.Models;

namespace MonetaryReign.Web.Api.Logic
{
    public class Converter
    {
        public List<IngRecord> ConvertCsvToIngRecords(string csv)
        {
            var reader = new CsvReader(new StringReader(csv));
            reader.Configuration.RegisterClassMap<IngRecordMap>();
            var records = new List<IngRecord>();

            while (reader.Read())
            {
                var record = reader.GetRecord<IngRecord>();
                records.Add(record);
            }

            return records;
        }

        public List<Transaction> ConvertToTransactions(Model.Entities.Account account, List<IngRecord> records)
        {
            var transactions = new List<Transaction>();
            foreach (var record in records)
            {
                var transaction = new Transaction();

                transaction.Date = DateTime.ParseExact(record.Date, "yyyyMMdd", CultureInfo.InvariantCulture);
                transaction.Name = record.NameDescription;
                transaction.Account = account;
                transaction.ContraAccount = record.ContraAccount;
                transaction.Positive = record.AfBij.Equals("Bij", StringComparison.InvariantCultureIgnoreCase);
                transaction.Ammount = decimal.Parse(record.Ammount, NumberStyles.Any, CultureInfo.InvariantCulture);
                transaction.TransactionSort = record.MutationSort;
                transaction.Message = record.Message;

                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}