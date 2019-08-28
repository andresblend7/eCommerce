using AutoMapper;
using EcommerceClient.Models.Structure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApiCore.DataAccess.Models;
using WebApiCore.Entities;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICoreModel model;
        private readonly IMapper mapper;

        private readonly Expression<Func<Dic_Cities, bool>> predicate = null;

        public CitiesController(ICoreModel model, IMapper mapper)
        {
            this.model = model;
            this.mapper = mapper;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<List<Cities>>> Get()
        {
            //Obtenemos todas las ciudades
            var entities = await this.model.GetAllAsync<Dic_Cities>();

            //Mapeamos la entidad al structure
            var cities =this.mapper.Map<List<Cities>>(entities);

            return cities;
        }

        //// GET: api/Cities/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Cities
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
