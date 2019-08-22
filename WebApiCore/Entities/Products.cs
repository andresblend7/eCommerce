using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Entities
{
    public class Products
    {
        public int Id { get; set; }
        /// <summary>
        /// Llave Foránea hacia la categoría principal del producto.
        /// </summary>
        [Required]
        [ForeignKey("Categories")]
        public int Pro_CategoryIdFk { get; set; }

        [ForeignKey("Pro_CategoryIdFk")]
        public Categories PrincipalCategory { get; set; }

        /// <summary>
        /// Guid del producto.
        /// </summary>
        [Required]
        [MaxLength(64)]
        public string Pro_GuId { get; set; }

        /// <summary>
        /// Usuario que creó el producto.
        /// </summary>
        [Required]
        [ForeignKey("Users")]
        public int Pro_CreationUserIdFk { get; set; }

        [ForeignKey("Pro_CreationUserIdFk")]
        public Users CreatorUser { get; set; }

        [Required]
        [MaxLength(64)]
        public string Pro_Name { get; set; }

        /// <summary>
        /// Descripción del producto.
        /// </summary>
        [MaxLength(512)]
        public string Pro_Description { get; set; }

        /// <summary>
        /// Precio original del producto
        /// </summary>
        public double Pro_Price { get; set; }

        /// <summary>
        /// Stock Disponible del producto
        /// </summary>
        [Required]
        public int Pro_Stock { get; set; }

        /// <summary>
        /// Precio con descuento.
        /// </summary>
        public double Pro_OutletPrice { get; set; }

        /// <summary>
        /// Tiene aplicado un descuento
        /// </summary>
        public bool ProIsOutlet { get; set; }




        /// <summary>
        /// Nombre de la imágen principal del producto.
        /// </summary>
        [Required]
        [MaxLength(64)]
        public string Pro_PrincipalImage { get; set; }

        [Required]
        public DateTime Pro_CreationDate { get; set; }

        public bool Pro_status { get; set; }

    }
}
