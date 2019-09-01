using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ST = EcommerceClient.Models.Structure;
using System.Linq.Expressions;
using WebApiCore.Entities;
using WebApiCore.DataAccess.Models;
using AutoMapper;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {

        private readonly ICoreModel model;
        private readonly IMapper mapper;

        private Expression<Func<Dic_SubCategories, bool>> predicate = null;

        public SubCategoriesController(ICoreModel model, IMapper mapper)
        {
            this.model = model;
            this.mapper = mapper;
        }


        // GET: api/SubCategories
        [HttpGet]
        public async Task<IEnumerable<ST.>> Get(bool? state = null)
        {
            //Preparamos el predicado de acuerdo a la petición
            if (state != null)
                this.predicate = x => x.Cat_Status == state;
            else
                this.predicate = x => x.Id > 0;

            //Obtenemos las Categorias segun el predicado creado
            var entities = await this.model.SearchAsync(this.predicate);

            //Mapeamos el diccionario al model Structure
            var categories = this.mapList(entities);

            //Retornamos las entidades ordenadas de forma descendente
            return categories.OrderByDescending(x => x.Id);
        }

        // GET: api/SubCategories/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SubCategories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/SubCategories/5
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
