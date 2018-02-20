using BookStore.Common.ApiClients.Design.Abstractions.BookServiceClient;
using BookStore.Common.ApiClients.Design.Abstractions.PurchaseServiceClient;
using BookStore.Common.BookServiceClient;
using BookStore.Common.HttpRequestExecutor;
using BookStore.Common.HttpRequestExecutor.Design;
using BookStore.Common.PurchaseServiceClient;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookStore.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
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
            container.Register<IPurchaseClient, PurchaseClient>();
            container.Register<ICartItemClient, CartItemClient>();
            container.Register<ICartsClient, CartsClient>();
            container.EnableMvc();
        }
    }
}
