using System;

namespace MonetaryReign.Model.Entities
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        public DateTime Date { get; set; }

        public Account Account { get; set; }

        public string Name { get; set; }

        public string ContraAccount { get; set; }

        public string TransactionSort { get; set; }

        public bool Positive { get; set; }

        public decimal Ammount { get; set; }

        public string Message { get; set; }
    }
}
