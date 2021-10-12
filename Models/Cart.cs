using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iStore.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Zipcode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string CustomerId { get; set; }
    }
}
