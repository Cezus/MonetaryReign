using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using MonetaryReign.Data.Database;
using MonetaryReign.Model.Entities;
using MonetaryReign.Web.Api.Logic;
using MonetaryReign.Web.Api.Models;

namespace MonetaryReign.Web.Api.Controllers
{
    public class TransactionsController : ApiController
    {
        public MonetaryReignContext context { get; set; }

        public TransactionsController()
        {
            this.context = new MonetaryReignContext();
        }

        public async Task<IHttpActionResult> Post()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            // stream to string
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            var file = await provider.Contents.First().ReadAsStreamAsync();
            var streamReader = new StreamReader(file);
            var csv = streamReader.ReadToEnd();

            var converter = new Converter();
            // string to IngRecords
            var records = converter.ConvertCsvToIngRecords(csv);
            var accountIban = records.First().Account;
            // IngRecords to Transactions
            var account = this.context.Accounts.FirstOrDefault(a => a.AccountIban.Equals(accountIban));
            if (account == null)
            {
                return NotFound();
            }

            var uploadedTransactions = converter.ConvertToTransactions(account, records);
            List<Transaction> newTransactions = this.GetNewTransactions(account, uploadedTransactions);

            if (newTransactions.Any())
            {
                context.Transactions.AddRange(newTransactions);
                await context.SaveChangesAsync();
            }

            return Ok(newTransactions);
        }

        private List<Transaction> GetNewTransactions(Model.Entities.Account account, List<Transaction> newTransactions)
        {
            var transactionsToSave = new List<Transaction>();

            var first = newTransactions.Min(t => t.Date);
            var latest = newTransactions.Max(t => t.Date);
            var existingTransactions = context.Transactions.Where(t => t.Account.AccountIban.Equals(account.AccountIban) && t.Date >= first && t.Date <= latest).ToList();

            foreach (var transaction in newTransactions)
            {
                if (!existingTransactions.Contains(transaction))
                {
                    transactionsToSave.Add(transaction);
                }
            }

            return transactionsToSave;
        }
    }
}
