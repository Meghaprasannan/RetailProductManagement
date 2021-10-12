using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iStore.Models;

namespace iStore.WishlistData
{
    public class SqlWishlistData:IWishlistData
    {
        ProductDbContext _wishContext;

        public SqlWishlistData(ProductDbContext wishContext)
        {
            _wishContext = wishContext;
        }
        public Wishlist AddProductToWishlist(Wishlist c)
        {
            _wishContext.wishlists.Add(c);
            _wishContext.SaveChanges();
            return c;
        }
        public void DeleteProductFromWishlist(Wishlist u)
        {
            _wishContext.wishlists.Remove(u);
            _wishContext.SaveChanges();
        }
        
        public Wishlist GetProductByIdFromWishlist(int id)
        {
            var user = _wishContext.wishlists.Find(id);
            return user;
        }
        public IEnumerable<Wishlist> GetProductsFromWishlist()
        {
            return _wishContext.wishlists.ToList();
        }

    }
}
