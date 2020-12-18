using CarPark.Models;
using CarPark.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarPark.Controllers
{
    public class CarsController : ApiController
    {
        ICarRepository _repository { get; set; }

        public CarsController(ICarRepository repository)
        {
            _repository = repository;
        }
        public IQueryable<CarDTO> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var c = _repository.GetById(id);
            if (c == null)
            {
                return NotFound();
            }
            return Ok(c);
        }


        public IHttpActionResult Post(Car c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(c);
            return CreatedAtRoute("DefaultApi", new { id = c.Id }, c);
        }

        public IHttpActionResult Put(int id, Car c)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != c.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(c);
            }
            catch
            {
                throw;
            }

            return Ok(c);
        }

        public IHttpActionResult Delete(int id)
        {
            var c = _repository.GetById(id);
            if (c == null)
            {
                return NotFound();
            }
            _repository.Delete(c);
            return StatusCode(HttpStatusCode.Accepted);
        }

        [Route("api/carsbymanufacturer")]
        public IQueryable<CarDTO> GetByManufacturer(int id)
        { 
            return _repository.GetByManufacturer(id);
        }
    }
}
