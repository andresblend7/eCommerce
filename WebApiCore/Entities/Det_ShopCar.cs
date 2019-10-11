using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Entities
{
    public class Det_ShopCar
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Dic_Users")]
        public int Shc_IdUserFk { get; set; }

        [Required]
        [ForeignKey("Dic_Products")]
        public int Shc_IdProductFk { get; set; }
        /// <summary>
        /// Cantidad de Shc_IdProductFk en el carrito
        /// </summary>
        public int Shc_Quantity { get; set; }
        /// <summary>
        /// 1 = en carrito, 2 = comprado, 3= cancelado
        /// </summary>
        public int Shc_Status { get; set; }
        public DateTime Shc_DateCreation { get; set; }

        [ForeignKey("Shc_IdProductFk")]
        public Dic_Products Product { get; set; }
    }
}
