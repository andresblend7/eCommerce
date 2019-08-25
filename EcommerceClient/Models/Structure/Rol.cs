using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Structure
{
    public class Rol
    {
        [MaxLength(16)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}