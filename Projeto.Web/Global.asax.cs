using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Diagnostics;
using Projeto.BLL.Contracts;
using Projeto.BLL.Business;
using Projeto.DAL.Contracts;
using Projeto.DAL.Repositories;

[assembly: PreApplicationStartMethod(typeof(Projeto.Web.PageInitializerModule), "Initialize")]
namespace Projeto.Web
{
    public sealed class PageInitializerModule : IHttpModule
    {
        public static void Initialize()
        {
            DynamicModuleUtility.RegisterModule(typeof(PageInitializerModule));
        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += (sender, e) => {
                var handler = context.Context.CurrentHandler;
                if (handler != null)
                {
                    string name = handler.GetType().Assembly.FullName;
                    if (!name.StartsWith("System.Web") &&
                        !name.StartsWith("Microsoft"))
                    {
                        Global.InitializeHandler(handler);
                    }
                }
            };
        }

        void IHttpModule.Dispose() { }
    }


    public class Global : HttpApplication
    {
        private static Container container;

        public static void InitializeHandler(IHttpHandler handler)
        {
            container.GetRegistration(handler.GetType(), true).Registration
                .InitializeInstance(handler);
        }


        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrap();
        }

        private static void Bootstrap()
        {
            // 1. Create a new Simple Injector container.
            var container = new Container();

            // Register a custom PropertySelectionBehavior 
            //to enable property injection.
            container.Options.PropertySelectionBehavior =
                new ImportAttributePropertySelectionBehavior();

            // 2. Configure the container (register)

            //Registrando as interfaces e classes da camada BLL..
            container.Register<IUserBusiness, UserBusiness>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<IBookBusiness, BookBusiness>();
            container.Register<IBookRepository, BookRepository>();

            // Register your Page classes to allow them 
            //to be verified and diagnosed.
            RegisterWebPages(container);

            // 3. Store the container for use by Page classes.
            Global.container = container;

            // 3. Verify the container's configuration.
            container.Verify();
        }

        private static void RegisterWebPages(Container container)
        {
            var pageTypes =
                from assembly in BuildManager.GetReferencedAssemblies()
                    .Cast<Assembly>()
                where !assembly.IsDynamic
                where !assembly.GlobalAssemblyCache
                from type in assembly.GetExportedTypes()
                where type.IsSubclassOf(typeof(Page))
                where !type.IsAbstract && !type.IsGenericType
                select type;

            foreach (Type type in pageTypes)
            {
                var registration = Lifestyle.Transient.CreateRegistration
                        (type, container);
                registration.SuppressDiagnosticWarning(
                    DiagnosticType.DisposableTransientComponent,
                    "ASP.NET creates and disposes page classes for us.");
                container.AddRegistration(type, registration);
            }
        }

        class ImportAttributePropertySelectionBehavior
        : IPropertySelectionBehavior
        {
            public bool SelectProperty
        (Type serviceType, PropertyInfo propertyInfo)
            {
                // Makes use of the System.ComponentModel.Composition assembly
                return typeof(Page).IsAssignableFrom(serviceType) &&
                    propertyInfo.GetCustomAttributes<ImportAttribute>().Any();
            }
        }

    }

}
