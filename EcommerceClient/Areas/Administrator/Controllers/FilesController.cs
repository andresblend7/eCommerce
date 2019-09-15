using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceClient.Areas.Administrator.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public JsonResult SaveImageProduct()
        {
            try
            {
                HttpPostedFileBase file = Request.Files[0];

                var fileContent = Request.Files[0];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    var stream = fileContent.InputStream;
                    var fileName = fileContent.FileName;

                    var nameFormat = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}_{fileName}";

                    string path = Path.Combine(Server.MapPath("~/Uploads"), nameFormat);


                    file.SaveAs(path);

                    return Json(new { control = true, data = nameFormat }, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    throw new Exception("No hay imágen");

                }
            }
            catch (Exception ex)
            {

                return Json(new { control = false, data = $"Error 500 _ Create {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}