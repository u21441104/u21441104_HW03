using u21441104_HW03.Models;


using System.Collections.Generic;

using System.IO; 
using System.Web.Mvc;

namespace u21441104_HW03.Controllers
{
    public class FileController : Controller 
    {
        // GET: Home
        public ActionResult Index()
        {
            string[] filePathsUploads = Directory.GetFiles(Server.MapPath("~/App_Data/uploads/"));
            string[] filePathsImages = Directory.GetFiles(Server.MapPath("~/App_Data/images/"));
            string[] filePathsDocs= Directory.GetFiles(Server.MapPath("~/App_Data/docs/"));
            string[] filePathsVideos= Directory.GetFiles(Server.MapPath("~/App_Data/videos/"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePathUpload in filePathsUploads)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePathUpload) });
            }

            foreach (string filePathImage in filePathsImages)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePathImage) });
            }

            foreach (string filePathDoc in filePathsDocs)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePathDoc) });
            }

            foreach (string filePathVideo in filePathsVideos)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePathVideo) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {

            string pathUploads = Server.MapPath("~/App_Data/uploads/") + fileName;
            string pathImages = Server.MapPath("~/App_Data/images/") + fileName;
            string pathVideos = Server.MapPath("~/App_Data/videos/") + fileName;
            string pathDocs = Server.MapPath("~/App_Data/docs/") + fileName;

            try { byte[] bytesUploads = System.IO.File.ReadAllBytes(pathUploads); return File(bytesUploads, "application/octet-stream", fileName); } catch (FileNotFoundException a) { }
            try { byte[] bytesImages = System.IO.File.ReadAllBytes(pathImages); return File(bytesImages, "application/octet-stream", fileName); } catch (FileNotFoundException b) { }
            try { byte[] bytesVideos = System.IO.File.ReadAllBytes(pathVideos); return File(bytesVideos, "application/octet-stream", fileName); } catch (FileNotFoundException c) { }
            try { byte[] bytesDocs = System.IO.File.ReadAllBytes(pathDocs); return File(bytesDocs, "application/octet-stream", fileName); } catch (FileNotFoundException d) { }

            return null;
        }

        public ActionResult DeleteFile(string fileName)
        {

            string pathUploads = Server.MapPath("~/App_Data/uploads/") + fileName;
            string pathImages = Server.MapPath("~/App_Data/images/") + fileName;
            string pathVideos = Server.MapPath("~/App_Data/videos/") + fileName;
            string pathDocs = Server.MapPath("~/App_Data/docs/") + fileName;

            try { byte[] bytesUploads = System.IO.File.ReadAllBytes(pathUploads); } catch (FileNotFoundException a) { }
            try { byte[] bytesImages = System.IO.File.ReadAllBytes(pathImages); } catch (FileNotFoundException b) { }
            try { byte[] bytesVideos = System.IO.File.ReadAllBytes(pathVideos); } catch (FileNotFoundException c) { }
            try { byte[] bytesDocs = System.IO.File.ReadAllBytes(pathDocs); } catch (FileNotFoundException d) { }

            System.IO.File.Delete(pathUploads);
            System.IO.File.Delete(pathImages);
            System.IO.File.Delete(pathVideos);
            System.IO.File.Delete(pathDocs);

            return RedirectToAction("Index");
        }
    }
}