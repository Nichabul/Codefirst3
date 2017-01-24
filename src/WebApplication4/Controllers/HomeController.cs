using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private WebdemoContext DB = new WebdemoContext();
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";
            var GetPro = DB.Profile.ToList();
            return View("About",GetPro);
        }
        public IActionResult Getdata()
        {
            var GetPro = DB.Profile.ToList();
            return PartialView("Lists", GetPro);
        }

        public IActionResult Formadd()
        {
            return View("Formadd");
        }
        [HttpPost]
        public IActionResult Add (Profile Model)
        {
            string msg = "";
            try
            {
                DB.Profile.Add(Model);
                DB.SaveChanges();
                msg = "บันทึกสำเร็จ";
            }
            catch (Exception e)
            {
                return Json(new { msg = e.Message });
            }
            return View("About");
        }

        public IActionResult Formedit(int ProfileId)
        {
            var GetProfile = DB.Profile.Where(a => a.ProfileId == ProfileId).Single();
            return View("Formedit", GetProfile);
        }
        [HttpPost]
        public IActionResult Edit(Profile Model)
        {
            String Msg = "";
            try
            {
                DB.Profile.Attach(Model);
                DB.Profile.Update(Model);
                DB.SaveChanges();
                Msg = "Sucess";
            }
            catch (Exception e)
            {
                return Json(new { msg = e.Message });
            }
            return View("About");
        }

        public IActionResult Delete (int ProfileId)
        {
            String Msg = "";
            try
            {
                var Model = DB.Profile.Where(a => a.ProfileId == ProfileId).Single();
                DB.Profile.Remove(Model);
                DB.SaveChanges();
                Msg = "Sucess";
            }
            catch (Exception e)
            {
                return Json(new { msg = e.Message });
            }
            return View("About");

        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }


    }
}
