using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceClient.Models.Structure
{
    public class ShopCar
    {
        public int Id { get; set; }

        [Required]
        public int IdUser { get; set; }

        [Required]
        public int IdProduct { get; set; }
        /// <summary>
        /// Cantidad de IdProductFk en el carrito
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 1 = en carrito, 2 = comprado, 3= cancelado
        /// </summary>
        public int IdStatus { get; set; }
        public DateTime DateCreation { get; set; }

    }
}