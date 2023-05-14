using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> getProducts(string? name, int? minPrice, int? maxPrice, int?[] categoryIds);
        public Task<Product> getProduct(int id);


    }
}
