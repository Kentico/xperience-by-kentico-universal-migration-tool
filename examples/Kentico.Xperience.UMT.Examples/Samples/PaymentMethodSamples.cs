using Kentico.Xperience.UMT.Model;

namespace Kentico.Xperience.UMT.Examples;

public static class PaymentMethodSamples
{
    public static readonly Guid SAMPLE_PAYMENT_METHOD_CREDIT_CARD_GUID = new("A7B8C9D0-E1F2-4345-A678-9ABCDEF01234");
    public static readonly Guid SAMPLE_PAYMENT_METHOD_PAYPAL_GUID = new("B8C9D0E1-F2A3-4456-B789-ABCDEF012345");

    [Sample("paymentmethod.sample.creditcard", "Sample demonstrates how to create a credit card payment method", "Instance of dataclass PaymentMethodInfo - Sample credit card payment method")]
    public static PaymentMethodModel SamplePaymentMethodCreditCard => new()
    {
        PaymentMethodGUID = SAMPLE_PAYMENT_METHOD_CREDIT_CARD_GUID,
        PaymentMethodName = "CreditCard",
        PaymentMethodDisplayName = "Credit Card",
        PaymentMethodDescription = "Pay with credit or debit card",
        PaymentMethodEnabled = true
    };


    [Sample("paymentmethod.sample.paypal", "Sample demonstrates how to create a PayPal payment method", "Instance of dataclass PaymentMethodInfo - Sample PayPal payment method")]
    public static PaymentMethodModel SamplePaymentMethodPayPal => new()
    {
        PaymentMethodGUID = SAMPLE_PAYMENT_METHOD_PAYPAL_GUID,
        PaymentMethodName = "PayPal",
        PaymentMethodDisplayName = "PayPal",
        PaymentMethodDescription = "Pay with PayPal account",
        PaymentMethodEnabled = true
    };
}

