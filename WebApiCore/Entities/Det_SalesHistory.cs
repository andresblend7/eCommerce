using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Entities
{
    /// <summary>
    /// Histórico de ventas de los productos de forma detalleada
    /// </summary>
    public class Det_SalesHistory
    {
        public int Id { get; set; }

        /// <summary>
        /// Id de la venta realizada
        /// </summary>
        [Required]
        [ForeignKey("Sales")]
        public int Shi_SaleIdFk { get; set; }

        [ForeignKey("Shi_SaleIdFk")]
        public Dic_Sales Sale { get; set; }

        /// <summary>
        /// Id del usuario que compró
        /// </summary>
        [Required]
        [ForeignKey("Users")]
        public int Shi_BuyerIdFk { get; set; }


        [ForeignKey("Shi_BuyerIdFk")]
        public Dic_Users UserBuyer { get; set; }

        /// <summary>
        /// Id del producto comprado
        /// </summary>
        [Required]
        [ForeignKey("Products")]
        public int Shi_ProductIdFk { get; set; }

        [ForeignKey("Shi_ProductIdFk")]
        public Dic_Products Producto { get; set; }


        /// <summary>
        /// Precio del producto en el momento de ralizar la compra
        /// </summary>
        [Required]
        public decimal Shi_ProductCurrentPrice { get; set; }

        /// <summary>
        /// Cantidad del producto vendidos
        /// </summary>
        [Required]
        public int Shi_Quantity { get; set; }

        /// <summary>
        /// Precio total (Cantidad * precio)
        /// </summary>
        [Required]
        public decimal Shi_TotalPrice { get; set; }

    }
}
