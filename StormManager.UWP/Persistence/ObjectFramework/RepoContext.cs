using System;
using System.Threading.Tasks;
using Autofac;
using StormManager.UWP.Persistence.Repositories;
using StormManager.UWP.Services.WebApiService;

namespace StormManager.UWP.Persistence.ObjectFramework
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

        public virtual async Task<int> SaveChangesAsync()
        {
            // TODO: Think about how to persist changes if network connection is unavailable

            var stateEntriesWritten = 0;

            while (RepoChanges.Changes.Count > 0)
            {
                // TODO: write the logic to persist the changes using stored procedures
                var nextChange = RepoChanges.Changes.Peek();

                // TODO: Move determination of storedProcedureName to it's own class with a helper. If this changes in the future, it will make changing the code easier
                var storedProcedureName = nextChange.DataManipulation + "_" + nextChange.Item.GetType().Name + "s"; // TODO: Remove the "s", as this will not work for all plurals
                try
                {
                    await WebApiService.PutAsync(storedProcedureName, nextChange.Item);
                    stateEntriesWritten += 1;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);  // TODO: work out what to do it the transaction doesn't work
                    throw;
                }
                

                RepoChanges.Changes.Dequeue();
            } 

            return stateEntriesWritten;
        }
    }
}
