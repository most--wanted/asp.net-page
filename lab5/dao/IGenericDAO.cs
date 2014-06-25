using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4.dao
{
    public interface IGenericDAO<T>
    {
        void SaveOrUpdate(T item);
        T GetById(long id);
        List<T> GetAll();
        void Delete(T item);
    }
}
