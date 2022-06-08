using u21441104_HW03.Models; 



using System.Collections.Generic; 

using System.IO; 
using System.Web.Mvc;

namespace u21441104_HW03.Controllers
{
    public class VideoController : Controller 
    {
        // GET: Home
        public ActionResult Index()
        {
            string[] filePathsVideos = Directory.GetFiles(Server.MapPath("~/App_Data/videos/"));

            List<FileModel> files = new List<FileModel>();


            foreach (string filePathVideo in filePathsVideos)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePathVideo) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            string pathVideos = Server.MapPath("~/App_Data/videos/") + fileName;

          
            try { byte[] bytesVideos = System.IO.File.ReadAllBytes(pathVideos); return File(bytesVideos, "application/octet-stream", fileName); } catch (FileNotFoundException c) { }

            return null;
        }

        public ActionResult DeleteFile(string fileName)
        {

            string pathVideos = Server.MapPath("~/App_Data/videos/") + fileName;

            try { byte[] bytesVideos = System.IO.File.ReadAllBytes(pathVideos); } catch (FileNotFoundException c) { }

            System.IO.File.Delete(pathVideos);

            return RedirectToAction("Index");
        }
    }
}