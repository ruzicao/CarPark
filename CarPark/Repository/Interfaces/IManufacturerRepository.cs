using CarPark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Repository.Interfaces
{
    public interface IManufacturerRepository
    {
        IQueryable<ManufacturerDTO> GetAll();
        Manufacturer GetById(int id);
    }
}
