
namespace CP380_B1_BlockList.Models
{
    public enum TransactionTypes
    {
        BUY, SELL, GRANT
    }

    public class Payload
    {
        public string userName { get; set; }
        public TransactionTypes transactionType { get; set; }
        public int amount { get; set; }
        public string item { get; set; }

        public Payload(string v)
        {

        }

        public Payload(string userName, TransactionTypes transactionType, int amount, string item)
        {
            this.userName = userName;
            this.transactionType = transactionType;
            this.amount = amount;
            this.item = item;
        }
    }
}
