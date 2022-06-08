using u21441104_HW03.Models;


using System.Collections.Generic; 

using System.IO; 
using System.Web.Mvc;

namespace u21441104_HW03.Controllers
{
    public class ImageController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string[] filePathsImages = Directory.GetFiles(Server.MapPath("~/App_Data/images/"));

            List<FileModel> files = new List<FileModel>();


            foreach (string filePathImage in filePathsImages)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePathImage) });
            }

            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {

            string pathImages = Server.MapPath("~/App_Data/images/") + fileName;

            try { byte[] bytesImages = System.IO.File.ReadAllBytes(pathImages); return File(bytesImages, "application/octet-stream", fileName); } catch (FileNotFoundException b) { }

            return null;
        }

        public ActionResult DeleteFile(string fileName)
        {

            string pathImages = Server.MapPath("~/App_Data/images/") + fileName;

            try { byte[] bytesImages = System.IO.File.ReadAllBytes(pathImages); } catch (FileNotFoundException b) { }

            System.IO.File.Delete(pathImages);

            return RedirectToAction("Index");
        }
    }
}