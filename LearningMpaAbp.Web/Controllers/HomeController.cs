using System;
using System.Linq;
using System.Web.Mvc;
using Abp.Dependency;
using Abp.Json;
using Abp.Web.Mvc.Authorization;
using Microsoft.Extensions.Configuration;

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
        public String GetRedisConfig()
        {
            var redisConfig = IocManager.Instance.Resolve<RedisConfiguration>();
            return redisConfig.ToJsonString();
        }
    }
}