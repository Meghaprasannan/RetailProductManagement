using iStore.Models;
using System.Collections.Generic;

namespace iStore.ProductData
{
    public interface IProductData
    {
        public IEnumerable<Product> GetProductById(string id);
        public IEnumerable<Product> GetProductByName(string name);
        public Product EditProduct(Product u);
        public IEnumerable<Product> GetProducts();
    }
}