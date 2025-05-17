namespace Gatocan.Business;
using Microsoft.Extensions.Options;
using Stripe;
using Gatocan.Model;

public class PaymentService
{
  public PaymentService(IOptions<StripeSettings> opts)
  {
    StripeConfiguration.ApiKey = opts.Value.SecretKey;
  }

  public PaymentIntent CreatePaymentIntent(long amountInCents)
  {
    var options = new PaymentIntentCreateOptions {
      Amount = amountInCents,
      Currency = "eur"
    };
    return new PaymentIntentService().Create(options);
  }
}