using RestWithASPNETUdemy.Models.Base;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindbyId(long id);
        IList<T> FindAll();
        IList<T> FindWithPagedSearch(string query);
        int GetCount(string query);
        T Update(T item);
        void Delete(long id);
        bool Exists(long? id);
    }
}
