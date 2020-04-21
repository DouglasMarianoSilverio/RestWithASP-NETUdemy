using RestWithASPNETUdemy.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindbyId(long id);
        IList<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long? id);
    }
}
