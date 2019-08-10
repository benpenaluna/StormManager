using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using StormManager.UWP.Core.Repositories;
using StormManager.UWP.Services.WebApiService;

namespace StormManager.UWP.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IWebApiService WebApiService;

        public Repository()
        {
            WebApiService = new WebApiService();
        }

        public TEntity Get(int id)
        {
            //return WebApiService.Set<TEntity>().Find(id);
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            //return WebApiService.Set<TEntity>().ToList();
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            //return WebApiService.Set<TEntity>().Where(predicate);
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            //return WebApiService.Set<TEntity>().SingleOrDefault(predicate);
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            //WebApiService.Set<TEntity>().Add(entity);
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            //WebApiService.Set<TEntity>().AddRange(entities);
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            //WebApiService.Set<TEntity>().Remove(entity);
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            //WebApiService.Set<TEntity>().RemoveRange(entities);
            throw new NotImplementedException();
        }
    }
}
