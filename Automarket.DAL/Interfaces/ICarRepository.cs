using Automarket.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.DAL.Interfaces
{
    public interface IBaseRepository: IBaseRepository<Car>
    {
        Task<Car> GetByName(string name);
    }
}
