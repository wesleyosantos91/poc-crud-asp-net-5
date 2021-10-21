using System.Collections.Generic;
using app.Models.Base;

namespace app.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        List<T> FindAll();
        T FindById(long id);
        T Update(long id, T item);
        void Delete(long id);
        bool Exists(long id);
    }
}
