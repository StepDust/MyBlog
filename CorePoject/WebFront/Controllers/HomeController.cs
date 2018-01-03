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

        public HomeController(IDT_UserService _UserService)
        {
            // 依赖注入得到实例
            this._UserService = _UserService;
        }

        public IActionResult Index()
        {
            var d = _UserService.Insert();

            DT_User user = new DT_User
            {
                Password = "998",
                UserName = "啦啦啦"
            };

            //_UserService.AddEntity(user,true);

            ViewBag.list = _UserService.LoadEntites(c => true);

            return View();

        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
