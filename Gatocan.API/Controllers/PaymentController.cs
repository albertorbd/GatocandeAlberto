using Gatocan.Business;
using Gatocan.Model;
using Microsoft.AspNetCore.Mvc;


namespace Gatocan.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly PaymentService _svc;
    public PaymentsController(PaymentService svc) => _svc = svc;

    [HttpPost("create-intent")]
    public IActionResult CreateIntent([FromBody] CreateIntentDto dto)
    {
        var cents = (long)(dto.Amount * 100);
        var pi = _svc.CreatePaymentIntent(cents);
        return Ok(new { clientSecret = pi.ClientSecret });
    }

}