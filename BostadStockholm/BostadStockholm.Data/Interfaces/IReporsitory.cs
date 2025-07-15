using System;
using System.Collections.Generic;

namespace BostadStockholm.Data.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(Guid Id);
        IList<T> GetAll();
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}