using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Entities
{
    /// <summary>
    /// Relación de las subcategorias que tiene un producto
    /// </summary>
    public class Products_SubCategories
    {
        public int Id { get; set; }

        /// <summary>
        /// Id del producto relacionado
        /// </summary>
        [Required]
        [ForeignKey("Products")]
        public int Psc_ProductIdFk { get; set; }

        [ForeignKey("Psc_ProductIdFk")]
        public Products Product { get; set; }

        /// <summary>
        /// Id de la subcategoría relacionada.
        /// </summary>
        [Required]
        [ForeignKey("SubCategories")]
        public int Psc_SubCategoryIdFk { get; set; }

        [ForeignKey("Psc_SubCategoryIdFk")]
        public SubCategories SubCategory { get; set; }

        public bool Psc_Status { get; set; }

    }
}
