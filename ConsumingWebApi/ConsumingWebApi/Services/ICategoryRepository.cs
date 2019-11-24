using ConsumingWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumingWebApi.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDto> GetCategories();
        CategoryDto GetCategoryById(int categoryId);
        IEnumerable<BookDto> GetAllBooksForCategory(int categoryId);
        IEnumerable<CategoryDto> GetAllCategoriesOfABook(int bookId);
    }
}
