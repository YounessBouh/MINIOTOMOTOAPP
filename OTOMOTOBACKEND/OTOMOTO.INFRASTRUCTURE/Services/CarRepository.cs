

using Microsoft.EntityFrameworkCore;
using OTOMOTO.CORE.Entities;
using OTOMOTO.CORE.Interfaces;
using OTOMOTO.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTOMOTO.INFRASTRUCTURE.Services
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;
        public CarRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<int> add(Car car)
        {
             _context.Add(car);
           await _context.SaveChangesAsync();
            return car.Id;
        }

        public IEnumerable<Car> getAllCars()
        {
            return _context.Cars.Include(x=>x.Pictures).ToList();
        }

        public Car getById(int id)
        {
            return _context.Cars.Include(x => x.Pictures).Include(x => x.appUser)
                .FirstOrDefault(x => x.Id == id);
        }

        public void remove(int id)
        {
            var model=getById(id);
            _context.Cars.Remove(model);
            _context.SaveChanges();
        }

        public async Task Update(Car car)
        {
            _context.Cars.Update(car);
           await _context.SaveChangesAsync();
        }

        
    }
}
