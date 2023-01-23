using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.ViewModels.Car;
using Automarket.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Automarket.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: CarController
        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var response = await _carService.GetCars();
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetCar(int id)
        {
            var response = await _carService.GetCar(id);
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error"); //Перенаправление на представление с ошибкой
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _carService.DeleteCar(id);
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetCars");
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id)
        {
            if(id == 0)
            {
                return View();
            }
            var response = await _carService.GetCar(id);
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Save(string name, string description, string model, double speed, decimal price, TypeCar typeCar, IFormFile avatar)
        {
            CarViewModel Model = new CarViewModel()
            {
                Name = name,
                Description = description,
                Model = model,
                Speed = speed,
                Price = price,
                TypeCar = typeCar,
                Avatar = avatar
            };
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                if (Model.Id == 0)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(Model.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)Model.Avatar.Length);
                    }
                    await _carService.CreateCar(Model, imageData);
                }
                else
                {
                    await _carService.Edit(Model.Id, Model);
                }
            }  
            return Redirect("GetCars");
        }

        //[HttpPost]
        //public JsonResult GetTypes()
        //{
        //    var types = _carService.GetType();
        //    return Json(types.Data);
        //}


//        string errorMessages = "";
//            foreach (var item in ModelState)
//            {
                
//                if (item.Value.ValidationState == ModelValidationState.Invalid)
//                {
//                    errorMessages = $"{errorMessages}\nОшибки для свойства {item.Key}:\n";
//                    foreach (var error in item.Value.Errors)
//                    {
//                        errorMessages = $"{errorMessages}{error.ErrorMessage}\n";
//                    }
//}
//            }






        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
