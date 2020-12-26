using AutoMapper.QueryableExtensions;
using CarPark.Models;
using CarPark.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPark.Repository
{
    public class ManufacturerRepository:IDisposable, IManufacturerRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<ManufacturerDTO> GetAll()
        {
            IQueryable<Manufacturer> list = db.Manufacturers;
            return list.ProjectTo<ManufacturerDTO>();
        }

        public Manufacturer GetById(int id)
        {
            return db.Manufacturers.FirstOrDefault(g => g.Id == id);
        }
    }
}