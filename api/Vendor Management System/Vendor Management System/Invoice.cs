using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Vendor_Management_System
{
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "Invoice number is required.")]
        [Range(1, long.MaxValue, ErrorMessage = "Invoice number must be a positive number.")]
        public Int64 InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Invoice currency ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invoice currency ID must be a positive number.")]
        public int InvoiceCurrencyId { get; set; }

        [Required(ErrorMessage = "Vendor ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Vendor ID must be a positive number.")]
        public int VendorId { get; set; }

        [Required(ErrorMessage = "Invoice amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Invoice amount must be a positive value.")]
        public decimal InvoiceAmount { get; set; }

        [Required(ErrorMessage = "Invoice received date is required.")]
        [DataType(DataType.Date)]
        public DateTime InvoiceReceivedDate { get; set; }

        [Required(ErrorMessage = "Invoice due date is required.")]
        [DataType(DataType.Date)]
        public DateTime InvoiceDueDate { get; set; }

        public bool IsActive { get; set; }

        //public int InvoiceId { get; set; }
        //public string InvoiceNumber { get; set; }
        //public string InvoiceCurrencyCode { get; set; }
        //public string VendorCode { get; set; }
        //public int InvoiceAmount { get; set; }
        //public DateTime InvoiceReceivedDate { get; set; }
        //public DateTime InvoiceDueDate { get; set; }
        //public bool IsActive { get; set; }
        //static int Id { get; set; }

        //public static List<Invoice> InvoiceList = new List<Invoice>
        //{
        //    new Invoice(){InvoiceId = 1, InvoiceNumber = 12345678, InvoiceCurrencyId = 1, VendorId = 1, InvoiceAmount = 500, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("12-08-2024"), IsActive = true},
        //    new Invoice(){InvoiceId = 2, InvoiceNumber = 12345679, InvoiceCurrencyId = 1, VendorId = 2, InvoiceAmount = 750, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("15-08-2024"), IsActive = true},
        //    new Invoice(){InvoiceId = 3, InvoiceNumber = 12345680, InvoiceCurrencyId = 2, VendorId = 1, InvoiceAmount = 1000, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("18-08-2024"), IsActive = true},
        //    new Invoice(){InvoiceId = 4, InvoiceNumber = 12345681, InvoiceCurrencyId = 1, VendorId = 2, InvoiceAmount = 1250, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("20-08-2024"), IsActive = true},
        //    new Invoice(){InvoiceId = 5, InvoiceNumber = 12345682, InvoiceCurrencyId = 2, VendorId = 1, InvoiceAmount = 1500, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("22-08-2024"), IsActive = true},
        //    new Invoice(){InvoiceId = 6, InvoiceNumber = 12345683, InvoiceCurrencyId = 1, VendorId = 2, InvoiceAmount = 1750, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("25-08-2024"), IsActive = true},
        //    new Invoice(){InvoiceId = 7, InvoiceNumber = 12345684, InvoiceCurrencyId = 2, VendorId = 1, InvoiceAmount = 2000, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("28-08-2024"), IsActive = true},
        //    new Invoice(){InvoiceId = 8, InvoiceNumber = 12345685, InvoiceCurrencyId = 1, VendorId = 2, InvoiceAmount = 2250, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("30-08-2024"), IsActive = true},
        //    new Invoice(){InvoiceId = 9, InvoiceNumber = 12345686, InvoiceCurrencyId = 2, VendorId = 3, InvoiceAmount = 2500, InvoiceReceivedDate = DateTime.Now, InvoiceDueDate = DateTime.Parse("02-09-2024"), IsActive = true},
         

        //};

        //public string CreateInvoice(Invoice invoice)
        //{
        //    Id = InvoiceList.Max(v => v.InvoiceId) + 1;
        //    invoice.InvoiceId = Id;

        //    if (!Currency.CurrencyList.Any(c => c.CurrencyCode == invoice.InvoiceCurrencyCode))
        //    {
        //        throw new Exception("Invalid Invoice, Currency Id not present in Currency!");
        //    }

        //    if (!Vendor.VendorList.Any(d => d.VendorCode == invoice.VendorCode))
        //    {
        //        throw new Exception("Vendor is not present! \n Create vendor first!");
        //    }

        //    if (!int.IsPositive(invoice.InvoiceAmount))
        //    {
        //        throw new Exception("Invalid Invoice Amount!");
        //    }

        //    invoice.InvoiceReceivedDate = DateTime.Now;

        //    if (invoice.InvoiceDueDate < invoice.InvoiceReceivedDate)
        //    {
        //        throw new ArgumentException("Due date cannot be earlier than the received date. Please enter a valid due date.");
        //    }

        //    if (invoice.IsActive != (true || false))
        //    {
        //        throw new Exception("Invalid input!");
        //    }

        //    else
        //    {
        //        InvoiceList.Add(invoice);
        //        return "Invoice added successfully!";
        //    }
        //}

        //public List<Invoice> ReadInvoice()
        //{
        //    return InvoiceList;
        //}

        //public string DeleteInvoice(string number)
        //{
        //    var i = (from a in InvoiceList
        //             where a.InvoiceNumber == number
        //             select a).Single();
        //    if (i != null)
        //    {
        //        InvoiceList.Remove(i);
        //        return "Invoice removed successfully!";
        //    }
        //    else
        //    {
        //        throw new Exception("Invoice number " + number + " not found!");
        //    }
        //}

        //public string UpdateInvoice(Invoice iObj)
        //{
        //    var i = (from a in InvoiceList
        //             where a.InvoiceNumber == iObj.InvoiceNumber
        //             select a).Single();

        //    if (i != null)
        //    {
        //        i.InvoiceNumber = iObj.InvoiceNumber;
        //        i.InvoiceCurrencyCode = iObj.InvoiceCurrencyCode;
        //        i.VendorCode = iObj.VendorCode;
        //        i.InvoiceAmount = iObj.InvoiceAmount;
        //        i.InvoiceDueDate = iObj.InvoiceDueDate;
        //        i.IsActive = true;
        //        return "Invoice updated successfully";
        //    }
        //    else
        //    {
        //        throw new Exception("Please enter valid input!");
        //    }
        //}

        //public List<Invoice> InvoiceByVendorId(string vendorCode)
        //{
        //    var i = (from v in InvoiceList
        //             where v.VendorCode == vendorCode
        //             select v).ToList();

        //    if (i != null)
        //    {
        //        return i;
        //    }
        //    throw new Exception("Invoices with this vendor Id is not present!");
        //}

        //public IEnumerable<object> InvoiceCount(string vendorCode)
        //{
        //    var invoiceList = InvoiceList.GroupBy(i => i.VendorCode).Select(g => new { VendorCode = g.Key, Count = g.Count() });
        //    if(invoiceList != null)
        //    {
        //        return invoiceList;
        //    }
        //    throw new Exception("Invoice not Present!");
        //}

        //public Invoice GetInvoiceByNumber(string number)
        //{
        //    var v = (from a in InvoiceList
        //             where a.InvoiceNumber == number
        //             select a).Single();
        //    if (v != null)
        //    {
        //        return v;
        //    }
        //    else
        //    {
        //        throw new Exception("Invalid number!");
        //    }
        //}

        //public string ExportToCSV()
        //{
        //    try
        //    {
        //        FileStream invoiceFile = new FileStream("invoiceData.csv", FileMode.Create, FileAccess.Write);

        //        StreamWriter wt = new StreamWriter(invoiceFile);

        //        wt.WriteLine("InvoiceId, InvoiceNumber, InvoiceCurrencyId, VendorId, VendorName, InvoiceAmount, InvoiceReceivedDate, InvoiceDueDate, IsActive");

        //        foreach (var items in InvoiceList)
        //        {
        //            wt.WriteLine($"{items.InvoiceId},{items.InvoiceNumber},{items.InvoiceCurrencyCode},{items.VendorCode}, {Vendor.VendorList.Find(v => v.VendorCode == items.VendorCode).VendorLongName},{items.InvoiceAmount},{items.InvoiceReceivedDate},{items.InvoiceDueDate},{items.IsActive}");
        //        }

        //        wt.Close();
        //        invoiceFile.Close();

        //        return ("Exported Successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
