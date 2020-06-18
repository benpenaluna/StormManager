using StormManager.UWP.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace StormManager.UWP.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IJobTypeRepository JobTypes { get; }

        Task<int> CompleteAsync();
    }
}
