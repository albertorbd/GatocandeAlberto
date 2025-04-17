using Gatocan.Model;


namespace Gatocan.Business
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetTransactionsByUser(int userId);
        void MakeDeposit(DepositDto depositDto);
       void MakePurchase(PurchaseDto purchaseDTO);
        IEnumerable<Product> GetPurchasedProducts(int userId);

    }
}