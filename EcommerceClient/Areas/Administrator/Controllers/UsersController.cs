using EcommerceClient.Models.Structure;
using EcommerceClient.Models.Views;
using EcommerceClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EcommerceClient.Areas.Administrator.Controllers
{
    public class UsersController : Controller
    {
        IWebApiCoreService webApi;

        public UsersController(IWebApiCoreService webApi)
        {
            this.webApi = webApi;
        }



        // GET: Administrator/Users
        public async Task<ActionResult> Index()
        {
            UsersVModel model = new UsersVModel() {
                    Users = await this.webApi.GetAsync<List<User>>("Users")
            };

            return View(model);
        }



        public async Task<JsonResult> Create(User user)
        {
            try
            {

                    //Enviamos la categoria al webApi para su creación
                    var result = await this.webApi.PostAsync<bool, User>("Users", user, null);

                    return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);

                           


            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ Create" }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Método encargado de la actualización de los datos básicos de una categoria
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<JsonResult> Update(User user)
        {

            try
            {
                //Enviamos la categoria al webApi para su creación
                var result = await this.webApi.PutAsync<bool, User>($"Users/{user.Id}", user, null);

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ Update" }, JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// Cambia el status de la categoria
        /// </summary>
        /// <param name="id"> id primary de la categoria</param>
        /// <returns></returns>
        public async Task<JsonResult> ChangeStatus(int id)
        {
            try
            {
                //Enviamos la categoria al webApi para su creación
                var result = await this.webApi.PutAsync<bool>("Users/ChangeStatus", new { id });

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ ChangeStatus" }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> Delete(int id)
        {

            try
            {
                //Enviamos la categoria al webApi para su eliminación
                var result = await this.webApi.DeleteAsync("Users", id);

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ Delete" }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}