﻿using EcommerceClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index()
        {
           int x = this.webApi.GetNumero();
            ClaseA obj = new ClaseA() {
                asd = 32
                ass = 21

            };
            return View();
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