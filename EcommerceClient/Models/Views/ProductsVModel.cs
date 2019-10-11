using EcommerceClient.Models.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Views
{
    public class ProductsVModel
    {
        public ProductsVModel()
        {
            this.Products = new List<Product>();
        }
        public List<Product> Products { get; set; }
        public List<City> Cities { get; set; }
        public List<Category> Categories { get; set; }

    }
}