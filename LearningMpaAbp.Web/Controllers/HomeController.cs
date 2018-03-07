using System;
using System.Web.Mvc;
using Abp.Dependency;
using Abp.Json;
using Abp.Web.Mvc.Authorization;

namespace LearningMpaAbp.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LearningMpaAbpControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public String GetConfigurationRoot()
        {
            return ConfigurationExtenion.AppConfiguration.ToJsonString();
        }

        [AllowAnonymous]
        public String GetRedisConfig()
        {
            var redisConfig = IocManager.Instance.Resolve<RedisConfiguration>();
            return redisConfig.ToJsonString();
        }
    }
}