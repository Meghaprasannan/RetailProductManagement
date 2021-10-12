using iStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iStore.ViewModel
{
    public class OverallViewModel
    {
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<Cart> carts { get; set; }
        public IEnumerable<Vendor> vendors { get; set; }
        public IEnumerable<Wishlist> wishlists { get; set; }
        public IEnumerable<VendorStock> vendorstocks { get; set; }
    }
}
