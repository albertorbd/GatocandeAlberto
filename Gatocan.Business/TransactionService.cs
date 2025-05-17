using Gatocan.Data;
using Gatocan.Model;


namespace Gatocan.Business;

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repo;
        private readonly IUserRepository _userRepo;
        private readonly IProductRepository _productRepo;

        public TransactionService(
            ITransactionRepository repo,
            IUserRepository userRepo,
            IProductRepository productRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
            _productRepo = productRepo;
        }

public void MakeDeposit(DepositDto depositDTO)
{
    var user = _userRepo.GetUserById(depositDTO.UserId);
    if (user == null) throw new KeyNotFoundException("User not found");

    user.Balance += depositDTO.Amount;
    _userRepo.UpdateUser(user);

    var transaction = new Transaction
    {
        UserId = depositDTO.UserId,
        ProductId = null,        
        Amount = depositDTO.Amount,
        Quantity = 0,
        Date = DateTime.Now,
        PaymentMethod = depositDTO.PaymentMethod,
        Tipo = TransactionType.Ingreso
    };
    _repo.AddTransaction(transaction);
    _repo.SaveChanges();
}
public void MakePurchase(PurchaseDto purchaseDTO)
{
    var user = _userRepo.GetUserById(purchaseDTO.UserId)
               ?? throw new KeyNotFoundException($"User {purchaseDTO.UserId} not found.");
    var prod = _productRepo.GetProductById(purchaseDTO.ProductId)
               ?? throw new KeyNotFoundException($"Product {purchaseDTO.ProductId} not found.");

    var totalCost = prod.Price * purchaseDTO.Quantity;

    
    if (purchaseDTO.PaymentMethod.Equals("Balance", StringComparison.OrdinalIgnoreCase))
    {
        if (user.Balance < totalCost)
            throw new InvalidOperationException("Insufficient balance.");
        user.Balance -= totalCost;
        _userRepo.UpdateUser(user);
        _userRepo.SaveChanges();
    }

    var transaction = new Transaction(
        userId:        purchaseDTO.UserId,
        productId:     purchaseDTO.ProductId,
        amount:        totalCost,
        quantity:      purchaseDTO.Quantity,
        paymentMethod: purchaseDTO.PaymentMethod,
        tipo:          TransactionType.Compra
    );
    _repo.AddTransaction(transaction);
    _repo.SaveChanges();
}


    public IEnumerable<Transaction> GetTransactionsByUser(int userId)
        {
            return _repo.GetTransactionsByUserId(userId);
        }

 public IEnumerable<Product> GetPurchasedProducts(int userId)
{
    var purchases = _repo
        .GetTransactionsByUserId(userId)
        .Where(t => t.Tipo == TransactionType.Compra)
        .Where(t => t.ProductId.HasValue);

    return purchases
        .Select(t => _productRepo.GetProductById(t.ProductId.Value))
        .Where(p => p != null)
        .ToList();
}
    }
