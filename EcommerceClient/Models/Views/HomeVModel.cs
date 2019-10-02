using EcommerceClient.Models.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Views
{
    public class HomeVModel
    {
        public HomeVModel()
        {
            this.Cities = new List<City>();
            this.Categories = new List<Category>();
            this.Products = new List<Product>();
        }
        public List<City> Cities { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}