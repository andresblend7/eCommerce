﻿using System;
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


        /// <summary>
        /// Petición Asíncrona Get con parámetros queryString
        /// </summary>
        /// <typeparam name="TResult"> Tipo de resultado</typeparam>
        /// <param name="actionName">Nombre del controlador [/CustomMethod]</param>
        /// <param name="parameters">Parámetros queryString</param>
        /// <returns></returns>
        Task<TResult> GetAsync<TResult>(string actionName, object parameters = null) where TResult : class;

        /// <summary>
        /// Petición Asíncrona Post con parámetros query string
        /// </summary>
        /// <typeparam name="TResult"> Tipo de resultado</typeparam>
        /// <param name="actionName">Nombre del controlador [/CustomMethod]</param>
        /// <param name="parameters">Parámetros queryString</param>
        /// <returns></returns>
        Task<TResult> PostAsync<TResult>(string actionName, object parameters = null);


        /// <summary>
        /// PEtición Asíncrona Put que permite enviar parámetros querystring
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="actionName"></param>
        /// <param name="entity"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<TResult> PutAsync<TResult>(string actionName, object parameters = null);

        /// <summary>
        /// PEtición Asíncrona Put que permite enviar entidades y querystrings
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="actionName"></param>
        /// <param name="entity"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<TResult> PutAsync<TResult, TModel>(string actionName, TModel entity, object parameters = null);

        /// <summary>
        /// Petición Asíncrona Post con Entidad de clase y parámetros query string 
        /// </summary>
        /// <typeparam name="TResult"> Tipo de resultado</typeparam>
        /// <param name="actionName">Nombre del controlador [/CustomMethod]</param>
        /// <param name="parameters">Parámetros queryString</param>
        /// <returns></returns>
        Task<TResult> PostAsync<TResult, TModel>(string actionName, TModel entity, object parameters = null) where TModel : class;


        /// <summary>
        /// Petición Asíncrona Delete que permite enviar entidades y querystrings
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteAsync(string actionName, int id);

    }
}
