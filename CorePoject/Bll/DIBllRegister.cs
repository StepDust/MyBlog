using DAL;
using DAL.DataTable;
using Interface.BLL;
using Interface.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    /// <summary>
    /// Bll层依赖注入
    /// </summary>
    public class DIBllRegister
    {

        public void DIRegister(IServiceCollection services)
        {
            // 用于实例化DalService对象，获取上下文对象
            services.AddTransient(typeof(IDalService<>), typeof(DalService<>));

            // 配置一个依赖注入映射关系 
            services.AddTransient(typeof(IDT_UserService), typeof(DT_UserService));
        }
    }
}
