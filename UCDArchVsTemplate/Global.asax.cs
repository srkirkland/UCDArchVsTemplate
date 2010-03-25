using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using MvcContrib.Castle;
using UCDArch.Web.IoC;
using UCDArch.Web.ModelBinder;
using UCDArch.Web.Validator;
using UCDArchVsTemplate.Controllers;

namespace UCDArchVsTemplate
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            #if DEBUG
            HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();
            #endif

            xVal.ActiveRuleProviders.Providers.Add(new ValidatorRulesProvider());

            ModelBinders.Binders.DefaultBinder = new UCDArchModelBinder();

            InitializeServiceLocator();

            RouteRegistrar.RegisterRoutesTo(RouteTable.Routes);

            AreaRegistration.RegisterAllAreas();
        }

        private static void InitializeServiceLocator()
        {
            IWindsorContainer container = new WindsorContainer();
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));

            container.RegisterControllers(typeof(HomeController).Assembly);
            ComponentRegistrar.AddComponentsTo(container);

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));

            return;
        }
    }
}