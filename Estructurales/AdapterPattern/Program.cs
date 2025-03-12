using System;
using System.Text;

namespace AdapterPractice{
    public class PayPalService{
        public void SendPayment(float amount){
            Console.WriteLine($"Sending payment of {amount} to Paypal...");
        }
    }

    public class StripeService{
        public void MakeCharge(float amount){
            Console.WriteLine($"Sending payment of {amount} to Stripe...");
        }
    }

    public class MercadoPagoService{
        public void Pay(float amount){
            Console.WriteLine($"Sending payment of {amount} to MercadoPago...");
        }
    }

    public abstract class PaymentProcessor{
        public abstract void ProcessPayment(float amount);
    }

    public class PayPalAdapter : PaymentProcessor{
        private PayPalService paypalService;

        public PayPalAdapter(PayPalService _paypalService){
            paypalService = _paypalService;
        }

        public override void ProcessPayment(float amount){
            paypalService.SendPayment(amount);
        }
    }

    public class StripeAdapter : PaymentProcessor{
        private StripeService stripeService;

        public StripeAdapter(StripeService _stripeService){
            stripeService = _stripeService;
        }

        public override void ProcessPayment(float amount){
            stripeService.MakeCharge(amount);
        }
    }

    public class MercadoPagoAdapter : PaymentProcessor{
        private MercadoPagoService mercadoPagoService;

        public MercadoPagoAdapter(MercadoPagoService _mercadoPagoService){
            mercadoPagoService = _mercadoPagoService;
        }

        public override void ProcessPayment(float amount){
            mercadoPagoService.Pay(amount);
        }
    }

    class Program{
        static void Main(string[] args){
            float paymentAmount = 100;

            PayPalAdapter paypalProcessor = new PayPalAdapter(new PayPalService());

            Console.WriteLine("Using Paypal...");
            paypalProcessor.ProcessPayment(paymentAmount);

            StripeAdapter stripeProcessor = new StripeAdapter(new StripeService());

            Console.WriteLine("Using Stripe...");
            stripeProcessor.ProcessPayment(paymentAmount);

            MercadoPagoAdapter mercadoPagoProcessor = new MercadoPagoAdapter(new MercadoPagoService());

            Console.WriteLine("Using Paypal...");
            mercadoPagoProcessor.ProcessPayment(paymentAmount);
        }
    }
}
