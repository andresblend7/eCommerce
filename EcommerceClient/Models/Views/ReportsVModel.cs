using EcommerceClient.Models.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Views
{
    public class ReportsVModel
    {
        public List<Reports> SelledByCityData { get; set; }
        public List<Reports> SelledByCategoryData { get; set; }
        public List<Reports> SelledByProductData { get; set; }

    }
}