using System;
using System.Collections.Generic;
using NHibernate;
using BostadStockholm.Data.Interfaces;

namespace BostadStockholm.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;
        
        public Repository(ISession session)
        {
            _session = session;
        }

        public T GetById(Guid id)
        {
            return _session.Get<T>(id);
        }

        public IList<T> GetAll()
        {
            return _session.QueryOver<T>().List();
        }

        public void Save(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(entity);
                transaction.Commit();
            }
        }

        public void Update(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(entity);
                transaction.Commit();
            }
        }

        public void Delete(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(entity);
                transaction.Commit();
            }
        }
    }
}