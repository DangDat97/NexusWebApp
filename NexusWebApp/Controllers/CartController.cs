using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NexusWebApp.Models;
using NexusWebApp.Helpers;
using NexusWebApp.Models.Authentication;
namespace NexusWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly NaxusWebAppContext _appContext;

        public CartController(NaxusWebAppContext appContext)
        {
            _appContext = appContext;
        }
        const string Cart_Key = "MYCART";
        public List<OrderItem> Carts => HttpContext.Session.
            Get<List<OrderItem>>(Cart_Key)?? new List<OrderItem>();

        public IActionResult Index()
        {
            return View();
        }
        [Authencation]
        public IActionResult AddToCart(int id, int quantity)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(x=>x.Id == id);
            if(item == null)
            {
                var product = _appContext.Products.SingleOrDefault(x=>x.Id.Equals(id));
                if(product == null)
                {
                    TempData["Message"] = $"No products found";
                    return Redirect("/404");
                }
                
                item = new OrderItem() { 
                    ProductId = product.Id,
                    Quantity = quantity,
                    Price = product.Price,
                    OrderId = id,
                };
                myCart.Add(item);
            }
            else
            {
                item.Quantity++;
            }

            HttpContext.Session.Set(Cart_Key, myCart);
            return RedirectToAction("Cart");
        }
    }
}
