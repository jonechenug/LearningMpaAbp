using System;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using Microsoft.Extensions.Configuration;

namespace LearningMpaAbp.Web
{
    public class MvcApplication : AbpWebApplication<LearningMpaAbpWebModule>
    {
        public MvcApplication()
        {
            ConfigurationExtenion.AppConfiguration = new ConfigurationBuilder()
                .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true)
                .Build();
        }

        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig("log4net.config")
            );

            base.Application_Start(sender, e);
        }
    }
}
