using Autofac;
using StormManager.UWP.Core;
using StormManager.UWP.Core.Repositories;
using StormManager.UWP.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace StormManager.UWP.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IJobTypeRepository JobTypes { get; private set; }

        private StormManagerContext _context;

        private UnitOfWork() { }

        public static Task<UnitOfWork> CreateAsync()
        {
            var result = new UnitOfWork();
            return result.InitialiseAsync();
        }

        private async Task<UnitOfWork> InitialiseAsync()
        {
            _context = await StormManagerContext.CreateAsync();

            JobTypes = App.Container.Resolve<IJobTypeRepository>(new TypedParameter(typeof(StormManagerContext), _context));
            return this;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
