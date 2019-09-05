using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceClient.Helpers.Html
{
    public static class HtmlHelperExtension
    {
        /// <summary>
        /// Método encargado de converitr  un objeto a Json
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IHtmlString ToJson(this HtmlHelper helper, Object obj)
        {
            var serializerSettings = new JsonSerializerSettings();

            //Creamos el contrato para resolver como CamelCase
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


            //Convertimos el modelo en un string
            var json = JsonConvert.SerializeObject(obj, serializerSettings);

            //Remplazamos los caracteres que dañan el json https://www.json.org/
            var fix = json.Replace("\\", "\\\\")
                          .Replace("\\t", "     ")
                          .Replace("\\f", "")
                          .Replace("\\b", "")
                          .Replace("\\f", "")
                          .Replace("\\r", "<br>")
                          .Replace("\\n", "<br>")
                          .Replace("\\r\\n", "<br>")
                          .Replace("`", "");

            //Retornamos la cadena con la correción
            return helper.Raw(fix);
        }

    }
}