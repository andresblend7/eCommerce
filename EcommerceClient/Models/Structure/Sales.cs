using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Structure
{
    public class Sales
    {
        public int Id { get; set; }

        /// <summary>
        /// Id del usuario que compró
        /// </summary>
        [Required]
        public int BuyerId { get; set; }

        public User UserBuyer { get; set; }

        /// <summary>
        /// Precio total de la venta
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// Fecha de la venta efectuada
        /// </summary>
        [Required]
        public DateTime SaleDate { get; set; }
    }
}