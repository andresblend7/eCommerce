using EcommerceClient.Models.Structure;
using EcommerceClient.Models.Views;
using EcommerceClient.Services;
using System;
using System.Collections.Generic;
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
            var categories = await this.webApi.GetAsync<List<Category>>("Categories", new { state = true});

            //Los agregamos al viewModel
            var model = new ProductsVModel() {
                Products = products,
                Categories = categories,
                Cities = cities
            };

            return View(model);
        }

        public ActionResult Create() {

            return View();
        }
    }
}