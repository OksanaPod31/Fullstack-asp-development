using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Service.Interfaces
{
    public interface ICarService
    {
        Task<IBaseResponse<List<Car>>> GetCars();
        Task<IBaseResponse<Car>> GetCar(int id);
        Task<IBaseResponse<Car>> GetCarByName(string name);
        Task<IBaseResponse<Car>> CreateCar(CarViewModel carViewModel, byte[] imageData);
        Task<IBaseResponse<bool>> DeleteCar(int id);
        Task<IBaseResponse<Car>> Edit(int id, CarViewModel model);


    }
}
