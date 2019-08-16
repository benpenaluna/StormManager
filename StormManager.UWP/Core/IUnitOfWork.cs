using System;
using System.Threading.Tasks;
using StormManager.UWP.Core.Repositories;

namespace StormManager.UWP.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IJobTypeRepository JobTypes { get; }

        Task<int> CompleteAsync();
    }
}
