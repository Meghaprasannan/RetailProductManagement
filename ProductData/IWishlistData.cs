using iStore.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iStore.WishlistData
{
    public interface IWishlistData
    {
        public Wishlist AddProductToWishlist(Wishlist w);
        public void DeleteProductFromWishlist(Wishlist u);
        public Wishlist GetProductByIdFromWishlist(int id);
        public IEnumerable<Wishlist> GetProductsFromWishlist();
    }
}