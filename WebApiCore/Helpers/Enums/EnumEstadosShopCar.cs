using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Helpers.Enums
{
    public enum EnumEstadosShopCar
    {
        /// 1 = en carrito, 2 = comprado, 3= cancelado
        Pending = 1,
        Buyed,
        Canceled
    }
}
