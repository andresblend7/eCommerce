using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Entities
{
    /// <summary>
    /// Subcategorias / tags de los productos
    /// </summary>
    public class SubCategories
    {
        public int Id { get; set; }

        /// <summary>
        /// Categoria a la cual pertenece
        /// </summary>
        [Required]
        [ForeignKey("Categories")]
        public int Sca_CategoryIdFk { get; set; }

        [ForeignKey("Sca_CategoryIdFk")]
        public Categories Category { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int Sca_CreationUserIdFk { get; set; }


        [ForeignKey("Sca_CreationUserIdFk")]
        public Users CreatorUser { get; set; }

        /// <summary>
        /// Nombre de la subcategoria
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string Sca_Name { get; set; }

        [MaxLength(256)]
        public string Sca_Description { get; set; }

        public DateTime Sca_CreationDate { get; set; }

        public bool Sca_Status { get; set; }
    }
}
