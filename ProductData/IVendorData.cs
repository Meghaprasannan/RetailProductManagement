using iStore.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iStore.VendorData
{
    public interface IVendorData
    {
        public Vendor GetVendorDetailsById(int id);
        public IEnumerable<Vendor> GetVendors();
    }
}