using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebFront.Models;
using Models.DataTable;
using Models;
using Microsoft.EntityFrameworkCore;
using Interface.BLL;

namespace WebFront.Controllers
{
    public class HomeController : Controller
    {
        private IDT_UserService _UserService;

        public HomeController(IDT_UserService _UserService )
        {
            // 依赖注入得到实例
            this._UserService = _UserService;
        }

        public IActionResult Index()
        {

            //_UserService.

            //_UserService.DT_User.Add(new IDT_UserBll { UserName = "嘿嘿" });
            //var count = _UserService.SaveChanges();
            //var cc = _UserService.DT_User.ToList();
            var d= _UserService.Insert();


            ViewBag.list = _UserService.GetList();

            return View();

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
