using AutoMapper;
using EcommerceClient.Models.Structure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private  Expression<Func<Dic_Cities, bool>> predicate = null;

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
            var entities =  await this.model.GetAllAsync<Dic_Cities>().ToListAsync();

            //Mapeamos la entidad al structure
            var cities =this.mapper.Map<List<Cities>>(entities);

            return cities;
        }

        //// GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cities>> Get(int id)
        {
            this.predicate = x => x.Id == id;

            //Obtenemos todas las ciudades
            var entities = await this.model.GetOneAsync(this.predicate);

            //Mapeamos la entidad al structure
            var city = this.mapper.Map<Cities>(entities);

            return city;

        }

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
