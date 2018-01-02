using BLL;
using Interface.BLL;
using Interface.DAL;
using Models;
using Models.DataTable;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.DataBaseTable
{
    public class DT_UserService : BllService<DT_User>, IDT_UserService
    {
        public DT_UserService(IDalService<DT_User> dal) : base(dal)
        {

        }

        public DT_User Insert()
        {
            DT_User user = new DT_User
            {
                Password = new Random().Next(0, 101) + "",
                UserName = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            return AddEntity(user, true);
        }

        public List<DT_User> GetList()
        {
            return LoadEntites(c => true).ToList();
        }

    }
}