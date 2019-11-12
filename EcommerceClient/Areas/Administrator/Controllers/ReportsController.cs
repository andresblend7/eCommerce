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
    public class ReportsController : Controller
    {
        IWebApiCoreService webApi;

        public ReportsController(IWebApiCoreService webApi)
        {
            this.webApi = webApi;
        }



        // GET: Administrator/Reports
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ByCity(int idCity = 1)
        {

            var viewModel = new ReportsVModel();

            viewModel.SelledByCityData = await this.webApi.GetAsync<List<Reports>>("Reports/GetProductsSelledByCity", new { idCity });



            return View(viewModel);
        }

        public async Task<ActionResult> ByCategories()
        {

            var viewModel = new ReportsVModel();

            viewModel.SelledByCategoryData = await this.webApi.GetAsync<List<Reports>>("Reports/GetProductsSelledByCategory", null);



            return View(viewModel);

        }

        public async Task<ActionResult> ByProducts()
        {

            var viewModel = new ReportsVModel();

            viewModel.SelledByProductData = await this.webApi.GetAsync<List<Reports>>("Reports/GetByProducts", null);


            return View(viewModel);
        }
    }
}