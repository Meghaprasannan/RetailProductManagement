using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iStore.Models
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }
        public string VendorName { get; set; }
        public int DeliveryCharge { get; set; }
        public Decimal Rating { get; set; }
    }
}
