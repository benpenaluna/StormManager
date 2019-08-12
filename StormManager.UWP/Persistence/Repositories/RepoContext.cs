using Autofac;
using StormManager.UWP.Services.WebApiService;

namespace StormManager.UWP.Persistence.Repositories
{
    public class RepoContext
    {
        protected IWebApiService _webApiService;

        public RepoContext(string connectionString)
        {
            _webApiService = App.Container.Resolve<IWebApiService>(new NamedParameter("connectionString", connectionString));
        }
    }
}
