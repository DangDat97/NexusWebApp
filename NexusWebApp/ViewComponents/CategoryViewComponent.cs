using NexusWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using NexusWebApp.Repository;
namespace NexusWebApp.ViewComponents
{
	public class CategoryViewComponent: ViewComponent
	{
		private readonly ICategoryRepository _Categories;

		public CategoryViewComponent(ICategoryRepository _CategoryRespository)
		{
			_Categories = _CategoryRespository;
		}

		public IViewComponentResult Invoke()
		{
			var Categories = _Categories.GetAll().OrderBy(x=>x.Id);
			return View(Categories);
		}
	}
}
