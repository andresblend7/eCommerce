using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCore.Entities
{
    /// <summary>
    /// Relación de imágenes y productos.
    /// </summary>
    public class Det_Images_Products
    {
        public int id { get; set; }

        [Required]
        [ForeignKey("Products")]
        public int Imp_ProductIdFk { get; set; }

        /// <summary>
        /// Nombre con extensión de la imágen del producto.
        /// </summary>
        [Required]
        [MaxLength(64)]
        public string Imp_Name { get; set; }

        [Required]
        [MaxLength(256)]
        /// <summary>
        /// Ruta parcial dónde se encuentra la imágen
        /// </summary>
        public string Imp_Path { get; set; }

        public DateTime Imp_CreationDate { get; set; }

        public bool Imp_Status { get; set; }

        [ForeignKey("Imp_ProductIdFk")]
        public Dic_Products Product { get; set; }
    }
}
