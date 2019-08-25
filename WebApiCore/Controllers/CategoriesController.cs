using AutoMapper;
using EcommerceClient.Models.Structure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApiCore.DataAccess;
using WebApiCore.DataAccess.Models;
using WebApiCore.Entities;
using WebApiCore.Helpers.Messages;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICoreModel model;
        private readonly IMapper mapper;

        private Expression<Func<Dic_Categories, bool>> predicate = null;

        public CategoriesController(ICoreModel model, IMapper mapper)
        {
            this.model = model;
            this.mapper = mapper;
        }

        // GET: api/Dic_Categories
        [HttpGet]
        public async Task<IEnumerable<Categories>> Get(bool? state = null)
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

            return categories;
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Categories>> Get(int id)
        {
            //Construimos el predicado:
            this.predicate = x => x.Id == id;

            var entity = await this.model.GetOneAsync(this.predicate);

            if (entity == null)
                return BadRequest(Errors.ENTITYNOTFOUND);

            //Mapeamos el Resultado
            return this.map(entity);

        }

        // POST: api/Dic_Categories
        [HttpPost]
        public async Task<ActionResult<bool>> PostAsync([FromBody] Categories data)
        {
            //Mapeamos el structure model al diccionario
            var entity = this.mapper.Map<Dic_Categories>(data);

            //Agregamos la fecha de creación.
            entity.Cat_CreationDate = DateTime.Now;

            //Creamos la entidad en la base de datos.
            var result = await this.model.AddAsync(entity);
            return result;
        }

        // PUT: api/Dic_Categories/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(int id, [FromBody] Categories data)
        {
            if (id != data.Id)
                return BadRequest(Errors.INCORRECTDATA);

            this.predicate = x => x.Id == id;
            var entity = await this.model.GetOneAsync(this.predicate);

            if (entity == null)
                return BadRequest(Errors.ENTITYNOTFOUND);

            entity.Cat_Name = data.Name;
            entity.Cat_Status = data.Status;

            return await this.model.UpdateAsync(entity);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {

            this.predicate = x => x.Id == id;

            var entity = this.model.GetOneAsync(this.predicate);

            if (entity == null)
                return BadRequest(Errors.ENTITYNOTFOUND);

            return await this.model.DeleteAsync(entity);
        }

        /// <summary>
        /// Método encargado de mapear una lista de entidades 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<Categories> mapList(List<Dic_Categories> source) {

            return this.mapper.Map<List<Categories>>(source);

        }

        /// <summary>
        /// Método encargado de mapear una entidad
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private Categories map(Dic_Categories source)
        {
            return this.mapper.Map<Categories>(source);
        }
    }
}
