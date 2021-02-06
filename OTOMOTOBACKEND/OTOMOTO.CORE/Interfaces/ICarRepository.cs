
using OTOMOTO.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OTOMOTO.CORE.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> getAllCars();
        Car getById(int id);
        void remove(int id);
        Task<int> add(Car car);
        Task Update(Car car); 
    }
}
