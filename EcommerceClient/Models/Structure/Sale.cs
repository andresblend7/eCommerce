using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Structure
{
    /// <summary>
    /// Información básica de la venta.
    /// </summary>
    public class Sale
    {
        public int Id { get; set; }

        /// <summary>
        /// Id del usuario que compró
        /// </summary>
        [Required]
        public int BuyerId { get; set; }

        /// <summary>
        /// Data del usuario que compró
        /// </summary>
        User User { get; set; }

        /// <summary>
        /// Precio total de la venta
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Fecha de la venta efectuada
        /// </summary>
        [Required]
        public DateTime SaleDate { get; set; }
    }
}