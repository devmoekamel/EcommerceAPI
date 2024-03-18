using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Services.CategoryService
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        bool AddCategory(Category category);
        IEnumerable<Item> GetProductsInCategory(int id);
        bool RemoveCategory(int id);

    }
}
