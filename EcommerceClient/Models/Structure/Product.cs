using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Structure
{
    public class Product
    {
        public Product()
        {
            this.Images = new List<ImagesProduct>();
        }

        public int Id { get; set; }
        /// <summary>
        /// Llave Foránea hacia la categoría principal del producto.
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SubCategoryId { get; set; }
        /// <summary>
        /// Usuario que creó el producto.
        /// </summary>
        [Required]
        public int CreationUserId { get; set; }

        /// <summary>
        /// Foránea del id de la ciudad dónde se venderá el producto
        /// </summary>
        [Required]
        public int CityId { get; set; }


        /// <summary>
        /// Guid del producto.
        /// </summary>
        [Required]
        [MaxLength(64)]
        public string GuId { get; set; }

        /// <summary>
        /// Condición del producto {nuevo / usado}
        /// </summary>
        [Required]
        public bool Condition { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        /// <summary>
        /// Descripción del producto.
        /// </summary>
        [MaxLength(512)]
        public string Description { get; set; }

        /// <summary>
        /// Precio original del producto
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Stock Disponible del producto
        /// </summary>
        [Required]
        public int Stock { get; set; }

        /// <summary>
        /// Precio con descuento.
        /// </summary>
        public decimal OutletPrice { get; set; }

        /// <summary>
        /// Determina si tiene aplicado un descuento
        /// </summary>
        public bool IsOutlet { get; set; }

        /// <summary>
        /// Valor del porcentaje de descuento (1 - 100)
        /// </summary>
        public int OutletValue { get; set; }

        /// <summary>
        /// Path/ Nombre de la imágen principal del producto.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string PrincipalImage { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public bool Status { get; set; }

        /// <summary>
        /// Lista de imágenes secundarias del producto
        /// </summary>
        List<ImagesProduct> Images { get; set; }
    }
}