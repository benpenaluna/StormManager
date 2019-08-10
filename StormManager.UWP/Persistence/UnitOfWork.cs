using StormManager.UWP.Core;
using StormManager.UWP.Core.Repositories;
using StormManager.UWP.Persistence.Repositories;

namespace StormManager.UWP.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StormManagerContext _context;

        public IJobTypeRepository JobTypes { get; }

        public UnitOfWork(StormManagerContext context)
        {
            _context = context;
            //JobTypes = new JobTypeRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
