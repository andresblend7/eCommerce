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
            this.Categories = new List<Category>();
            this.SubCategories = new List<SubCategory>();
        }

        public List<Category> Categories { get; set; }

        public List<SubCategory> SubCategories { get; set; }
    }
}