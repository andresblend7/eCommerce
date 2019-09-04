using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Structure
{
    /// <summary>
    /// Histórico de ventas de los productos de forma detallada
    /// </summary>
    public class SaleHistory
    {
        public int Id { get; set; }

        /// <summary>
        /// Id del diccionario de la venta realizada
        /// </summary>
        [Required]
        public int SaleIdFk { get; set; }

        /// <summary>
        /// Id del usuario que compró
        /// </summary>
        [Required]
        public int BuyerId { get; set; }

        /// <summary>
        /// Id del producto comprado
        /// </summary>
        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// Precio del producto en el momento de ralizar la compra
        /// </summary>
        [Required]
        public decimal ProductCurrentPrice { get; set; }

        /// <summary>
        /// Cantidad del producto vendidos
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Precio total (Cantidad * precio)
        /// </summary>
        [Required]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Información básica de la venta.
        /// </summary>
        public Sale Sale { get; set; }

    }
}