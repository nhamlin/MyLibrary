﻿using System.Collections.Generic;
using System.Linq;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;

namespace Episerver.Extensions
{
	public static class CategoryExtensions
	{
		public static Category GetCategory(this string idName)
		{
			int id = 0;
			if (int.TryParse(idName, out id))
			{
				return id.GetCategory();
			}

			Category root = ServiceLocator
			                .Current
			                .GetInstance<CategoryRepository>()
			                .GetRoot();
			Category category = root.FindChild(idName);
			if (category != null)
			{
				return category;
			}

			return null;
		}

		public static Category GetCategory(this int id)
		{
			return ServiceLocator
			       .Current
			       .GetInstance<CategoryRepository>()
			       .Get(id);
		}

		public static IEnumerable<Category> GetCategories(this CategoryList categoryList)
		{
			if (categoryList == null || categoryList.Count == 0)
			{
				yield break;
			}

			foreach (int catId in categoryList)
			{
				yield return ServiceLocator
				             .Current
				             .GetInstance<CategoryRepository>()
				             .Get(catId);
			}
		}

		public static IEnumerable<Category> GetCategories(this string categories)
		{
			string[] categoryNamesIds = categories.Split(',');
			return categoryNamesIds.Select(category => category.GetCategory());
		}

		/// <summary>
		///     returns the first category in a CategoryList
		/// </summary>
		/// <param name="categoryList"></param>
		/// <returns></returns>
		public static Category GetFirst(this CategoryList categoryList)
		{
			return categoryList.GetCategories().FirstOrDefault();
		}

		public static IEnumerable<Category> GetChildren(this Category category)
		{
			return category.Categories.Cast<Category>();
		}

		public static IEnumerable<Category> GetDescendents(this Category category)
		{
			if (category == null || category.Categories.Count == 0)
			{
				yield break;
			}

			foreach (Category cat in category.Categories)
			{
				yield return cat;
				foreach (var subCat in cat.GetDescendents())
				{
					yield return subCat;
				}
			}
		}

		public static Category FindCategory(this PageData currentPage, int categoryId)
		{
			if (categoryId > 0)
			{
				if (currentPage.Category.Any(x => x == categoryId))
				{
					return categoryId.GetCategory();
				}
			}

			return null;
		}
	}
}