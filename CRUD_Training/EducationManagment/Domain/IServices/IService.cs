using System.Collections.Generic;

namespace Domain.IServices
{
    public interface IService<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
