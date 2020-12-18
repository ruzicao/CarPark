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
    public class ManufacturersController : ApiController
    {
        IManufacturerRepository _repository { get; set; }

        public ManufacturersController(IManufacturerRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<ManufacturerDTO> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var m = _repository.GetById(id);
            if (m == null)
            {
                return NotFound();
            }
            return Ok(m);
        }
    }
}
