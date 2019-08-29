using EcommerceClient.Models.Structure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
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

                string queryString = "";

                //Si la solicitud trae parámetros querystrings, construimos la url
                if (parameters != null)
                {
                    //Concatenamos las propiedades como queryString
                    queryString = "?" + string.Join("&", queryString.GetType().GetProperties().Select(x => $"{x.Name}={x.GetValue(queryString, null)}").ToArray());

                }

                //Creamos la Url
                this.request = this.client.GetAsync($"{actionName}{queryString}");

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
      
        public Task<TResult> GetAsync<TResult, TModel>(string actionName, NameValueCollection parameters = null) where TResult : class
        {
            throw new NotImplementedException();
        }

    }
}