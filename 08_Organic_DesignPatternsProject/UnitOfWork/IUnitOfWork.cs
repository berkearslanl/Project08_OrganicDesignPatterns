namespace _08_Organic_DesignPatternsProject.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        Task<int> CommitAsync();//tüm repository'lerin yaptığı değişiklikleri tek bir savechanges ile çağırır
    }
}
