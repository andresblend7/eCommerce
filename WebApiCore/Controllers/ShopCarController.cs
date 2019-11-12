using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceClient.Models.Structure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCore.DataAccess.Models;
using WebApiCore.Entities;
using WebApiCore.Helpers.Enums;
using WebApiCore.Helpers.Messages;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopCarController : ControllerBase
    {
        private Expression<Func<Det_ShopCar, bool>> predicate;
        private readonly ICoreModel model;
        private readonly IMapper mapper;

        public ShopCarController(ICoreModel model, IMapper mapper)
        {
            this.model = model;
            this.mapper = mapper;
        }

        // GET: api/ShopCar
        [HttpGet ("GetByUser")]
        public async Task<ActionResult<IEnumerable<ShopCar>>> GetByUser(int idUser, bool allItems)
        {
            if (allItems)
                this.predicate = x => x.Shc_IdUserFk == idUser;
            else
                this.predicate = x => x.Shc_IdUserFk == idUser && x.Shc_Status != (int) EnumEstadosShopCar.Canceled && x.Shc_Status != (int)EnumEstadosShopCar.Buyed;

            var entities = await this.model.GetAllAsync<Det_ShopCar>()
                                           .Where(this.predicate)
                                           .Include(x => x.Product)
                                           .ToListAsync();

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
            //Que le den al mapper ._."
            var entity = new Det_ShopCar()
            {

                Id = data.Id,
                Shc_DateCreation = data.DateCreation,
                Shc_IdProductFk = data.IdProduct,
                Shc_IdUserFk = data.IdUser,
                Shc_Quantity = data.Quantity,
                Shc_Status = data.IdStatus
            };

            return await this.model.AddAsync(entity);


        }

        /// <summary>
        /// Método para comprar todos los items del carrito de un usuario
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns> diccionario, estado final , mensaje</returns>
        [HttpPost("BuyShopCarItems")]
        public async Task<ActionResult<KeyValuePair<bool, string>>> BuyShopCarItems(int idUser)
        {

            var result = new KeyValuePair<bool, string>();


            //Obtenemos todos los items del carrito en estado pendiente
            this.predicate = x => x.Shc_IdUserFk == idUser && x.Shc_Status == (int) EnumEstadosShopCar.Pending;
            var items = await this.model.GetAllAsync<Det_ShopCar>()
                                           .Where(this.predicate)
                                           .Include(x => x.Product)
                                           .ToListAsync();

            decimal totalPrice =0;

            //Obtenemos el total a pagar
            foreach (var item in items) 
                totalPrice += (item.Product.Pro_IsOutlet) ? item.Product.Pro_OutletPrice : item.Product.Pro_Price;


            //Obtenemos el dinero del usuario
            var dataUser = await  this.model.GetOneAsync<Dic_Users>(x => x.Id == idUser);

            if (totalPrice > dataUser.Use_Money)
            {
                result = new KeyValuePair<bool, string>(false, "El usuario no tiene los fondos suficientes");
            }
            else {

                //Descontamos el dinero de la cartera
                int totalPriceReduce = int.Parse(Math.Round(totalPrice, 0).ToString());
                dataUser.Use_Money -= totalPriceReduce;
                _ = await this.model.UpdateAsync(dataUser);

                //Se Procede a quitar los items del carrito
                foreach (var item in items) {
                    item.Product = null;
                    item.Shc_Status = (int) EnumEstadosShopCar.Buyed;

                   _ = await this.model.UpdateAsync(item);


                    //Descontamos el stock de los productos
                    var product = await this.model.GetOneAsync<Dic_Products>(x => x.Id == item.Shc_IdProductFk);
                    product.Pro_Stock -= 1;
                    _ = await this.model.UpdateAsync(product);

                }

                result = new KeyValuePair<bool, string>(true, "Compra exitosa");

            }


            return Ok(result);


        }

        // PUT: api/ShopCar/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
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

            var result = await this.model.DeleteAsync(entity);

            return Ok(result);

        }
    }
}
