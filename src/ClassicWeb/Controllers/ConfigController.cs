using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassicWeb.Controllers
{
    public class ConfigController : Controller
    {
        // GET: Config
        public ActionResult Index()
        {
            return new ContentResult() {Content = ConfigurationManager.AppSettings["MyConfigEntry"]};
        }



    }
}