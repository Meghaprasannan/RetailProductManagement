using iStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iStore.ProductData
{
    public class SqlProductData:IProductData
    {
        ProductDbContext context;

        public SqlProductData(ProductDbContext dbContext)
        {
            context = dbContext;
        }
        public IEnumerable<Product> GetProductById(string id)
        {
            var details = context.products.Where(s=>s.Id.ToString()==id);
            return details;
        }
        public IEnumerable<Product> GetProductByName(string name)
        {
            var details = context.products.Where(s => s.Name.StartsWith(name));
            return details;
        }
        public Product EditProduct(Product u)
        {
            var ExistingProduct = context.products.Find(u.Id);
            ExistingProduct.Rating = (u.Rating+ExistingProduct.Rating*5)/6;
            
            context.SaveChanges();
            return ExistingProduct;
        }
        public IEnumerable<Product> GetProducts()
        {
            return context.products.ToList();
        }
    }
}
