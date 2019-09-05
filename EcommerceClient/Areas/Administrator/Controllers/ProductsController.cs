using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceClient.Areas.Administrator.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Administrator/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create() {

            return View();
        }
    }
}