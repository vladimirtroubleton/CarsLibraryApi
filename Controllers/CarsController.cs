using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CarsLibraryApi.Models;
using CarsLibraryApi.Repostitories;
using CarsLibraryApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarsLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ILogRepostiory logRepostiory;
        private readonly ICarsRepository carsRepository;

        public CarsController(ILogRepostiory logRepostiory, ICarsRepository carsRepository)
        {
            this.logRepostiory = logRepostiory;
            this.carsRepository = carsRepository;
        }

        [HttpPost("CreateCar")]
        public async Task AddCarInDb(object carData)
        {
            var timer = Stopwatch.StartNew();
            var log = new LogModel { RequestStart = DateTime.Now };
            log.RequestBody = carData.ToString();
           
            try
            {
                var desirializeObject = Deserialize<CarModel>(carData.ToString());
                await carsRepository.CreateCar(desirializeObject);
                log.RequestEnd = DateTime.Now;
                log.Status = "Прошло отлично";
                log.TimeRequest = timer.ElapsedMilliseconds;
                await logRepostiory.CreateLog(log);
                Response.StatusCode = 200;
            }
            catch(Exception except)
            {
                Response.Headers.Add("Warning", except.Message);
                log.RequestEnd = DateTime.Now;
                log.Status = "Не удалось завершить";
                log.TimeRequest = timer.ElapsedMilliseconds;
                log.RequestBody = log.RequestBody + " Ошибка: " + except.Message;
                await logRepostiory.CreateLog(log);
                Response.StatusCode = 400;
                
            }

        }

        [HttpPost("GetCars")]
        public async Task<string> GetCars(object findData)
        {
            var timer = Stopwatch.StartNew();
            var log = new LogModel { RequestStart = DateTime.Now };
            try
            {
                var desirializeObject = Deserialize<AttrCarFind>(findData.ToString());
                var findedData = await carsRepository.GetCarsByAttr(desirializeObject);
                log.RequestEnd = DateTime.Now;
                log.Status = "Прошло отлично";
                log.TimeRequest = timer.ElapsedMilliseconds;
                await logRepostiory.CreateLog(log);
                return Serialize(findedData);

            }
            catch (Exception except)
            {
                Response.Headers.Add("Warning", except.Message);
                log.RequestEnd = DateTime.Now;
                log.Status = "Не удалось завершить";
                log.TimeRequest = timer.ElapsedMilliseconds;
                log.RequestBody = except.Message;
                await logRepostiory.CreateLog(log);
                Response.StatusCode = 400;
                return null;
            }

            }
        [HttpGet("GetCars")]
        public async Task<string> GetCars()
        {
            var timer = Stopwatch.StartNew();
            var log = new LogModel { RequestStart = DateTime.Now  , RequestBody = ""};
            var cars = await carsRepository.GetAllCars();
            log.RequestEnd = DateTime.Now;
            log.Status = "Прошло отлично";
            log.TimeRequest = timer.ElapsedMilliseconds;
            await logRepostiory.CreateLog(log);
            return Serialize(cars);
        }

        [HttpGet("GetCarsStat")]
        public async Task<string> GetCarsStat()
        {
            var cars = await carsRepository.GetAllCars();
            var logs = await logRepostiory.GetLogs();
            return string.Format("Количество записей {0} , дата первого обращения к системе {1}, дата последнего обращения к системе  {2} , количество успешных операций : {3} , количество ошибочных операций {4}",
                cars.Count().ToString(),
                logs.First().RequestEnd.ToString() ,
                logs.Last().RequestEnd.ToString(),
                logs.Where(x=> x.Status == "Прошло отлично").Count(),
                logs.Where(x=> x.Status == "Не удалось завершить").Count()

                );
        }

        private TResult Deserialize<TResult>(string obj)
        {
            return JsonConvert.DeserializeObject<TResult>(obj);
        }

        public string Serialize<TParam>(TParam obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}