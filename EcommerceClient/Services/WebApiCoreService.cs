using EcommerceClient.Models.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EcommerceClient.Services
{
    public class WebApiCoreService : IWebApiCoreService
    {

        private  HttpClient client;

        public WebApiCoreService(HttpClient http)
        {
            this.client = http;
        }

        public ActionResult GetAsync()
        {
           

            using (this.client)
            {
                client.BaseAddress = new Uri("https://localhost:44356/api/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("Cities");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Cities>>();
                    readTask.Wait();

                    var members = readTask.Result;

                    var x = 2;

                }
                else
                {
                    
                }
            }
            return null;
        }
    
    }
}