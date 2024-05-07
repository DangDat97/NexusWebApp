﻿using NexusWebApp.Models;
namespace NexusWebApp.Repository
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly NaxusWebAppContext _appContext;

		public CategoryRepository(NaxusWebAppContext appContext)
		{
			_appContext = appContext;
		}

		public Category Add(Category category)
		{
			_appContext.Categories.Add(category);
			_appContext.SaveChanges();
			return category;
		}
		public Category Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Category> GetAll()
		{
			return _appContext.Categories;
		}

		public Category Get(int id)
		{
			return _appContext.Categories.Find(id);
		}
		
		public Category Update(Category category)
		{
			_appContext.Categories.Update(category);
			_appContext.SaveChanges(true);
			return category;
		}


	}
}
