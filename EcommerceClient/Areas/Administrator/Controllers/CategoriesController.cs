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
            var categories = await this.webApi.GetAsync<List<Category>>("categories");

            //Instanciamos el viewModel
            this.viewModel = new CategoriesVModel()
            {
                Categories = categories
            };

            return View(this.viewModel);
        }

        public async Task<JsonResult> Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    category.CreationUser = 1;

                    //Enviamos la categoria al webApi para su creación
                    var result = await this.webApi.PostAsync<bool, Category>("Categories", category, null);

                    return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);

                }
                else {
                    return Json(new { control = false, data = "Datos inválidos" }, JsonRequestBehavior.AllowGet);

                }

                
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
        public async Task<JsonResult> Update(Category category)
        {

            try
            {
                //Enviamos la categoria al webApi para su creación
                var result = await this.webApi.PutAsync<bool, Category>($"Categories/{category.Id}", category, null);

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

        /// <summary>
        /// Método para obtener las subcategorias que dependen de un id de una categoria
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetSubCategoriesByCategory(int idCategoria) {
            try
            {
                //Obtenemos las subcategorias
                var subcategories = await this.webApi.GetAsync<List<SubCategory>>("SubCategories/GetFromCategory", new { idCategoria });

                return Json(new { control = true, data = subcategories }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ GetSubCategoriesByCategory" }, JsonRequestBehavior.AllowGet);
            }

        }

        #region SubCategorias

        /// <summary>
        /// Vista admin de las subcategorias
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> SubCategories()
        {
            var subModel = new SubCategoriesVModel()
            {
                //Obtenemos solo las categorias activas
                Categories = await this.webApi.GetAsync<List<Category>>("categories"),
                SubCategories = await this.webApi.GetAsync<List<SubCategory>>("SubCategories")

            };

            return View(subModel);
        }


        public async Task<JsonResult> AddSubCategory(SubCategory subCategory)
        {

            try
            {
                //Agregamos los datos básicos
                subCategory.CreationUser = 1;

                //Enviamos la categoria al webApi para su creación
                var result = await this.webApi.PostAsync<bool, SubCategory>("SubCategories", subCategory, null);

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { control = false, data = "Error 500 | AddSubCategory" }, JsonRequestBehavior.AllowGet);
            }

        }

        public async Task<JsonResult> UpdateSubCategory(SubCategory subCategory)
        {

            try
            {
                //Enviamos la categoria al webApi para su creación
                var result = await this.webApi.PutAsync<bool, SubCategory>($"SubCategories/{subCategory.Id}", subCategory, null);


                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { control = false, data = "Error 500 | UpdateSubCategory" }, JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// Cambia el status de la categoria
        /// </summary>
        /// <param name="id"> id primary de la categoria</param>
        /// <returns></returns>
        public async Task<JsonResult> ChangeStatusSubCategory(int id)
        {
            try
            {
                //Enviamos la categoria al webApi para su creación
                var result = await this.webApi.PutAsync<bool>("SubCategories/ChangeStatus", new { id });

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 | ChangeStatusSubCategory" }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> DeleteSubCategory(int id)
        {

            try
            {
                //Enviamos la categoria al webApi para su eliminación
                var result = await this.webApi.DeleteAsync("SubCategories", id);

                return Json(new { control = result, data = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 | DeleteAsync" }, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion
    }
}