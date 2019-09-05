using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Structure
{
    /// <summary>
    /// Estructura de la realción entre productos (*)  y subcategorias (*)
    /// </summary>
    public class ProductSubCategories
    {
        public int Id { get; set; }

        /// <summary>
        /// Id del producto relacionado
        /// </summary>
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        public bool Psc_Status { get; set; }
    }
}