using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceClient.Models.Structure;
using System.Linq.Expressions;
using WebApiCore.Entities;
using WebApiCore.DataAccess.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiCore.DataAccess;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {

        private readonly ICoreModel model;
        private readonly IMapper mapper;

        private readonly AppDbContext db;


        private Expression<Func<Dic_SubCategories, bool>> predicate = null;

        public SubCategoriesController(ICoreModel model, IMapper mapper, AppDbContext db)
        {
            this.model = model;
            this.mapper = mapper;

            this.db = db;
        }


        // GET: api/SubCategories
        [HttpGet]
        public async Task<IEnumerable<SubCategories>> Get(bool? state = null)
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
            var subCategories = this.mapper.Map<List<SubCategories>>(entities);

            //Retornamos las entidades ordenadas de forma descendente
            return subCategories.OrderByDescending(x => x.Id);
        }

        // GET: api/SubCategories/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SubCategories
        [HttpPost]
        public async Task<ActionResult<bool>> PostAsync([FromBody] SubCategories data)
        {
            //Mapeamos el structure model al diccionario
            //var entity = this.mapper.Map<Dic_SubCategories>(data);

            var entity = new Dic_SubCategories() {
                Sca_CategoryIdFk = data.CategoryId,
                Sca_Name= data.Name,
                Sca_Status = data.Status,
                Sca_Description= data.Description,
                Sca_CreationUserIdFk = data.CreationUser
                
            };


            //Agregamos la fecha de creación.
            entity.Sca_CreationDate = DateTime.Now;

            var m = await this.db.Dic_SubCategories.AddAsync(entity);


            //Creamos la entidad en la base de datos.
            var result = await this.db.SaveChangesAsync();

            return (result>0);
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
