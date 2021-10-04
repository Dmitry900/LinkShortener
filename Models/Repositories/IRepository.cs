using LinkShortener.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkShortener.Models
{
    public interface IRepository<T>  where T : class, IEntity
    {
        Task<bool> IsFind(string link);
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        public Task<T> Get(string link);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}