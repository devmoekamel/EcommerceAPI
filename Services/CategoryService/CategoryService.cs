using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDBContext _context;
        public CategoryService(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool AddCategory(Category category)
        {
            _context.Categories.Add(category);
            if(_context.SaveChanges()>=1)return true;
            return false;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Item> GetProductsInCategory(int id)
        {
            var category =  _context.Categories.Include(c => c.Items).FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return null;
            }

            return category.Items.ToList();
        }

        public bool RemoveCategory(int id)
        {
            var category =  _context.Categories.Find(id);
            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
             _context.SaveChanges();

            return true;
        }
    }
}
