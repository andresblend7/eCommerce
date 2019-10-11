﻿using EcommerceClient.Models.Structure;
using EcommerceClient.Models.Views;
using EcommerceClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EcommerceClient.Controllers
{
    public class HomeController : Controller
    {

        IWebApiCoreService webApi;

        public HomeController(IWebApiCoreService webApi)
        {
            this.webApi = webApi;
        }

        public async Task<ActionResult> Index(int? idCategoria, int? idSubCategoria, bool? estado, int? ciudad)
        {
            //Lista de ciudades
            var cities = await this.webApi.GetAsync<List<City>>("Cities", null);
           
            //Categorias para el menu
            var categories = await this.webApi.GetAsync<List<Category>>("Categories/GetWithSubCategories", null);

            var products = new List<Product>();

            if (idSubCategoria != null)
            {
                products = await this.webApi.GetAsync<List<Product>>("Products/GetBySubCat", new { idSubCategoria });

            }
            else {
                //Productos de la primer categoria
                products = await this.webApi.GetAsync<List<Product>>("Products/GetByCategoryAsync", new { idCategory = categories.FirstOrDefault().Id });

            }



            var model = new HomeVModel() {
                Cities = cities,
                Categories = categories,
                Products = products
            };
            
            //Petición por id
            //var cityTest = await this.webApi.GetAsync<Cities>("Cities/5");
            
            return View(model);
        }


        public async Task<ActionResult> ProductInfo(string product) {

            //Obtenemos el producto
            var productResult = await this.webApi.GetAsync<Product>("Products/GetById", new { reff = product });

            var modelv = new ProductInfoVModel() { 
                Product = productResult
            };

            return View(modelv);
        }

        public async Task<JsonResult> Login(string email, string pass) {

            try
            {
                //Enviamos las credenciales para la autenticación
                var authUser = await this.webApi.PostAsync<User>("users/Auth", new { email = email, hashedpass = pass });

                var control = (authUser != null);

                return Json(new { control , data = authUser }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ Login" }, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}