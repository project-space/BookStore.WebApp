using BookStore.Common.ApiClients.Design.Abstractions.BookServiceClient;
using BookStore.Common.ApiClients.Design.Abstractions.PurchaseServiceClient;
using BookStore.Common.BookServiceClient;
using BookStore.Common.HttpRequestExecutor;
using BookStore.Common.HttpRequestExecutor.Design;
using BookStore.Common.PurchaseServiceClient;
using LightInject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookStore.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static object sync = new object();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new ServiceContainer();
            container.RegisterControllers();
            //http executor
            container.Register<IHttpExecutor, HttpExecutor>();
            container.Register<IRequestSender, RequestSender>();
            container.Register<IResponseDeserializer, ResponseDeserializer>();
            //book service clients
            container.Register<IBooksClient, BooksClient>();
            container.Register<IGenresClient, GenresClient>();
            // purchase service clients
            //container.Register<IPurchaseClient, PurchaseClient>();
            container.Register<ICartItemClient, CartItemClient>();
            container.Register<ICartsClient, CartsClient>();

            
            container.EnableMvc();
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            if (ex is HttpUnhandledException)
            {
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog);
                string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log", AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
                string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}.{2}()] {3}\r\n",
                DateTime.Now, ex.TargetSite.DeclaringType, ex.TargetSite.Name, ex.Message);
                lock (sync)
                {
                    File.AppendAllText(filename, fullText, Encoding.GetEncoding("Windows-1251"));
                }
            }
        }

    }
}
