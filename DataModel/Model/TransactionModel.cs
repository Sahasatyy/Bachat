namespace DataModel.Model
{
    public class TransactionModel
    {
        public Guid TransactionId { get; set; }

        public TransactionType TransactionType { get; set; }

        public string TransactionAmount { get; set; }

        public string TransactionNotes { get; set; }

        public TransactionTag TransactionTag { get; set; }

        public DateTime TransactionDate { get; set; }

        
    }
}
