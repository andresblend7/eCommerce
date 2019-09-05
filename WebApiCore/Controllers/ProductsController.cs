using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceClient.Models.Structure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.DataAccess.Models;
using WebApiCore.Entities;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private Expression<Func<Dic_Products, bool>> predicate;
        private readonly ICoreModel model;
        private readonly IMapper mapper;

        public ProductsController(ICoreModel model, IMapper mapper)
        {
            this.model = model;
            this.mapper = mapper;
        }


        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> Get(bool? state = null)
        {
            //Construimos el predicado
            if (state != null)
                this.predicate = x => x.Pro_status == state;
            else
                this.predicate = x => x.Id > 0;

            //Obtenemos los productos
            var entities = await this.model.SearchAsync(this.predicate);

            var products = this.mapper.Map<List<Product>>(entities);

            return products;

        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Products/5
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
