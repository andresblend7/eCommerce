using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Entities
{
    public class Dic_Products
    {
        public int Id { get; set; }
        /// <summary>
        /// Llave Foránea hacia la categoría principal del producto.
        /// </summary>
        [Required]
        [ForeignKey("Dic_Categories")]
        public int Pro_CategoryIdFk { get; set; }

        /// <summary>
        /// Subcategoria del producto
        /// </summary>
        [Required]
        [ForeignKey("Dic_SubCategories")]
        public int Pro_SubCategoryIdFk { get; set; }

        /// <summary>
        /// Usuario que creó el producto.
        /// </summary>
        [Required]
        [ForeignKey("Dic_Users")]
        public int Pro_CreationUserIdFk { get; set; }

        /// <summary>
        /// Foránea del id de la ciudad.
        /// </summary>
        [Required]
        public int Pro_CityIdFk { get; set; }

        /// <summary>
        /// Guid del producto.
        /// </summary>
        [Required]
        [MaxLength(64)]
        public string Pro_GuId { get; set; }

        /// <summary>
        /// Condición del producto {nuevo / usado}
        /// </summary>
        [Required]
        public bool Pro_Condition { get; set; }
     
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
        public decimal Pro_Price { get; set; }

        /// <summary>
        /// Stock Disponible del producto
        /// </summary>
        [Required]
        public int Pro_Stock { get; set; }
        

        /// <summary>
        /// Determina si tiene aplicado un descuento
        /// </summary>
        public bool Pro_IsOutlet { get; set; }

        /// <summary>
        /// Precio con descuento.
        /// </summary>
        public decimal Pro_OutletPrice { get; set; }

        /// <summary>
        /// Valor del porcentaje de descuento (1 - 100)
        /// </summary>
        public int Pro_OutletValue { get; set; }
        /// <summary>
        /// Path/ Nombre de la imágen principal del producto.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Pro_PrincipalImage { get; set; }

        [Required]
        public DateTime Pro_CreationDate { get; set; }

        public bool Pro_status { get; set; }

        [ForeignKey("Pro_CategoryIdFk")]
        public Dic_Categories PrincipalCategory { get; set; }

        [ForeignKey("Pro_SubCategoryIdFk")]
        public Dic_SubCategories SubCategory { get; set; }

        [ForeignKey("Pro_CreationUserIdFk")]
        public Dic_Users CreatorUser { get; set; }

        [ForeignKey("Pro_CityIdFk")]
        public Dic_Cities City { get; set; }

    }
}
