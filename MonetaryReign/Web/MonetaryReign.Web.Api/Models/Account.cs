using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonetaryReign.Web.Api.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AccountIban { get; set; }

        public string Bank { get; set; }
    }
}