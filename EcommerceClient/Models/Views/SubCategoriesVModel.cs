﻿using EcommerceClient.Models.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Views
{
    public class SubCategoriesVModel
    {
        public List<Categories> Categories { get; set; }

        public List<SubCategories> SubCategories { get; set; }
    }
}