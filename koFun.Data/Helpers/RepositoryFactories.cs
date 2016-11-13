using System;
using System.Collections.Generic;
using System.Data.Entity;
using koFun.Contracts;

namespace koFun.Data.Helpers
{
    public class RepositoryFactories
    {
        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }

        public RepositoryFactories()
        {
            _repositoryFactories = GetCodeCamperFactories();
        }

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {

            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new EFRepository<T>(dbContext);
        }

        private IDictionary<Type, Func<DbContext, object>> GetCodeCamperFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
                {
                   {typeof(IAttendanceRepository), dbContext => new AttendanceRepository(dbContext)},
                   {typeof(IPersonRepository), dbContext => new PersonRepository(dbContext)},
                   {typeof(ISessionRepository), dbContext => new SessionRepository(dbContext)},
                };
        }
    }
}