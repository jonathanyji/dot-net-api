using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySampleAPI.Models;
using MySampleAPI.Data;

namespace MySampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApiContext _context;

        public CarsController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult CreateCar(Car car)
        {
            if (car.Make != null || car.Model != null) {
                _context.cars.Add(car);
                _context.SaveChanges();
            } else
            {
                return new JsonResult(BadRequest());
            }

            return new JsonResult(Ok());
        }

        [HttpPut]
        public JsonResult UpdateCar(Car car)
        {
            if (car.Make != null || car.Model != null)
            {
                var findCarInDb = _context.cars.Find(car.Id);

                if (findCarInDb == null)
                    return new JsonResult(NotFound());

                findCarInDb = car;
                _context.SaveChanges();
            } else
            {
                return new JsonResult(BadRequest());
            }

            return new JsonResult(Ok());
        }

        [HttpGet]
        public JsonResult GetCar(int id)
        {
            var result = _context.cars.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpDelete]
        public JsonResult DeleteCar(int id)
        {
            var result = _context.cars.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.cars.Remove(result);
            _context.SaveChanges();

            return new JsonResult(Ok());
        }
    }
}
