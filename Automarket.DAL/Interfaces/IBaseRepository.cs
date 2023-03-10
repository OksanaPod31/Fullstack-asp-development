using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
        Task<T> Get(int id);
        IQueryable<T> GetAll();

        //Task<List<T>> Select(); 
        Task Delete(T entity);
        Task<T> Update (T entity);
    }
}
