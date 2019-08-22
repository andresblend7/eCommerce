using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Entities
{
    public class Categories
    {
        public int Id { get; set; }

        /// <summary>
        /// Id foránea del usuario que creó la categoría.
        /// </summary>
        [Required]
        [ForeignKey("Users")]
        public int Cat_CreationUserIdFk { get; set; }

        /// <summary>
        /// Nombre de la categoria.
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Cat_Name { get; set; }
        /// <summary>
        /// Descripción de la Categoria.
        /// </summary>
        [MaxLength(256)]
        public string Cat_Description { get; set; }
   
        public DateTime Cat_CreationDate { get; set; }
        public bool Cat_Status { get; set; }


        [ForeignKey("Cat_CreationUserIdFk")]
        public Users CreatorUser { get; set; }
    }
}
