using ProjetoBackEndInfnet.Models;

namespace ProjetoBackEndInfnet.Services;

public class PaymentService
{
    public bool ProcessPayment(Order order, decimal amount, string paymentMethod)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order), "Order cannot be null.");

        if (order.Status == Order.STATUS_COMPLETED)
            throw new InvalidOperationException("This order has already been paid.");

        if (amount <= 0)
            throw new ArgumentException("Payment amount must be greater than zero.", nameof(amount));

        if (amount < order.GetTotalAmount())
            throw new InvalidOperationException("Payment amount is less than order total.");

        // Criando o pagamento
        var payment = new Payment
        {
            OrderId = order.Id,
            TotalAmount = amount,
            PaymentMethod = paymentMethod,
            PaymentDate = DateTime.Now
        };

        order.Status = Order.STATUS_COMPLETED;

        // TODO: Salvar o pagamento no banco de dados
        // Aqui você poderia integrar com gateways externos (Pix, cartão, etc.)
        Console.WriteLine($"Payment of {amount:C} for Order {order.Id} processed via {paymentMethod}.");

        return true;
    }

    public bool ValidatePayment(Payment payment)
    {
        if (payment == null)
            throw new ArgumentNullException(nameof(payment), "Payment cannot be null.");

        if (payment.TotalAmount <= 0)
            return false;

        if (payment.PaymentDate == default)
            return false;

        if (string.IsNullOrWhiteSpace(payment.PaymentMethod))
            return false;

        return true;
    }
}