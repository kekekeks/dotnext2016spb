using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;


namespace CoreWeb.Controllers
{
    [Route("Config")]
    public class ConfigController : Controller
    {
        private readonly IConfigurationRoot _config;

        public ConfigController(IConfigurationRoot config)
        {
            _config = config;
        }

        [HttpGet("")]
        public object GetConfig() => _config.Get("MySetting", (string) null);
    }
}
