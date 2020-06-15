using CarsLibraryApi.Context;
using CarsLibraryApi.Models;
using CarsLibraryApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsLibraryApi.Repostitories
{
    public class CarsRepository : ICarsRepository
    {
        private CarsContext context;
        object glush = new object();
        public CarsRepository(CarsContext context)
        {
            this.context = context;
        }

        public async Task CreateCar(CarModel car)
        {
            lock (glush)
            {
                context.Cars.Add(car);
            };
            await context.SaveChangesAsync();
        }

        public Task<CarModel[]> GetAllCars()
        {
            return Task.FromResult(context.Cars.ToArray());
        }

        public async Task RemoveCar(CarModel car)
        {
            lock (glush)
            {
                context.Cars.Remove(car);
            }
            await context.SaveChangesAsync();

        }

        public async Task<CarModel[]> GetCarsByAttr(AttrCarFind attrCar)
        {
            switch (attrCar.AttrKey)
            {
                case "Number":
                    {
                        return await context.Cars.Where(x => x.Number == attrCar.AttrValues).ToArrayAsync();
                    }
                case "TypeCar":
                    {
                        return await context.Cars.Where(x => x.Type == attrCar.AttrValues).ToArrayAsync();
                    }
                case "Model":
                    {
                        return await context.Cars.Where(x => x.Model == attrCar.AttrValues).ToArrayAsync();
                    }
                case "ReleaseYear":
                    {
                        return await context.Cars.Where(x => x.ReleaseYear == int.Parse(attrCar.AttrValues)).ToArrayAsync();
                    }
                case "OwnerName":
                    {
                        return await context.Cars.Where(x => x.OwnerName == attrCar.AttrValues).ToArrayAsync();
                    }
                case "CountHourseForces":
                    {
                        return await context.Cars.Where(x => x.CountHourseForces == attrCar.AttrValues).ToArrayAsync();
                    }
                default:
                    {
                        return null;
                    }
            }

        }
    }
}
