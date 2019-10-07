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
using WebApiCore.Helpers.Messages;

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

        // GET: api/Products
        [HttpGet ("GetBySubCat")]
        public async Task<IEnumerable<Product>> GetBySubCat(int idSubCategoria)
        {
            //Construimos el predicado
           
            this.predicate = x => x.Pro_SubCategoryIdFk == idSubCategoria;

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

        [HttpGet("GetByCategoryAsync")]
        public async Task<ActionResult<List<Product>>> GetByCategoryAsync(int idCategory) {

            this.predicate = x => x.Pro_CategoryIdFk == idCategory;

            var entities = await this.model.SearchAsync(this.predicate);

            var products = this.mapper.Map<List<Product>>(entities);

            return products;
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<bool>> PostAsync([FromBody] Product data)
        {
            //Mapeamos el structure model al diccionario
            var entity = this.mapper.Map<Dic_Products>(data);

            //Agregamos las datos autogenerados
            entity.Pro_CreationDate = DateTime.Now;
            entity.Pro_status = true;
            entity.Pro_GuId = Guid.NewGuid().ToString();

            //Elimina referencias innecesarias
            entity.PrincipalCategory = null;
            entity.SubCategory = null;
            entity.CreatorUser = null;
            entity.City = null;

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
            entity.Pro_status = !entity.Pro_status;

            //Hacemos la actualización
            return await this.model.UpdateAsync(entity);

        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutAsync(int id, [FromBody] Product data)
        {
            if (id != data.Id)
                return BadRequest(Errors.INCORRECTDATA);

            //Comprueba que exista la entidad
            this.predicate = x => x.Id == id;
            var entity = await this.model.GetOneAsync(this.predicate);

            if (entity == null)
                return BadRequest(Errors.ENTITYNOTFOUND);

            //Actualiza los datos básicos
            entity.Pro_Name = data.Name;
            entity.Pro_Description = data.Description;
            entity.Pro_CategoryIdFk = data.CategoryId;
            entity.Pro_Condition = data.Condition;
            entity.Pro_Price = data.Price;
            entity.Pro_CityIdFk = data.CityId;
            entity.Pro_Stock = data.Stock;

            return await this.model.UpdateAsync(entity);
        }


        /// <summary>
        /// Método encargado de aplicar un descuento a un producto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="discount">1 - 100 % de descuento</param>
        [HttpPut("ApplyDiscount")]
        public async Task<ActionResult<bool>> ApplyDiscount(int id, int discount)
        {
            //Comprobamos que exista el producto.
            this.predicate = x => x.Id == id;
            var product = await this.model.GetOneAsync(this.predicate);

            if (product == null)
                return NotFound();
         
            //Calcula el descuento
            var actualPrice = product.Pro_Price;
            var discountToApply = (actualPrice * discount) / 100;

            //Aplica el descuento
            product.Pro_OutletValue = discount;
            product.Pro_OutletPrice = (actualPrice - discountToApply);

            //Coloca el producto en descuento.
            product.Pro_IsOutlet = true;

            return await this.model.UpdateAsync(product);

        }


        /// <summary>
        /// Método encargado de quitar un descuento a un producto.
        /// </summary>
        /// <param name="id">id del producto</param>
        [HttpPut("RemoveDiscount")]
        public async Task<ActionResult<bool>> RemoveDiscount(int id)
        {
            //Comprobamos que exista el producto.
            this.predicate = x => x.Id == id;
            var product = await this.model.GetOneAsync(this.predicate);

            if (product == null)
                return NotFound();

            //Quita el descuento
            product.Pro_OutletValue = 0;
            product.Pro_OutletPrice = 0;

            //Quita el producto en descuento.
            product.Pro_IsOutlet = false;

            return await this.model.UpdateAsync(product);
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
                     
            //Eliminamos el producto
            return await this.model.DeleteAsync(entity);
        }
    }
}
