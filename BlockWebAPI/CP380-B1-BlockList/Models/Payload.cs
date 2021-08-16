
namespace CP380_B1_BlockList.Models
{
    public enum TransactionTypes
    {
        BUY, SELL, GRANT
    }

    public class Payload
    {
        public Payload(string user, TransactionTypes transactionType, int amount, string item)
        {
            User = user;
            TransactionType = transactionType;
            Item = item;
            Amount = amount;
        }

        /// <summary>
        /// The account making the transaction
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// the kind of transaction being made
        /// </summary>
        public TransactionTypes TransactionType { get; set; }
        
        /// <summary>
        /// the number of items being transacted
        /// </summary>
        public int Amount { get; set; }
        
        /// <summary>
        /// the thing being transacted
        /// </summary>
        public string Item { get; set; }


    }
}
