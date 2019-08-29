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
            this.Cities = new List<Cities>();
        }
        public List<Cities> Cities { get; set; }
    }
}