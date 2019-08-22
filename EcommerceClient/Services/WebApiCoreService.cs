using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceClient.Services
{
    public class WebApiCoreService : IWebApiCoreService
    {
        public int prueba { get ; set ; }
        public WebApiCoreService(int nm)
        {
            this.prueba = nm;
        }


        public int GetNumero()
        {
            return this.prueba;
        }
    }
}