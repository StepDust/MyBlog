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
using Common;

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

            _UserService.AddEntity(new DT_User() { UserName = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), Password = "" + (new Random()).Next(100) }, true);

            ViewBag.list = _UserService.LoadEntites(c => true).ToList();

            return View();

        }


        public IActionResult EncryptAction(string str, string key, string iv)
        {

            res res = new res();

            res.str = str;
            res.key = key;

            str = EncryptHelper.Encrypt(str, key);

            res.kstr = str;

            str = EncryptHelper.Decrypt(str, key);

            res.text = str;

            return Json(res);

        }

        public class res
        {
            public string str { get; set; }
            public string key { get; set; }
            public string kstr { get; set; }
            public string text { get; set; }
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
