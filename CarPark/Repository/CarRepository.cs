using AutoMapper.QueryableExtensions;
using CarPark.Models;
using CarPark.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace CarPark.Repository
{
    public class CarRepository: IDisposable, ICarRepository
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

        public IQueryable<CarDTO> GetAll()
        {
            IQueryable<Car> list = db.Cars.Include(p => p.Manufacturer);
            return list.ProjectTo<CarDTO>();
        }



        public Car GetById(int id)
        {
            return db.Cars.Include(p => p.Manufacturer).FirstOrDefault(g => g.Id == id);
        }

        public void Add(Car c)
        {
            db.Cars.Add(c);
            db.SaveChanges();
        }

        public void Delete(Car c)
        {
            db.Cars.Remove(c);
            db.SaveChanges();
        }

        public void Update(Car c)
        {
            db.Entry(c).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }


        public IQueryable<CarDTO> GetByManufacturer(int idManufacturer)
        {
            IQueryable<Car> list = db.Cars.Include(p => p.Manufacturer).Where(m => m.ManufacturerId==idManufacturer).OrderByDescending(y=>y.Year);
            return list.ProjectTo<CarDTO>();
        }


    }
}