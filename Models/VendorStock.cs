using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iStore.Models
{
    
    public class VendorStock
    {
        [ForeignKey("Product")]
        public int ProductID  { get; set; }

        [ForeignKey("Vendor")]
        public int VendorID { get; set; }
        public int StockInHand { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpectedStockReplinshmentDate { get; set; }
    }
}
