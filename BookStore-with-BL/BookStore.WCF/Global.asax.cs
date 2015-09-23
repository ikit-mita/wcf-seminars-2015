using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web;
using Microsoft.Mef.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;

namespace BookStore.WCF
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var assembly = new AssemblyCatalog(typeof(Global).Assembly);
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(assembly);
            catalog.Catalogs.Add(new DirectoryCatalog("bin"));
            var container = new CompositionContainer(catalog);
            var mefServiceLocator = new MefServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => mefServiceLocator);
            container.ComposeExportedValue<IServiceLocator>(mefServiceLocator);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}