using BLL;
using Interface.BLL;
using Interface.DAL;
using Models.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataTable
{
    public class DT_UserService : BllService<DT_User>, IDT_UserService
    { 
        /// <summary>
        /// 用于实例化父级，DBService变量
        /// </summary>
        /// <param name="dal"></param>
        public DT_UserService(IDalService<DT_User> dal) : base(dal)
        {

        }
        
    }
}