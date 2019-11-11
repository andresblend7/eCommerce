using EcommerceClient.Models.Structure;
using EcommerceClient.Models.Views;
using EcommerceClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EcommerceClient.Controllers
{
    public class HomeController : Controller
    {

        IWebApiCoreService webApi;

        public HomeController(IWebApiCoreService webApi)
        {
            this.webApi = webApi;
        }

        public async Task<ActionResult> Index(int? idCategoria, int? idSubCategoria, bool? estado, int? ciudad)
        {
            //Lista de ciudades
            var cities = await this.webApi.GetAsync<List<City>>("Cities", null);
           
            //Categorias para el menu
            var categories = await this.webApi.GetAsync<List<Category>>("Categories/GetWithSubCategories", null);

            var products = new List<Product>();

            if (idSubCategoria != null)
            {
                products = await this.webApi.GetAsync<List<Product>>("Products/GetBySubCat", new { idSubCategoria });

            }
            else {
                //Productos de la primer categoria
                products = await this.webApi.GetAsync<List<Product>>("Products/GetByCategoryAsync", new { idCategory = categories.FirstOrDefault().Id });

            }

            if (estado != null) {

                products = products.Where(x => x.Condition == estado).ToList();

            }


            var model = new HomeVModel() {
                Cities = cities,
                Categories = categories,
                Products = products
            };
            
            //Petición por id
            //var cityTest = await this.webApi.GetAsync<Cities>("Cities/5");
            
            return View(model);
        }


        public async Task<ActionResult> ProductInfo(string product) {

            //Obtenemos el producto
            var productResult = await this.webApi.GetAsync<Product>("Products/GetById", new { reff = product });

            var modelv = new ProductInfoVModel() { 
                Product = productResult
            };

            return View(modelv);
        }

        public async Task<JsonResult> Login(string email, string pass) {

            try
            {
                //Enviamos las credenciales para la autenticación
                var authUser = await this.webApi.PostAsync<User>("users/Auth", new { email = email, hashedpass = pass });

                //Si trae Id Creamos la session
                if (authUser.Id != 0) {

                    Session["LoggedIn"] = true;
                    Session["user"] = authUser.Id;
                    Session["rol"] = authUser.Rol;
                    Session["firstName"] = authUser.FirstName;
                    Session["lastName"] = authUser.LastName;
                    Session["money"] = authUser.Money;
                }

                return Json(new { control = (authUser.Id != 0), data = authUser }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { control = false, data = "Error 500 _ Login" }, JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// Método para obtener los items del carrito de compra de un usuario logeado
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetShopCar() {

            var shopCarList = new List<ShopCar>();
            bool control = false;

            if(Session["user"] != null){
                //Obtenemos los productos en el carrito del usuario logueado
                shopCarList = await this.webApi.GetAsync<List<ShopCar>>("ShopCar/GetByUser", new { idUser = int.Parse(Session["user"].ToString()), allItems = false });

                control = true;
            }

            return Json(new { control , data = shopCarList }, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> AddItemToShopCar(ShopCar data) {

            if (Session["user"] != null)
            {

                data.IdUser = int.Parse(Session["user"].ToString());
                data.DateCreation = DateTime.Now;

                var addItem = await this.webApi.PostAsync<bool, ShopCar>("ShopCar", data, null);

                return Json(new { control = true, data = addItem }, JsonRequestBehavior.AllowGet);
            }
            else {

                return Json(new { control = true, data = false }, JsonRequestBehavior.AllowGet);

            }

        }

        public async Task<JsonResult> RemoveShopCarItem(int id)
        {

            if (Session["user"] != null)
            {              
                var addItem = await this.webApi.DeleteAsync("ShopCar", id);

                return Json(new { control = true, data = addItem }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                return Json(new { control = true, data = false }, JsonRequestBehavior.AllowGet);

            }

        }

        //Método para comprar los items del carrito
        public async Task<JsonResult> BuyShopCar() {

            if (Session["user"] != null)
            {
                var idUser = int.Parse(Session["user"].ToString());

                var resultBuy = await this.webApi.PostAsync<KeyValuePair<bool, string>>("ShopCar/BuyShopCarItems", new { idUser});

                //Actualizamos la cartera del usuario
                var user = await this.webApi.GetAsync<User>($"Users/{idUser}", null);

                Session["money"] = user.Money;

                return Json(new { control = true, data = resultBuy.Key, message = resultBuy.Value }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                return Json(new { control = true, data = false , message = "sessión expirada" }, JsonRequestBehavior.AllowGet);

            }

        }

        public JsonResult LogOut() {

            Session.Clear();
            Session.Abandon();

            return Json(new { control = true, data = "" }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}