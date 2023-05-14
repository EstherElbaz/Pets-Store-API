using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;
using Repository;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        public CategoryService(ICategoryRepository ICategoryRepository)
        {
            _CategoryRepository = ICategoryRepository;
        }


        public async Task<IEnumerable<Category>> getCategory()
        {
            return await _CategoryRepository.getCategory();

        }



    }
}
