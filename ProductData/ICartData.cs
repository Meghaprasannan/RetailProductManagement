using iStore.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iStore.CartData
{
    public interface ICartData
    {
        public Cart AddProductToCart(Cart c);
        public void DeleteProductFromCart(Cart u);
        public Cart GetProductById(int id);
        public IEnumerable<Cart> GetProductsFromCart();
    }
}