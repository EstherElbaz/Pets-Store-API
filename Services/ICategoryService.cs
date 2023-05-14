using Entites;
using Repository;

namespace Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> getCategory();
    }
}