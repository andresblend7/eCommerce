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

        private  HttpClient client;

        private Task<HttpResponseMessage> request;

        public const string BASEURI = "https://localhost:44356/api/";

        public WebApiCoreService(HttpClient http)
        {
            this.client = http;
            if(this.client.BaseAddress == null)
                this.client.BaseAddress = new Uri(BASEURI);
        }
        public async Task<TResult> GetAsync<TResult, TModel>(string actionName, NameValueCollection parameters=null ) where TResult : class
        {
            //Si la solicitud trae parámetros querystrings, construimos la url
            if (parameters != null)
                this.request =  this.client.GetAsync($"{actionName}{this.ToQueryString(parameters)}");
            else
                this.request =  this.client.GetAsync(actionName);

            //Await del response
            this.request.Wait();

            var result =  this.request.Result;

            if (result.IsSuccessStatusCode)
            {
                try
                {
                    //Leemos la respuesta y la convertimos al tipo de datos solicitados
                    var readTask = await result.Content.ReadAsAsync<TResult>();

                    //Retornamos la respuesta del webApi
                    return readTask;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            else {
                 throw new Exception("Petición inválida");
            }
            
        }

        private string ToQueryString(NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                         from value in nvc.GetValues(key)
                         select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
                .ToArray();
            return "?" + string.Join("&", array);
        }

        public async  Task<TResult> GetAsync<TResult>(string actionName, NameValueCollection parameters = null) where TResult : class
        {
            //Si la solicitud trae parámetros querystrings, construimos la url
            if (parameters != null)
                this.request = this.client.GetAsync($"{actionName}{this.ToQueryString(parameters)}");
            else
                this.request = this.client.GetAsync(actionName);

            //Await del response
            this.request.Wait();

            var result = this.request.Result;

            if (result.IsSuccessStatusCode)
            {
                try
                {
                    //Leemos la respuesta y la convertimos al tipo de datos solicitados
                    var readTask = await result.Content.ReadAsAsync<TResult>();

                    //Retornamos la respuesta del webApi
                    return readTask;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            else
            {
                throw new Exception("Petición inválida");
            }

        }
    }
}