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
    public class CategoriesController : Controller
    {
        CategoriesVModel viewModel;
        IWebApiCoreService webApi;

        public CategoriesController(IWebApiCoreService webApi)
        {
            this.webApi = webApi;
        }

        // GET: Administrator/Categories
        public async Task<ActionResult> Index()
        {
            //Obtenemos las categorias existentes.
            var categories = await this.webApi.GetAsync<List<Categories>>("categories");

            //Instanciamos el viewModel
            this.viewModel = new CategoriesVModel()
            {
                Categories = categories
            };

            return View(this.viewModel);
        }

        public async Task<JsonResult> Create(Categories category)
        {
            try
            {
                category.CreationUser = 1;

                //Enviamos la categoria al webApi para su creación
                var result = await this.webApi.PostASync<bool, Categories>("Categories", category, null);

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
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<JsonResult> Update(Categories category)
        {

            try
            {
                //Enviamos la categoria al webApi para su creación
                var result = await this.webApi.PutAsync<bool, Categories>($"Categories/{category.Id}", category, null);

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
                var result = await this.webApi.PutAsync<bool>("Categories/ChangeStatus", new { id });

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
                var result = await this.webApi.DeleteAsync("Categories", id);

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ Delete" }, JsonRequestBehavior.AllowGet);
            }

        }

        #region SubCategorias

        /// <summary>
        /// Vista admin de las subcategorias
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> SubCategories()
        {
            var subModel = new SubCategoriesVModel() {
                //Obtenemos solo las categorias activas
                Categories = await this.webApi.GetAsync<List<Categories>>("categories", new { state = true}),
                SubCategories = 
                
            };

            return View();
        }

        #endregion
    }
}