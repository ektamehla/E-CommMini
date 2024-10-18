namespace Ecomm.Server.Models
{
    public abstract class Payment
    {
        public int Id { get; set; }
        public decimal PricePayment { get; set; }

        public string Type { get; set; }

        public Payment(int  id, decimal pricePayment, string type)
        {
            Id = id;
            PricePayment = pricePayment;
            Type = type;
        }

        public abstract void paymentMethod();
    }

    public class PayPalPayment: Payment
    {
        public string PaypalEmail { get; private set; }
        public PayPalPayment(int id, decimal pricePayment, string type, string paypalEmail): base(id, pricePayment, type)
        {
            PaypalEmail = paypalEmail;
        }

        public override void paymentMethod()
        {
            Console.WriteLine("Paypal payment!");
        }
    }

    public class CreditCardPayment : Payment
    {
        public string CreditCardNumber { get; private set; }
        public CreditCardPayment(int id, decimal pricePayment, string type, string creditCardNumber) : base(id, pricePayment, type)
        {
            CreditCardNumber = creditCardNumber;
        }

        public override void paymentMethod()
        {
            Console.WriteLine("Paypal payment!");
        }
    }
}
