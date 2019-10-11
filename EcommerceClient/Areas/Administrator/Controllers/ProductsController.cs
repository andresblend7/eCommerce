using EcommerceClient.Models.Structure;
using EcommerceClient.Models.Views;
using EcommerceClient.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EcommerceClient.Areas.Administrator.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWebApiCoreService webApi;
        public ProductsController(IWebApiCoreService webApi)
        {
            this.webApi = webApi;
        }
        // GET: Administrator/Admin
        public async Task<ActionResult> Index()
        {
            //Obtenemos la lista de productos
            var products = await this.webApi.GetAsync<List<Product>>("Products");

            //Obtenemos la lista de ciudades
            var cities = await this.webApi.GetAsync<List<City>>("Cities");


            //Obtenemos la lista de categorias Activas
            var categories = await this.webApi.GetAsync<List<Category>>("Categories");

            //Los agregamos al viewModel
            var model = new ProductsVModel()
            {
                Products = products,
                Categories = categories,
                Cities = cities
            };

            return View(model);
        }

        public async Task<JsonResult> Create(Product product)
        {
            try
            {
                product.CreationUserId = 1;

                //Enviamos el producto al webApi para su creación
                var result = await this.webApi.PostAsync<bool, Product>("Products", product, null);

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ Create" }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> Delete(int id)
        {
            try
            {

                //Enviamos la categoria al webApi para su eliminación
                var result = await this.webApi.DeleteAsync("Products", id);

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ Create" }, JsonRequestBehavior.AllowGet);
            }
        }


        public async Task<JsonResult> Update(Product product)
        {
            try
            {
                product.CreationUserId = 1;

                //Enviamos el producto al webApi para su creación
                var result = await this.webApi.PutAsync<bool, Product>($"Products/{product.Id}", product, null);

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ Create" }, JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// Cambia el status de la categoria
        /// </summary>
        /// <param name="id"> id primary de la categoria</param>
        /// <returns></returns>
        public async Task<JsonResult> ChangeStatus(int id)
        {
            try
            {
                //Enviamos la categoria al webApi para su creación
                var result = await this.webApi.PutAsync<bool>("Products/ChangeStatus", new { id });

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ ChangeStatus" }, JsonRequestBehavior.AllowGet);
            }
        }


        public async Task<JsonResult> ApplyDiscount(int id, int discount) {

            try
            {
                //Enviamos la categoria al webApi para su creación
                var result = await this.webApi.PutAsync<bool>("Products/ApplyDiscount", new { id, discount });

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ ChangeStatus" }, JsonRequestBehavior.AllowGet);
            }

        }


        public async Task<JsonResult> RemoveDiscount(int id)
        {

            try
            {
                //Enviamos la categoria al webApi para su creación
                var result = await this.webApi.PutAsync<bool>("Products/RemoveDiscount", new { id });

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ ChangeStatus" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}