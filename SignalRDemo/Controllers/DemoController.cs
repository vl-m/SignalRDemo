using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRDemo.Controllers
{
    public class DemoController : Controller
    {
        //**/[Authorize]
        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult MoveShape()
        {
            return View();
        }

        public ActionResult StockTicker()
        {
            return View();
        }

        public ActionResult PerfMon()
        {
            return View();
        }
	}
}