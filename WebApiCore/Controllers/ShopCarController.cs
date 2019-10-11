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
using WebApiCore.Helpers.Enums;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopCarController : ControllerBase
    {
        private Expression<Func<Det_ShopCar, bool>> predicate;
        private readonly ICoreModel model;
        private readonly IMapper mapper;

        // GET: api/ShopCar
        [HttpGet ("GetByUser")]
        public async Task<ActionResult<IEnumerable<ShopCar>>> GetByUser(int idUser, bool allItems)
        {
            if (allItems)
                this.predicate = x => x.Shc_IdUserFk == idUser;
            else
                this.predicate = x => x.Shc_IdUserFk == idUser && x.Shc_Status != (int) EnumEstadosShopCar.Canceled;

            var entities = await this.model.SearchAsync(this.predicate);

            var shopCarItems = this.mapper.Map<List<ShopCar>>(entities);

            return Ok(shopCarItems);
        }

        // GET: api/ShopCar/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<ShopCar>> Get(int id)
        {
            this.predicate = x => x.Id == id;

            var entity = await this.model.GetOneAsync(this.predicate);

            var shopCar = this.mapper.Map<ShopCar>(entity);

            return Ok(shopCar);
        }

        // POST: api/ShopCar
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] ShopCar data)
        {
            var entity = this.mapper.Map<Det_ShopCar>(data);

            return await this.model.AddAsync(entity);


        }

        // PUT: api/ShopCar/5
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
