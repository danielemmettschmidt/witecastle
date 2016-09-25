using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using dev_sbpcoveragetoolService.DataObjects;
using dev_sbpcoveragetoolService.Models;
using dev_sbpcoveragetoolService.SignalR;
using Microsoft.AspNet.SignalR;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace dev_sbpcoveragetoolService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            var config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            //Database.SetInitializer(new dev_sbpcoveragetoolInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<dev_sbpcoveragetoolContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }

            // Automatic Code First Migrations
            var migrator = new DbMigrator(new Migrations.Configuration());
            migrator.Update();

            app.MapSignalR();

            // Simple Injector
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.RegisterSingleton<ISignalRClientService>(() => new SignalRClientService(GlobalHost.ConnectionManager.GetHubContext<SctHub>().Clients));
            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            app.UseWebApi(config);
        }
    }

    //public class dev_sbpcoveragetoolInitializer : CreateDatabaseIfNotExists<dev_sbpcoveragetoolContext>
    //{
    //    protected override void Seed(dev_sbpcoveragetoolContext context)
    //    {
    //        List<TodoItem> todoItems = new List<TodoItem>
    //        {
    //            new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
    //            new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
    //        };

    //        foreach (TodoItem todoItem in todoItems)
    //        {
    //            context.Set<TodoItem>().Add(todoItem);
    //        }

    //        base.Seed(context);
    //    }
    //}
}

