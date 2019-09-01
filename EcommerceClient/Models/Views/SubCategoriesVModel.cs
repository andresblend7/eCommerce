using EcommerceClient.Models.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Views
{
    public class SubCategoriesVModel
    {
        public SubCategoriesVModel()
        {
            this.Categories = new List<Categories>();
            this.SubCategories = new List<SubCategories>();
        }

        public List<Categories> Categories { get; set; }

        public List<SubCategories> SubCategories { get; set; }
    }
}