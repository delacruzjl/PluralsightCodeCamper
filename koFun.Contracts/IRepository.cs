using System.Linq;

namespace koFun.Contracts
{
    public interface IRepository<T> where T : class 
    {
        IQueryable<T> GetAll();
        T FindOne(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}