using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceClient.Models.Structure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.DataAccess.Models;
using WebApiCore.Entities;

using EMS = EcommerceClient.Models.Structure;


namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ICoreModel model;

        public ReportsController(ICoreModel model)
        {
            this.model = model;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCity"></param>
        /// <returns>Retorna un diccionario int= cantidadProductosVendidos key= nombre del producto</returns>
        [HttpGet("GetProductsSelledByCity")]
        public async Task<List<Reports>> GetProductsSelledByCity(int idCity)
        {
            //Obtenemos los detalles de venta de la ciudad solicitada
            var result = await this.model.SearchAsync<Det_SalesHistory>(x => x.Shi_CityIdFk == idCity);

            //Obtenemos los datos del producto y creamos el diccionario
            var dicResult = new List<Reports>();

            foreach (var detalle in result)
            {

                //Obtenemos el nombre del producto
                var resultProduct = await this.model.GetOneAsync<Dic_Products>(x => x.Id == detalle.Shi_ProductIdFk);

                dicResult.Add(new Reports()
                {
                    Quantity = detalle.Shi_Quantity,
                    NombreBroducto = resultProduct.Pro_Name

                });

            }

            return dicResult;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCity"></param>
        /// <returns>Retorna un diccionario int= cantidadProductosVendidos key= nombre del producto</returns>
        [HttpGet("GetByProducts")]
        public async Task<List<Reports>> GetByProducts()
        {
            //Obtenemos las categorias  que hayan tenido ventas.
            var detalles = this.model.GetAllAsync<Det_SalesHistory>().OrderByDescending(x => x.Shi_ProductIdFk);

            //Obtenemos los datos de la categorua y creamos el diccionario
            var dicResult = new List<Reports>();


            //Recoremos los datos y obtenemos la info de la categoria:
            int countAux = 0;

            int lastProd = 0;

            foreach (var detVenta in detalles)
            {

                if (lastProd != detVenta.Shi_ProductIdFk)
                {


                    var detalleByProd = await this.model.SearchAsync<Det_SalesHistory>(x => x.Shi_ProductIdFk == detVenta.Shi_ProductIdFk);

                    //Obtenemos el nombre del producto
                    var resultPRoduct = await this.model.GetOneAsync<Dic_Products>(x => x.Id == detVenta.Shi_ProductIdFk);


                    foreach (var detCat in detalleByProd)
                    {
                        countAux += detCat.Shi_Quantity;
                    }

                    dicResult.Add(new Reports()
                    {
                        Quantity = countAux,
                        NombreBroducto = resultPRoduct.Pro_Name

                    });

                    countAux = 0;
                }

                lastProd = detVenta.Shi_CategoryIdFk;
            }


            return dicResult;

        }

        /// <summary>
        /// Método para obtener las ventas por categoria
        /// </summary>
        /// <param name="idCity"></param>
        /// <returns>Retorna un diccionario int= cantidadProductosVendidos key= nombre del producto</returns>
        [HttpGet("GetProductsSelledByCategory")]
        public async Task<List<Reports>> GetProductsSelledByCategory()
        {
            //Obtenemos las categorias  que hayan tenido ventas.
            var detalles = this.model.GetAllAsync<Det_SalesHistory>().OrderByDescending(x => x.Shi_CategoryIdFk);

            //Obtenemos los datos de la categorua y creamos el diccionario
            var dicResult = new List<Reports>();


            //Recoremos los datos y obtenemos la info de la categoria:
            int countAux = 0;

            int lastCat = 0;

            foreach (var detVenta in detalles)
            {

                if (lastCat != detVenta.Shi_CategoryIdFk)
                {


                    var detalleByCat = await this.model.SearchAsync<Det_SalesHistory>(x => x.Shi_CategoryIdFk == detVenta.Shi_CategoryIdFk);

                    //Obtenemos el nombre del producto
                    var resultCategory = await this.model.GetOneAsync<Dic_Categories>(x => x.Id == detVenta.Shi_CategoryIdFk);


                    foreach (var detCat in detalleByCat)
                    {
                        countAux += detCat.Shi_Quantity;
                    }

                    dicResult.Add(new Reports()
                    {
                        Quantity = countAux,
                        NombreBroducto = resultCategory.Cat_Name

                    });

                    countAux = 0;
                }

                lastCat = detVenta.Shi_CategoryIdFk;
            }


            return dicResult;

        }

        // POST: api/Reports
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Reports/5
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
