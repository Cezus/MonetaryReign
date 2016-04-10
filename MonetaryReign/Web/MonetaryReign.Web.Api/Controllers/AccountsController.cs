using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MonetaryReign.Data.Database;

namespace MonetaryReign.Web.Api.Controllers
{
    public class AccountsController : ApiController
    {
        public MonetaryReignContext context { get; set; }

        public AccountsController()
        {
            this.context = new MonetaryReignContext();
        }

        [ResponseType(typeof(Models.Account))]
        public async Task<IHttpActionResult> GetAccount(int id)
        {
            Model.Entities.Account account = await context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            var model = new Models.Account()
            {
                Id = account.AccountID,
                Name = account.Name,
                AccountIban = account.AccountIban,
                Bank = account.Bank
            };

            return Ok(model);
        }

        [ResponseType(typeof(Models.Account))]
        public async Task<IHttpActionResult> PostAccount(Models.Account model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = new Model.Entities.Account()
            {
                Name = model.Name,
                AccountIban = model.AccountIban,
                Bank = model.Bank
            };

            this.context.Accounts.Add(account);
            await this.context.SaveChangesAsync();

            model.Id = account.AccountID;

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }
    }
}
