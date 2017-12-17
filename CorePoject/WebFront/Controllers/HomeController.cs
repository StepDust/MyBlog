using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebFront.Models;
using Models.DataTable;
using Models;

namespace WebFront.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new DBCoreFirst())
            {

                db.DT_User.Add(new DT_User { UserName = "嘿嘿" });
                var count = db.SaveChanges();
                var cc = db.DT_User.ToList();
                return View();
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
