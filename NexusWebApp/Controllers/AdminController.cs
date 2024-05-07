using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexusWebApp.Models;
using NexusWebApp.Models.Authentication;
using NexusWebApp.ViewModels;
using System.Diagnostics;

namespace NexusWebApp.Controllers
{
	public class AdminController : Controller
	{
		private readonly ILogger<AdminController> _logger;
		private readonly NaxusWebAppContext _appContext;

		public AdminController(ILogger<AdminController> logger, NaxusWebAppContext appContext)
		{
			_logger = logger;
			_appContext = appContext;
		}

		[HttpGet]
		public IActionResult Index()
		{
            return View();
        }

		[HttpGet]
		public IActionResult ListConnection() {
            
            return View();
		}

        [HttpPost]
		public IActionResult ListConnection(ConnectionType connectionType)
		{
			var ConnectionType= new ConnectionType();
            ConnectionType.Name= connectionType.Name;
            ConnectionType.Deposit= connectionType.Deposit;

            _appContext.ConnectionTypes.Add(ConnectionType);
			_appContext.SaveChanges();
			ViewData["Message"] = "Add new Connection Success";
            return View();
		}

		[HttpGet]
		public IActionResult ListProduct() {	
			return View();
		
		}
    }
}
