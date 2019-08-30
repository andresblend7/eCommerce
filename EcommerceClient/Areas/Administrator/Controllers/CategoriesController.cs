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
    public class CategoriesController : Controller
    {
        CategoriesVModel viewModel;
        IWebApiCoreService webApi;

        public CategoriesController(IWebApiCoreService webApi)
        {
            this.webApi = webApi;
        }

        // GET: Administrator/Categories
        public async Task<ActionResult>Index()
        {
            //Obtenemos las categorias existentes.
            var categories =  await this.webApi.GetAsync<List<Categories>>("categories");

            //Instanciamos el viewModel
            this.viewModel = new CategoriesVModel() {
                Categories = categories
            };

            return View(this.viewModel);
        }

        public async Task<JsonResult> Create(Categories category)
        {
            try
            {
                var  x = 31;
               

                return Json(new { control = true, data = x }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ Create" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}