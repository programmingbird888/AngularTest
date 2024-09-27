using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vendor_Management_System.Models
{
    [Table("InvoiceView")]
    public class InvoiceView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }
        public long InvoiceNumber { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string VendorCode { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsActive { get; set; }
        public DateOnly InvoiceReceivedDate { get; set; }
    }
}
