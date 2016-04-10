using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using MonetaryReign.Web.Api.Models;

namespace MonetaryReign.Web.Api.Logic
{
    public class IngRecordMap : CsvClassMap<IngRecord>
    {
        public IngRecordMap()
        {
            Map(t => t.Date).Name("Datum");
            Map(t => t.NameDescription).Name("Naam / Omschrijving");
            Map(t => t.Account).Name("Rekening");
            Map(t => t.ContraAccount).Name("Tegenrekening");
            Map(t => t.Code).Name("Code");
            Map(t => t.AfBij).Name("Af Bij");
            Map(t => t.Ammount).Name("Bedrag (EUR)");
            Map(t => t.MutationSort).Name("MutatieSoort");
            Map(t => t.Message).Name("Mededelingen");
        }
    }
}
