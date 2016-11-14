using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult ShowImages()
        {
            var folderPath = Server.MapPath("../Pictures");
            var imagePaths = Directory.GetFiles(folderPath, "*.*").ToList();

            return View(imagePaths);
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase photo)
        {

            string pictureFolder = Server.MapPath("../Pictures");

            if (photo != null && photo.ContentLength > 0)
            {


                var fileName = Path.GetFileName(photo.FileName);
                var path = Path.Combine(pictureFolder, fileName);
                photo.SaveAs(path);


            }


            return RedirectToAction("ShowImages");

        }
    }
}