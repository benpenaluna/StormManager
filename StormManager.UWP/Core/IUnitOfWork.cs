using System;
using StormManager.UWP.Core.Repositories;

namespace StormManager.UWP.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IJobTypeRepository JobTypes { get; }

        int Complete();
    }
}
