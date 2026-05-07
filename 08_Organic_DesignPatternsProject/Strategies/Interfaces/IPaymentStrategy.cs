namespace _08_Organic_DesignPatternsProject.Strategies.Interfaces
{
    public interface IPaymentStrategy
    {
        string PaymentMethodName { get; }
        Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request);
    }
}
