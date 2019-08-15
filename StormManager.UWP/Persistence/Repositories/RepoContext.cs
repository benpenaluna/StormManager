using Autofac;
using StormManager.UWP.Models;
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
            var stateEntriesWritten = 0;

            while (RepoChanges.Changes.Count > 0)
            {
                // TODO: write the logic to persist the changes using stored procedures

                // if transaction successful
                stateEntriesWritten += 1;

                RepoChanges.Changes.Dequeue();
            } 

            return stateEntriesWritten;
        }
    }
}
