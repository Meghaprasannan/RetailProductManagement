using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iStore.Models;

namespace iStore.VendorData
{
    public class SqlVendorData:IVendorData
    {
        ProductDbContext _vendorContext;

        public SqlVendorData(ProductDbContext vendorContext)
        {
            _vendorContext = vendorContext;
        }
        public Vendor GetVendorDetailsById(int id)
        {
            var details = _vendorContext.vendors.Find(id);
            return details;
        }
        public IEnumerable<Vendor> GetVendors()
        {
            return _vendorContext.vendors.ToList();
        }
    }
}
