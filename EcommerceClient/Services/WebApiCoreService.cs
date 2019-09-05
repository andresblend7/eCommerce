using EcommerceClient.Models.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
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

        /// <summary>
        /// Petición Asíncrona Get con parámetros queryString
        /// </summary>
        /// <typeparam name="TResult"> Tipo de resultado</typeparam>
        /// <param name="actionName">Nombre del controlador [/CustomMethod]</param>
        /// <param name="parameters">Parámetros queryString</param>
        /// <returns></returns>
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


                    throw new Exception($"Solicitud inválida: {process.ReasonPhrase.ToString()}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Petición Asíncrona Post con parámetros query string
        /// </summary>
        /// <typeparam name="TResult"> Tipo de resultado</typeparam>
        /// <param name="actionName">Nombre del controlador [/CustomMethod]</param>
        /// <param name="parameters">Parámetros queryString</param>
        /// <returns></returns>
        public async Task<TResult> PostAsync<TResult>(string actionName, object parameters = null)
        {
            try
            {
                //Construimos la url con la uri y los queryString
                string url = this.BuildUrl(actionName, parameters);

                //Creamos la petición
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
                    //Retornamos 'null' si no existe el recurso
                    if (process.StatusCode == System.Net.HttpStatusCode.NotFound)
                        return default;


                    throw new Exception($"Solicitud inválida: {process.ReasonPhrase.ToString()}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Petición Asíncrona Post con Entidad de clase y parámetros query string 
        /// </summary>
        /// <typeparam name="TResult"> Tipo de resultado</typeparam>
        /// <param name="actionName">Nombre del controlador [/CustomMethod]</param>
        /// <param name="parameters">Parámetros queryString</param>
        /// <returns></returns>
        public async Task<TResult> PostAsync<TResult, TModel>(string actionName, TModel entity, object parameters = null) where TModel : class
        {
            try
            {
                //Construimos la url con la uri y los queryString
                string url = this.BuildUrl(actionName, parameters);

                //Serializamos la entidad
                StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                //Creamos la Url  y agregamos la entidad serializada
                this.request = this.client.PostAsync(url, content);

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
                    throw new Exception($"Solicitud inválida: {process.ReasonPhrase.ToString()}");
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
        /// <param name="action">Nombre del controlador / methodo</param>
        /// <param name="params">parámetros querystring</param>
        /// <returns></returns>
        public string BuildUrl(string action, object @params)
        {

            string url = "";

            //Si la solicitud trae parámetros querystrings, construimos la url
            if (@params != null)
            {
                Type type = @params.GetType();

                //Obtenemos la lista de propiedades del objeto
                IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());

                url = "?";

                foreach (PropertyInfo prop in props)
                {
                    //Nombre del parámetro
                    var name = prop.Name.ToString();

                    //Valor del parámetro
                    var value = prop.GetValue(@params, null).ToString();

                    //Construcción de la url con los parámetros querystring
                    url += $"{name}={value}&";

                }

            }

            return $"{action}{url}";

        }

        public Task<TResult> GetAsync<TResult, TModel>(string actionName, NameValueCollection parameters = null) where TResult : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// PEtición Asíncrona Put que permite enviar parámetros querystring
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="actionName"></param>
        /// <param name="entity"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<TResult> PutAsync<TResult>(string actionName, object parameters = null)
        {

            try
            {
                //Construimos la url con la uri y los queryString
                string url = this.BuildUrl(actionName, parameters);

                this.request = this.client.PutAsync(url, null);

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
                    //Retornamos 'null' si no existe el recurso
                    if (process.StatusCode == System.Net.HttpStatusCode.NotFound)
                        return default;


                    throw new Exception($"Solicitud inválida: {process.ReasonPhrase.ToString()}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// PEtición Asíncrona Put que permite enviar entidades y querystrings
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="actionName"></param>
        /// <param name="entity"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<TResult> PutAsync<TResult, TModel>(string actionName, TModel entity, object parameters = null)
        {
            try
            {
                //Construimos la url con la uri y los queryString
                string url = this.BuildUrl(actionName, parameters);

                //Serializamos la entidad
                StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                //Creamos la Url  y agregamos la entidad serializada
                this.request = this.client.PutAsync(url, content);

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
                    throw new Exception($"Solicitud inválida: {process.ReasonPhrase.ToString()}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// Petición Asíncrona Delete que permite enviar entidades y querystrings
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="actionName"></param>
        /// <param name="entity"></param>
        /// <param name="parameters"></param>
        /// <returns>Boolean</returns>
        
        public async Task<bool> DeleteAsync(string actionName, int id)
        {
            try
            {
              
                //Creamos la Url  y agregamos el id
                this.request = this.client.DeleteAsync($"{actionName}/{id}");

                //Await del response
                this.request.Wait();

                //Obtenemos el resultado del procesamiento
                var process = this.request.Result;

                //Si la solicitud fue correcta procesamos la información
                if (process.IsSuccessStatusCode)
                {
                    //Leemos la respuesta y la convertimos al tipo de datos solicitados
                    var readTask = await process.Content.ReadAsAsync<bool>();

                    //Retornamos la respuesta del webApi
                    return readTask;

                }
                else
                    return false;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}