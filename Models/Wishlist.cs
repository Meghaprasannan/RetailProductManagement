using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iStore.Models
{
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAddedToWishlist { get; set; }
        public string CustomerId { get; set; }
    }
}
