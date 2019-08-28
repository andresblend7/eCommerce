using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EcommerceClient.Services
{
    public interface IWebApiCoreService
    {
        ActionResult GetAsync();   
    }
}
