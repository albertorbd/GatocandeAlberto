using Gatocan.Model;
using Microsoft.EntityFrameworkCore;

namespace Gatocan.Data;

    public class TransactionEFRepository : ITransactionRepository
    {
        private readonly GatocanContext _context;

        public TransactionEFRepository(GatocanContext context)
        {
            _context = context;
        }

        public IEnumerable<Transaction> GetTransactionsByUserId(int userId)
        {
            return _context.Transactions
                           .Include(t => t.Product)
                           .Where(t => t.UserId == userId)
                           .OrderByDescending(t => t.Date)
                           .ToList();
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
        }

       

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
