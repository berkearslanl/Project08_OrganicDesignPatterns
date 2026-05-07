namespace _08_Organic_DesignPatternsProject.Observer
{
    //abone olunduktan sonra hoşgeldin mesajı
    public interface ISubscriberObserver
    {
        Task OnSubscribedAsync(string email);
    }
}
