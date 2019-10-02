using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceClient.Models.Structure
{
    public class Category
    {
        public Category()
        {
            SubCategories = new List<SubCategory>();
        }

        public int Id { get; set; }

        /// <summary>
        /// Id foránea del usuario que creó la categoría.
        /// </summary>
        public int CreationUser { get; set; }

        /// <summary>
        /// Nombre de la categoria.
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }
        /// <summary>
        /// Descripción de la Categoria.
        /// </summary>
        [MaxLength(256)]
        public string Description { get; set; }

        public bool Status { get; set; }


        public List<SubCategory> SubCategories { get; set; }

    }
}