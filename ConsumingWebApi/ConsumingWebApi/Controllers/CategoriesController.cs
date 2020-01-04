using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsumingWebApi.Services;
using ConsumingWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConsumingWebApi.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepository.GetCategories();

            if (categories == null)
            {
                ViewBag.Message = "There was a problem retrirving categories from the database or no category exists";
            }

            return View(categories);
        }

        public IActionResult GetCategoryById(int categoryId)
        {
            var category = _categoryRepository.GetCategoryById(categoryId);

            if (category == null)
            {
                ModelState.AddModelError(null, "Error getting category");
                ViewBag.Message = $"There was a problem retrieving category with id {categoryId} from the database or no category exists";
                category = new Dtos.CategoryDto();
            }

            var books = _categoryRepository.GetAllBooksForCategory(categoryId);

            if (books == null || books.Count() <= 0)
            {
                ViewBag.BookMessage = $"{category.Name} 's Category has no books";
            }

            var bookCategoryVM = new CategoryBooksVM
            {
                Books = books,
                Category = category
            };

            return View(bookCategoryVM);
        }
    }
}