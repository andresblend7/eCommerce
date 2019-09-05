using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Structure
{
    /// <summary>
    /// Strcutura de la relación entre imágenes secundarias y el producto
    /// </summary>
    public class ImagesProduct
    {
        public int id { get; set; }

        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// Nombre con extensión de la imágen del producto.
        /// </summary>
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        /// <summary>
        /// Ruta pArcial dónde se encuentra la imagen
        /// </summary>
        public string Path { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Status { get; set; }

    }
}