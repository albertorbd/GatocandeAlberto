using Gatocan.Model;


namespace Gatocan.Data;

    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactionsByUserId(int userId);
        void AddTransaction(Transaction transaction);
        void SaveChanges();
    }