using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace LabCrashFromBackground.Controllers
{
    public class ReproController : Controller
    {
        // GET: Repro
        public ActionResult Index()
        {
            return View();
        }

        public string Crash()
        {
            HostingEnvironment.QueueBackgroundWorkItem(Action => {
                Thread.Sleep(10000);
                throw new ApplicationException("Crashing...");
            });
            return "Process will crash in 10 seconds";
        }
    }
}