using System.Web.Mvc;
using BookStore.WebApp.Models;
using BookStore.WebApp.Mappers;
using BookStore.Common.ApiClients.Design.Abstractions.PurchaseServiceClient;

namespace BookStore.WebApp.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseClient purchaseClient;

        public PurchaseController(IPurchaseClient purchaseClient)
        {
            this.purchaseClient = purchaseClient;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public async void CheckoutAsync(Order order)
        {
            int orderId = await purchaseClient.CreatePurchase(OrderMapper.Map(order)).ConfigureAwait(false);
        }
    }
}