using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Structure
{
    public class SubCategory
    {

        public int Id { get; set; }

        /// <summary>
        /// Categoria a la cual pertenece
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
     
        public int CreationUser { get; set; }

        /// <summary>
        /// Nombre de la subcategoria
        /// </summary>
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Status { get; set; }


    }
}