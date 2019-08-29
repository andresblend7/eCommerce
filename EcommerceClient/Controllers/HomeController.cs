using EcommerceClient.Models.Structure;
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

        public async Task<ActionResult> Index()
        {
            var cities = await this.webApi.GetAsync<List<Cities>>("Cities", null);

            var model = new HomeVModel() {
                Cities = cities
            };

            var queryString = new NameValueCollection();
            queryString.Add("id", ""+5);

            var cityTest = await this.webApi.GetAsync<Cities>("Cities", queryString);
            
            return View(model);
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