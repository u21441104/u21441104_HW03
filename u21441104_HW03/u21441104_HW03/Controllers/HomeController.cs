using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21441104_HW03.Models;

namespace u21441104_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string rbSelection)
        {
            if (files != null && files.ContentLength > 0)
            {
                var fileName = Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);

                if (rbSelection == "img")
                {
                    path = Path.Combine(Server.MapPath("~/App_Data/images"), fileName);   
                }
                else if (rbSelection == "vid")
                {
                    path = Path.Combine(Server.MapPath("~/App_Data/videos"), fileName);
                }
                else if (rbSelection == "doc")
                {
                    path = Path.Combine(Server.MapPath("~/App_Data/docs"), fileName);
                }

                files.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}