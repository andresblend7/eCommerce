using EcommerceClient.Models.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Views
{
    public class CategoriesVModel
    {
        public CategoriesVModel()
        {
            this.Categories = new List<Categories>();
        }
        public List<Categories> Categories { get; set; }

        public Categories Category { get; set; }

    }
}