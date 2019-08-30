using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EcommerceClient.Services
{
    public interface IWebApiCoreService
    {
        /// <summary>
        /// Método para invocar las peticiones get
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        Task<TResult> GetAsync<TResult, TModel>(string actionName, NameValueCollection parameters= null) where TResult : class;  
        Task<TResult> GetAsync<TResult>(string actionName, object parameters = null) where TResult : class;
        Task<TResult> PostASync<TResult>(string actionName, object parameters = null) where TResult : class;

    }
}
