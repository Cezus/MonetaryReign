using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonetaryReign.Web.Api.Models
{
    public class IngRecord
    {
        public string Date { get; set; }

        public string NameDescription { get; set; }

        public string Account { get; set; }

        public string ContraAccount { get; set; }

        public string Code { get; set; }

        public string AfBij { get; set; }

        public string Ammount { get; set; }

        public string MutationSort { get; set; }

        public string Message { get; set; }
    }
}
