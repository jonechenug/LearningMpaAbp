using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.Dependency;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace LearningMpaAbp.Web
{
    internal class ConfigurationExtenion
    {
        internal static IConfigurationRoot AppConfiguration;

        /// <summary>
        /// 获取节点配置
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="config"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        internal static TService GetSectionObject<TService>(IConfigurationRoot config, String sectionName)
        {
            var section = config.GetSection(sectionName);
            if (section == null)
            {
                throw new ArgumentException($" {sectionName} 未绑定，无法获取到配置节点信息！");
            }
            return section.Get<TService>();
        }

        /// <summary>
        /// 注册方法
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="ioc"></param>
        /// <param name="factoryMethod"></param>
        private static void Register<TService>(IIocManager ioc, Func<TService> factoryMethod) where TService : class
        {
            ioc.IocContainer
                .Register(
                    Component.For<TService>()
                        .UsingFactoryMethod(factoryMethod)
                        .LifestyleTransient()
                );
        }

        /// <summary>
        /// 获取配置节点信息
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="ioc"></param>
        /// <param name="config"></param>
        /// <param name="sectionName"></param>
        public static void InitConfigService<TService>(IIocManager ioc, IConfigurationRoot config, String sectionName) where TService : class
        {
            Register(ioc, () =>
            {
                var service = GetSectionObject<TService>(config, sectionName);
                return service;
            });
        }



    }
}