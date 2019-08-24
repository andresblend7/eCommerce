using AutoMapper;
using EcommerceClient.Models.Structure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.DataAccess;
using WebApiCore.DataAccess.Models;
using WebApiCore.Entities;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly CategoriesModel model;
        private readonly IMapper mapper;

        public CategoriesController(CategoriesModel model, IMapper mapper)
        {
            this.model = model;
            this.mapper = mapper;
        }

        // GET: api/Dic_Categories
        [HttpGet]
        public IEnumerable<Categories> Get()
        {
            //Obtenemos las Categorias 
            var entities = this.model.GetAll<Dic_Categories>().Where(x=> x.Cat_Status);

            var categories = this.mapper.Map<List<Categories>>(entities);

            return categories;
        }

        // GET: api/Dic_Categories/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Dic_Categories
        [HttpPost]
        public async Task<bool> PostAsync([FromBody] Categories data)
        {
            var result = await this.model.CreateAsync(new Entities.Dic_Categories()
            {
                Cat_CreationDate = DateTime.Now,
                Cat_CreationUserIdFk = data.CreationUser,
                Cat_Description = data.Description,
                Cat_Name = data.Name,
                Cat_Status = data.Status
            });

            return result;
        }

        // PUT: api/Dic_Categories/5
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
