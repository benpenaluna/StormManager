using System;
using System.Threading.Tasks;
using Autofac;
using StormManager.UWP.Core;
using StormManager.UWP.Core.Repositories;
using StormManager.UWP.Persistence.Repositories;

namespace StormManager.UWP.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IJobTypeRepository JobTypes { get; private set; }

        private StormManagerContext _context;

        private UnitOfWork()
        {
        }

        public static Task<UnitOfWork> CreateAsync()
        {
            var result = new UnitOfWork();
            return result.InitialiseAsync();
        }

        private async Task<UnitOfWork> InitialiseAsync()
        {
            _context = await StormManagerContext.CreateAsync();

            //JobTypes = new JobTypeRepository(_context);
            JobTypes = App.Container.Resolve<IJobTypeRepository>(new TypedParameter(typeof(StormManagerContext), _context));
            return this;
        }

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
