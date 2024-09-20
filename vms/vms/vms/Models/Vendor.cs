using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vms.Models
{
    [Table("Vendors")]
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }
        public string VendorLongName { get; set; }
        public string VendorCode { get; set; }
        public string VendorPhoneNumber { get; set; }
        public string VendorEmail { get; set; }
        public DateTime VendorCreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
