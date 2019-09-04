using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Entities
{
    /// <summary>
    /// Información básica de la venta.
    /// </summary>
    public class Dic_Sales
    {
        public int Id { get; set; }

        /// <summary>
        /// Id del usuario que compró
        /// </summary>
        [Required]
        [ForeignKey("Users")]
        public int Sal_BuyerId { get; set; }

        [ForeignKey("Sal_BuyerId")]
        public Dic_Users UserBuyer { get; set; }

        /// <summary>
        /// Precio total de la venta
        /// </summary>
        public decimal Sal_TotalPrice { get; set; }

        /// <summary>
        /// Fecha de la venta efectuada
        /// </summary>
        [Required]
        public DateTime Shi_SaleDate { get; set; }
    }
}
