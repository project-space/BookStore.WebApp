using System.Web.Mvc;
using BookStore.WebApp.Models;
using BookStore.Common.PurchaseServiceClient;
using BookStore.WebApp.Mappers;

namespace BookStore.WebApp.Controllers
{
    public class PurchaseController : Controller
    {

        private static PurchaseClient purchaseClient = new PurchaseClient();

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Checkout(Order order)
        {
            purchaseClient.CreatePurchase(OrderMapper.Map(order));
        }
    }
}