using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;

namespace Common
{
    /// <summary>
    /// 配置类
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 所有的配置数据
        /// </summary>
        private static IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// 获得数据
        /// </summary>
        /// <param name="_Configuration"></param>
        public static void SetConfig(IConfigurationRoot _Configuration)
        {
            Configuration = _Configuration;
        }

        /// <summary>
        /// 返回对应键的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键</param>
        /// <param name="def">默认值</param>
        /// <returns></returns>
        public static T GetObject<T>(string key, T def = default(T)) where T : class, new()
        {
            try
            {
                // 实体配置
                var config = new ServiceCollection().AddOptions()
                            .Configure<T>(Configuration.GetSection(key))
                            .BuildServiceProvider();

                def = config.GetService<IOptions<T>>().Value;

            }
            catch (Exception e)
            {

            }
            return def;
        }

        /// <summary>
        /// 返回对应键的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">键</param>
        /// <param name="def">默认值</param>
        /// <returns></returns>
        public static T GetVal<T>(ConfigKey key, T def = default(T))
        {
            try
            {
                def = (T)Convert.ChangeType(Configuration.GetSection(key.ToString()).Value, typeof(T));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return def;
        }

    }

    /// <summary>
    /// 配置键
    /// </summary>
    public enum ConfigKey
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        ConStr
    }

}
