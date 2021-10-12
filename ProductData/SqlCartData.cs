using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iStore.Models;

namespace iStore.CartData
{
    public class SqlCartData:ICartData
    {
        ProductDbContext _cartContext;

        public SqlCartData(ProductDbContext cartContext)
        {
            _cartContext = cartContext;
        }
        public Cart AddProductToCart(Cart c)
        {
            _cartContext.carts.Add(c);
            _cartContext.SaveChanges();
            return c;
        }
        public void DeleteProductFromCart(Cart u)
        {
            _cartContext.carts.Remove(u);
            _cartContext.SaveChanges();
        }
        public Cart GetProductById(int id)
        {
            var user = _cartContext.carts.Find(id);
            return user;
        }
        public IEnumerable<Cart> GetProductsFromCart()
        {
            return _cartContext.carts.ToList();
        }
    }
}
