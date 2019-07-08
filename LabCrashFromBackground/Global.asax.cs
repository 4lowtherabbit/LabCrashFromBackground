using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LabCrashFromBackground
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Thread t = new Thread(WaitForCrash);
            t.Start();
        }

        public static bool CrashIt = false;

        static void WaitForCrash()
        {
            while(true)
            {
                Thread.Sleep(10000);
                if(CrashIt)
                    throw new ApplicationException("Crashing...");
            }
        }
    }
}
