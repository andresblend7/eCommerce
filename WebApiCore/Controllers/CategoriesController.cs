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
        public async Task<IEnumerable<Category>> Get(bool? state = null)
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

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
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
        public async Task<ActionResult<bool>> PostAsync([FromBody] Category data)
        {
            //Mapeamos el structure model al diccionario
            var entity = this.mapper.Map<Dic_Categories>(data);

            //Agregamos la fecha de creación.
            entity.Cat_CreationDate = DateTime.Now;

            //Creamos la entidad en la base de datos.
            var result = await this.model.AddAsync(entity);
            return result;
        }

        /// <summary>
        /// Método Encargado de cambiar el estado de una entidad (Activo / inactivo)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("ChangeStatus")]
        public async Task<ActionResult<bool>> ChangeStatus(int id)
        {

            this.predicate = x => x.Id == id;

            //Obtenemos la entidad a actualizar
            var entity = await this.model.GetOneAsync(this.predicate);

            if (entity == null)
                return NotFound(Errors.ENTITYNOTFOUND);

            //Cambiamos el estado
            entity.Cat_Status = !entity.Cat_Status;

            //Hacemos la actualización
            return await this.model.UpdateAsync(entity);

        }

        /// <summary>
        /// Método encargado de la actualización de los datos básicos de una categoria
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        // PUT: api/Dic_Categories/5
        [HttpPut("{id}", Name = "Put")]
        public async Task<ActionResult<bool>> Put(int id, [FromBody] Category data)
        {
            if (id != data.Id)
                return BadRequest(Errors.INCORRECTDATA);

            this.predicate = x => x.Id == id;
            var entity = await this.model.GetOneAsync(this.predicate);

            if (entity == null)
                return BadRequest(Errors.ENTITYNOTFOUND);

            //Actualizamos los datos básicos
            entity.Cat_Name = data.Name;
            entity.Cat_Description = data.Description;

            return await this.model.UpdateAsync(entity);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            //Creamos el predicado
            this.predicate = x => x.Id == id;

            //Comprobamos que existe una entidad con ese Id
            var entity = await this.model.GetOneAsync(this.predicate);

            if (entity == null)
                return BadRequest(Errors.ENTITYNOTFOUND);

            //Obtenemos la lista de subcategorias asociadas.
            var subCats = await this.model.SearchAsync<Dic_SubCategories>(x => x.Sca_CategoryIdFk == entity.Id);

            //Eliminamos las subcategorias asociadas
            if (subCats != null)
                await this.model.DeleteListAsync(subCats);

            //Eliminamos la Categoria
            return await this.model.DeleteAsync(entity);
        }

        /// <summary>
        /// Método encargado de mapear una lista de entidades 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<Category> mapList(List<Dic_Categories> source)
        {

            return this.mapper.Map<List<Category>>(source);

        }

        /// <summary>
        /// Método encargado de mapear una entidad
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private Category map(Dic_Categories source)
        {
            return this.mapper.Map<Category>(source);
        }
    }
}
