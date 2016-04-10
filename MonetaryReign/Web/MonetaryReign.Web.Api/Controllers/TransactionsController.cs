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
using MonetaryReign.Web.Api.Logic;

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

            var transactions = converter.ConvertToTransactions(account, records);

            context.Transactions.AddRange(transactions);
            await context.SaveChangesAsync();

            return Ok(transactions);
        }
    }
}
