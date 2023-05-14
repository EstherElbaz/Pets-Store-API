using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        storeWebsiteContext _storeWebsiteContext;
        public ProductRepository(storeWebsiteContext storeWebsiteContext)
        {
            _storeWebsiteContext = storeWebsiteContext;
        }


        public async Task<IEnumerable<Product>> getProducts(string? name, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _storeWebsiteContext.Products.Where(product =>
            (name == null ? (true) : (product.ProductName.Contains(name)))
            && ((minPrice == null) ? (true) : (product.ProductPrice >= minPrice))
            && ((maxPrice == null) ? (true) : (product.ProductPrice <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.ProductCategoryId))))
                .OrderBy(product => product.ProductPrice);
            List<Product> products = await query.ToListAsync();
            return products;
        }
        public async Task<Product> getProduct(int id)
        {

            var products = (from product in _storeWebsiteContext.Products
                        where product.ProductId == id
                            select product).ToArray<Product>();
            return products.FirstOrDefault();

        }
    }
}
