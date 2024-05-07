using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexusWebApp.Models;
using NexusWebApp.ViewModels;
using System.Diagnostics;
using X.PagedList;

namespace NexusWebApp.Controllers
{
    public class HomeController : Controller
    {

		private readonly NaxusWebAppContext _appContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, NaxusWebAppContext appContext)
        {
            _logger = logger;
			_appContext = appContext;
        }
        public IActionResult Index()
        {
			
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Shop(int? page=1)
        {
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var products =
                _appContext.Products.AsNoTracking().OrderBy(x => x.Name);
            PagedList<Product> lst = new PagedList<Product>(products, pageNumber, pageSize);

            return View(lst);
        }

		public IActionResult ProductCategory(int id ,int? page = 1) {
			int pageSize = 4;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var products =
			_appContext.Products.AsNoTracking().Where(x => x.CategoryId == id).OrderBy(x => x.Name);
			PagedList<Product> lst = new PagedList<Product>(products, pageNumber, pageSize);

			return View(lst);
		}
		public IActionResult Product(int id)	
		{
            var productP = _appContext.Products.SingleOrDefault(x => x.Id == id);
            var ImagesP = _appContext.ProductImages.Where(x => x.ProductId == id).ToList();
            if (productP is null) return NotFound();
			
			var ProductImages = new HomeProductDetailViewModels {
            product= productP, images= ImagesP
            };
			return View(ProductImages);
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Cart()
		{
			return View();
		}

		public IActionResult Checkout()
		{
			return View();
		}

		[HttpGet]
		public ActionResult BookingForm() {
			return View();
		}

        //[HttpPost]
        //public ActionResult BookingForm()
        //{
        //    return View();
        //}


        // Controllers Acount
        public IActionResult AccountD()
		{
			return View();
		}

		public IActionResult Dashboard()
		{
			return View();
		}
		public IActionResult Orders()
		{
			return View();
		}

		public IActionResult OrdersSingle()
		{
			return View();
		}

		public IActionResult Addresses()
		{
			return View();
		}
		public IActionResult AddressesEdit()
		{
			return View();
		}

		// End Controller Acount



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
