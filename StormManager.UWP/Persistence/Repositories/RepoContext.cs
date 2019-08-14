using Autofac;
using StormManager.UWP.Services.WebApiService;

namespace StormManager.UWP.Persistence.Repositories
{
    public class RepoContext
    {
        protected IWebApiService WebApiService;

        public RepoContext()
        {
            
        }

        public RepoContext(string connectionString)
        {
            InitialiseWebApiService(connectionString);
        }

        protected IWebApiService InitialiseWebApiService(string connectionString)
        {
            return WebApiService = App.Container.Resolve<IWebApiService>(new NamedParameter("connectionString", connectionString));
        }

        public virtual int SaveChanges()
        {
            return 0;
        }
    }
}
