using Microsoft.AspNetCore.Mvc;
using Gatocan.Business;
using Gatocan.Model;
using Microsoft.AspNetCore.Authorization;


namespace Gatocan.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionsController> _logger;
         private readonly IAuthService _authService;

        public TransactionsController(ITransactionService transactionService,
        ILogger<TransactionsController> logger, IAuthService authService)
        {
            _transactionService = transactionService;
            _logger = logger;
            _authService= authService;
            
        }

         [Authorize(Roles = Roles.Admin + "," + Roles.User)] 
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<Transaction>> GetAllForUser(int userId)
        {
             if (!_authService.HasAccessToResource(Convert.ToInt32(userId), HttpContext.User)) 
            {return Forbid(); }

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
        [Authorize(Roles = Roles.Admin + "," + Roles.User)] 
        [HttpGet("{userId}/purchased")]
        public ActionResult<IEnumerable<Product>> GetProductsPurchased(int userId)
        {

             if (!_authService.HasAccessToResource(Convert.ToInt32(userId), HttpContext.User)) 
            {return Forbid(); }

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
        [Authorize(Roles = Roles.Admin + "," + Roles.User)]
        [HttpPost("{userId}/deposit")]
        public IActionResult Deposit(int userId, [FromBody] DepositDto dto)
        {
            if (userId != dto.UserId)
                return BadRequest("UserId mismatch between route and body.");
            if (!_authService.HasAccessToResource(Convert.ToInt32(dto.UserId), HttpContext.User)) 
            {return Forbid(); }

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
         [Authorize(Roles = Roles.Admin + "," + Roles.User)]
        [HttpPost("{userId}/purchase")]
        public IActionResult Purchase(int userId, [FromBody] PurchaseDto dto)
        {
    
            if (userId != dto.UserId)
                return BadRequest("UserId mismatch between route and body.");

             if (!_authService.HasAccessToResource(Convert.ToInt32(dto.UserId), HttpContext.User)) 
            {return Forbid(); }


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