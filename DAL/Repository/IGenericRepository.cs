using System.Collections.Generic;

namespace DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> SelectAll();
        //IEnumerable<Event> SelectAllActiveEvents();

        T SelectByID(object id);

        void Insert(T obj);

        bool Update(int id, T obj);

        void Delete(object id);

        void Save();

        bool Exists(object id);
    }
}
