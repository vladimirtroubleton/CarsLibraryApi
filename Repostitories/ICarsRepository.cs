using CarsLibraryApi.Models;
using CarsLibraryApi.ViewModels;
using System.Threading.Tasks;

namespace CarsLibraryApi.Repostitories
{
    public interface ICarsRepository
    {
        Task CreateCar(CarModel car);
        Task<CarModel[]> GetAllCars();
        Task<CarModel[]> GetCarsByAttr(AttrCarFind attrCar);
        Task RemoveCar(CarModel car);
    }
}