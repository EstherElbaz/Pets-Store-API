using Entites; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        storeWebsiteContext _storeWebsiteContext;
        public CategoryRepository(storeWebsiteContext storeWebsiteContext)
        {
            _storeWebsiteContext = storeWebsiteContext;
        }

        public async Task<IEnumerable<Category>> getCategory()
        {
            IEnumerable<Category> categories = await _storeWebsiteContext.Categories.ToArrayAsync();
            return categories;
        }


    }
}
