using EcommerceClient.Models.Structure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EcommerceClient.Services
{
    public class WebApiCoreService : IWebApiCoreService
    {

        private HttpClient client;

        private Task<HttpResponseMessage> request;

        public const string BASEURI = "https://localhost:44356/api/";

        public WebApiCoreService(HttpClient http)
        {
            this.client = http;
            if (this.client.BaseAddress == null)
                this.client.BaseAddress = new Uri(BASEURI);
        }

        public async Task<TResult> GetAsync<TResult>(string actionName, object parameters = null) where TResult : class
        {

            try
            {
                //Construimos la url con la uri y los queryString
                string url = this.BuildUrl(actionName, parameters);

                //Creamos la Url
                this.request = this.client.GetAsync(url);

                //Await del response
                this.request.Wait();

                //Obtenemos el resultado del procesamiento
                var process = this.request.Result;

                //Si la solicitud fue correcta procesamos la información
                if (process.IsSuccessStatusCode)
                {
                    //Leemos la respuesta y la convertimos al tipo de datos solicitados
                    var readTask = await process.Content.ReadAsAsync<TResult>();

                    //Retornamos la respuesta del webApi
                    return readTask;

                }
                else
                {
                    throw new Exception($"Solicitud inválida: {process.RequestMessage.ToString()}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<TResult> PostASync<TResult>(string actionName, object parameters = null) where TResult : class
        {
            try
            {
                //Construimos la url con la uri y los queryString
                string url = this.BuildUrl(actionName, parameters);

                //Creamos la Url
                this.request = this.client.PostAsync(url, null);

                //Await del response
                this.request.Wait();

                //Obtenemos el resultado del procesamiento
                var process = this.request.Result;

                //Si la solicitud fue correcta procesamos la información
                if (process.IsSuccessStatusCode)
                {
                    //Leemos la respuesta y la convertimos al tipo de datos solicitados
                    var readTask = await process.Content.ReadAsAsync<TResult>();

                    //Retornamos la respuesta del webApi
                    return readTask;

                }
                else
                {
                    if (process.StatusCode == System.Net.HttpStatusCode.NotFound)
                         return null;
                    

                    throw new Exception($"Solicitud inválida: {process.RequestMessage.ToString()}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método encargado de construir la url con la queryString
        /// </summary>
        /// <param name="action"></param>
        /// <param name="params"></param>
        /// <returns></returns>
        public string BuildUrl(string action, object @params)
        {

            string url = "";

            //Si la solicitud trae parámetros querystrings, construimos la url
            if (@params != null)
            {
                Type type = @params.GetType();


                IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());

                url = "?";

                foreach (PropertyInfo prop in props)
                {
                    //Nombre del parámetro
                    var name = prop.Name.ToString();

                    var value = prop.GetValue(@params, null).ToString();

                    url += $"{name}={value}&";
                    
                }
                //Concatenamos las propiedades como queryString
               // url = "?" + string.Join("&", url.GetType().GetProperties().Select(x => $"{x.Name}={x.GetValue(url, null)}").ToArray());

            }

            return $"{action}{url}";

        }
        public Task<TResult> GetAsync<TResult, TModel>(string actionName, NameValueCollection parameters = null) where TResult : class
        {
            throw new NotImplementedException();
        }


    }
}