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

        public override bool Equals(object other)
        {
            var transaction = other as Transaction;

            return
                transaction != null && (
                this.Date.Date == transaction.Date.Date &&
                this.Account == null || this.Account.AccountIban.Equals(transaction.Account.AccountIban) &&
                this.Ammount.Equals(transaction.Ammount) &&
                this.Name.Equals(transaction.Name) &&
                this.ContraAccount.Equals(transaction.ContraAccount) &&
                this.Message.Equals(transaction.Message));
        }
    }
}
