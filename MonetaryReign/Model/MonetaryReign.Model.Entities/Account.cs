using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonetaryReign.Model.Entities
{
    public class Account
    {
        public int AccountID { get; set; }

        public string Name { get; set; }

        public string AccountIban { get; set; }

        public string Bank { get; set; }
    }
}
