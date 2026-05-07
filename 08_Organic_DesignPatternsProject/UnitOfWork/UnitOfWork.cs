
using _08_Organic_DesignPatternsProject.Context;

namespace _08_Organic_DesignPatternsProject.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrganicContext _context;

        public UnitOfWork(OrganicContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()//nesne kullanımı bittiğinde geride kalan kaynakları temizler.
        {
            _context.Dispose();
        }
    }
}
