using CarPark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Repository.Interfaces
{
    public interface ICarRepository
    {
        IQueryable<CarDTO> GetAll();
        Car GetById(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        IQueryable<CarDTO> GetByManufacturer(int idManufacturer);
    }
}
