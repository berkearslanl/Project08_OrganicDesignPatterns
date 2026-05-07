namespace _08_Organic_DesignPatternsProject.Observer
{
    //sipariş verildikten sonra bilgilendirme mesajı
    public interface IOrderObserver
    {
        Task OnOrderCreatedAsync(string email, int orderId, decimal totalAmount);
    }
}
