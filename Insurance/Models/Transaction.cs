namespace Insurance.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        private double _amount;
        public void setAmount(double amount)
        {
            _amount = amount;
        }
        public double getAmount()
        {
            return this._amount;
        }
    }
}
