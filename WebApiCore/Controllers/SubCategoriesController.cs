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
using WebApiCore.Helpers.Messages;

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
        public async Task<IEnumerable<SubCategory>> Get(bool? state = null)
        {
            //Preparamos el predicado de acuerdo a la petición
            if (state != null)
                this.predicate = x => x.Sca_Status == state;
            else
                this.predicate = x => x.Id > 0;

            //Obtenemos las subcategorias con su categoria principal
            var entities =  await this.model.GetAllAsync<Dic_SubCategories>()
                                            .Where(this.predicate)
                                            .Include(x=> x.Category)
                                            .ToListAsync();


            //Mapeamos el diccionario al model Structure
            var subCategories = this.mapper.Map<List<SubCategory>>(entities);

            //Retornamos las entidades ordenadas de forma descendente
            return subCategories.OrderByDescending(x => x.Id);
        }


        /// <summary>
        /// Método para obtener las subcategorias dependientes de una categoria
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        [HttpGet("GetFromCategory")]
        public async Task<IEnumerable<SubCategory>> GetFromCategory(int idCategoria) {

            //Obtenemos las subcategorias correspondientes a la categoria
            this.predicate = x => x.Sca_CategoryIdFk == idCategoria;

            var entities = await this.model.SearchAsync(this.predicate);

            //Mapeamos el diccionario al model Structure
            var subCategories = this.mapper.Map<List<SubCategory>>(entities);

            //Retornamos las entidades ordenadas de forma descendente
            return subCategories;
        }

        // POST: api/SubCategories
        [HttpPost]
        public async Task<ActionResult<bool>> PostAsync([FromBody] SubCategory data)
        {
            //Mapeamos el structure model al diccionario
            var entity = this.mapper.Map<Dic_SubCategories>(data);

            //Limpiamos la referencia para evitar errores en entityFramework
            entity.Category = null;

            //Agregamos la fecha de creación.
            entity.Sca_CreationDate = DateTime.Now;

            var result = await this.model.AddAsync<Dic_SubCategories>(entity);

            return result;
        }

       

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            //Comprobamos que existe la entidad
            this.predicate = x => x.Id == id;
            var entity = await this.model.GetOneAsync(this.predicate);

            if (entity == null)
                return BadRequest(Errors.ENTITYNOTFOUND);

            return await this.model.DeleteAsync(entity);

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
            entity.Sca_Status = !entity.Sca_Status;

            //Hacemos la actualización
            return await this.model.UpdateAsync(entity);

        }

        // PUT: api/SubCategories/5
        /// <summary>
        /// Método encargado de la actualización de los datos básicos de una SubCategoria
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(int id, [FromBody] SubCategory data)
        {
            if (id != data.Id)
                return BadRequest(Errors.INCORRECTDATA);

            //Comprobamos que existe la entidad
            this.predicate = x => x.Id == id;
            var entity = await this.model.GetOneAsync(this.predicate);

            if (entity == null)
                return BadRequest(Errors.ENTITYNOTFOUND);

            //Actualizamos los datos básicos
            entity.Sca_Name = data.Name;
            entity.Sca_Description = data.Description;
            entity.Sca_CategoryIdFk = data.CategoryId;

            return await this.model.UpdateAsync(entity);

        }
    }
}
