using Microsoft.AspNetCore.Mvc;
using Gatocan.Business;
using Gatocan.Model;

namespace Gatocan.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ITransactionService transactionService,
        ILogger<TransactionsController> logger)
        {
            _transactionService = transactionService;
            _logger = logger;
        }

        // GET api/transactions/{userId}
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<Transaction>> GetAllForUser(int userId)
        {
            try
            {
                var ops = _transactionService.GetTransactionsByUser(userId);
                return Ok(ops);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving transactions for user {userId}");
                return StatusCode(500, $"An error occurred retrieving transactions for user {userId}.");
            }
        }

        // GET api/transactions/{userId}/purchased
        [HttpGet("{userId}/purchased")]
        public ActionResult<IEnumerable<Product>> GetProductsPurchased(int userId)
        {
            try
            {
                var products = _transactionService.GetPurchasedProducts(userId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving purchased products for user {userId}");
                return StatusCode(500, $"An error occurred retrieving purchased products for user {userId}.");
            }
        }

        // POST api/transactions/{userId}/deposit
        [HttpPost("{userId}/deposit")]
        public IActionResult Deposit(int userId, [FromBody] DepositDto dto)
        {
            if (userId != dto.UserId)
                return BadRequest("UserId mismatch between route and body.");

            try
            {
                _transactionService.MakeDeposit(dto);
                return NoContent();
            }
            catch (KeyNotFoundException knf)
            {
                return NotFound(knf.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error depositing for user {userId}");
                return StatusCode(500, "An error occurred during deposit.");
            }
        }

        // POST api/transactions/{userId}/purchase
        [HttpPost("{userId}/purchase")]
        public IActionResult Purchase(int userId, [FromBody] PurchaseDto dto)
        {
            if (userId != dto.UserId)
                return BadRequest("UserId mismatch between route and body.");

            try
            {
                _transactionService.MakePurchase(dto);
                return NoContent();
            }
            catch (KeyNotFoundException knf)
            {
                return NotFound(knf.Message);
            }
            catch (InvalidOperationException ioex)
            {
                return BadRequest(ioex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error processing purchase for user {userId}");
                return StatusCode(500, "An error occurred during purchase.");
            }
        }
    }
}