using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Microsoft.EntityFrameworkCore;
using Common;
using System.IO;
using BLL;

namespace WebFront
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .Build();

            Config.SetConfig(config);
        }

        /// <summary>
        /// 运行时调用此方法。使用此方法向容器添加服务。
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            // 数据库连接字符串
            var conStr = Config.GetVal<string>(ConfigKey.ConStr);
            services.AddDbContext<DBCodeFirst>(options => options.UseSqlServer(conStr));

            DIBllRegister bllRegister = new DIBllRegister();
            bllRegister.DIRegister(services);
            
            services.AddMvc();
        }

        /// <summary>
        /// 运行时调用此方法。使用此方法配置HTTP请求管道。
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DBCodeFirst dB)
        {

            // new DbInitializer().InitializeAsync(dB);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
