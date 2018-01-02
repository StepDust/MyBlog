using DAL;
using DAL.DataBaseTable;
using Interface.BLL;
using Interface.DAL;
using Microsoft.Extensions.DependencyInjection;
using Models.DataTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    /// <summary>
    /// Bll层依赖注入
    /// </summary>
    public class DIBllRegister
    {

        public void DIRegister(IServiceCollection services)
        {
            // 用于传递上下文对象
            services.AddTransient(typeof(IDalService<>), typeof(DalService<>));

            // 配置一个依赖注入映射关系 
            services.AddTransient(typeof(IDT_UserService), typeof(DT_UserService));
                        
        }
    }
}
