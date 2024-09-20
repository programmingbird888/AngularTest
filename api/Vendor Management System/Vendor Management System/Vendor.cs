using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vendor_Management_System
{
    [Table("Vendors")]
    public class Vendor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorId { get; set; }

        [Required(ErrorMessage = "Vendor long name is required.")]
        [StringLength(50, ErrorMessage = "Vendor long name cannot exceed 50 characters.")]
        public string VendorLongName { get; set; }

        [Required(ErrorMessage = "Vendor code is required.")]
        [StringLength(20, ErrorMessage = "Vendor code cannot exceed 20 characters.")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Vendor code can only contain letters and numbers.")]
        public string VendorCode { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        [StringLength(10, ErrorMessage = "Vendor phone number cannot exceed 10 characters.")]
        public string VendorPhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(50, ErrorMessage = "Vendor email cannot exceed 50 characters.")]
        public string VendorEmail { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime VendorCreatedOn { get; set; }

        public bool IsActive { get; set; }

        //public int VendorId { get; set; }
        //public string VendorLongName { get; set; }
        //public string VendorCode { get; set; }
        //public string VendorPhoneNumber { get; set; }
        //public string VendorEmail { get; set; }
        //public DateTime VendorCreatedOn { get; set; }
        //public bool IsActive { get; set; }
        //static int Id { get; set; }

        //public static List<Vendor> VendorList = new List<Vendor>
        //{
        //    new Vendor(){VendorId = 1, VendorLongName = "Sandip", VendorCode = "abcdefgh", VendorPhoneNumber = "9876543212", VendorEmail = "abc@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
        //    new Vendor(){VendorId = 2, VendorLongName = "Rajesh", VendorCode = "ijklmnop", VendorPhoneNumber = "9876543213", VendorEmail = "rajesh@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
        //    new Vendor(){VendorId = 3, VendorLongName = "Anita", VendorCode = "qrstuvwx", VendorPhoneNumber = "9876543214", VendorEmail = "anita@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
        //    new Vendor(){VendorId = 4, VendorLongName = "Vikram", VendorCode = "yzabcdef", VendorPhoneNumber = "9876543215", VendorEmail = "vikram@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
        //    new Vendor(){VendorId = 5, VendorLongName = "Priya", VendorCode = "ghijklmn", VendorPhoneNumber = "9876543216", VendorEmail = "priya@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
        //    new Vendor(){VendorId = 6, VendorLongName = "Amit", VendorCode = "opqrstuv", VendorPhoneNumber = "9876543217", VendorEmail = "amit@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
        //    new Vendor(){VendorId = 7, VendorLongName = "Neha", VendorCode = "wxyzabcd", VendorPhoneNumber = "9876543218", VendorEmail = "neha@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
        //    new Vendor(){VendorId = 8, VendorLongName = "Suresh", VendorCode = "efghijkl", VendorPhoneNumber = "9876543219", VendorEmail = "suresh@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
        //    new Vendor(){VendorId = 9, VendorLongName = "Kavita", VendorCode = "mnopqrst", VendorPhoneNumber = "9876543220", VendorEmail = "kavita@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
        //    new Vendor(){VendorId = 10, VendorLongName = "Rohit", VendorCode = "uvwxyzab", VendorPhoneNumber = "9876543221", VendorEmail = "rohit@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true},
        //    new Vendor(){VendorId = 11, VendorLongName = "Meena", VendorCode = "cdefghij", VendorPhoneNumber = "9876543222", VendorEmail = "meena@gmail.com", VendorCreatedOn = DateTime.Now, IsActive = true}

        //};

        //public string CreateVendor(Vendor vendor)
        //{
        //    Id = VendorList.Max(v => v.VendorId) + 1;
        //    vendor.VendorId = Id;

        //    if (Validation.ValidationString(vendor.VendorLongName) == false)
        //    {
        //        throw new Exception("Invalid name!");
        //    }

        //    if(Validation.ValidationCode(vendor.VendorCode) == false)
        //    {
        //        throw new Exception("Invalid Vendor!");
        //    }

        //    if (Validation.ValidationPhone(vendor.VendorPhoneNumber) == false)
        //    {
        //        throw new Exception("Invalid Phone number!");
        //    }

        //    if (string.IsNullOrWhiteSpace(vendor.VendorEmail))
        //    {
        //        throw new Exception("Invalid Email!");
        //    }

        //    //if(vendor.IsActive != (true || false))
        //    //{
        //    //    throw new Exception("Invalid input!");
        //    //}
        //    else
        //    {
        //        VendorList.Add(vendor);
        //        return "Vendor Added Successfully!";
        //    }
        //}

        //public List<Vendor> ReadVendor()
        //{
        //    return VendorList;
        //}

        //public string DeleteVendor(string code)
        //{
        //    var v = (from a in VendorList
        //             where a.VendorCode == code
        //             select a).Single();
        //    if(v != null)
        //    {
        //        if(Invoice.InvoiceList.Any(f => f.VendorCode == v.VendorCode))
        //        {
        //            throw new Exception("Delete Invoice first!");
        //        }
        //        VendorList.Remove(v);
        //        return "Vendor removed successfully!";
        //    }
        //    throw new Exception("Vendor with " + code + " not found!");

        //}

        //public string UpdateVendor(Vendor vObj)
        //{
        //    var v = (from a in VendorList
        //             where a.VendorCode == vObj.VendorCode
        //             select a).Single();

        //    if(v != null)
        //    {
        //        v.VendorLongName = vObj.VendorLongName;
        //        v.VendorCode = vObj.VendorCode;
        //        v.VendorPhoneNumber = vObj.VendorPhoneNumber;
        //        v.VendorEmail = vObj.VendorEmail;
        //        v.VendorCreatedOn = vObj.VendorCreatedOn;
        //        v.IsActive = true;
        //        return "Vendor updated successfully";
        //    }
        //    else
        //    {
        //        throw new Exception("Please enter valid input!");
        //    }
        //}

        //public Vendor GetVendorByCode(string code)
        //{
        //    var v = (from a in VendorList
        //             where a.VendorCode == code
        //             select a).Single();
        //    if(v != null)
        //    {
        //        return v;
        //    }
        //    else
        //    {
        //       throw new Exception("Invalid code!");
        //    }
        //}

        //public string ExportToCSV()
        //{
        //    try
        //    {
        //        FileStream fs = new FileStream("vendorData.csv", FileMode.Create, FileAccess.Write);

        //        StreamWriter wr = new StreamWriter(fs);

        //        wr.WriteLine("VendorId, VendorLongName, VendorCode, VendorPhoneNumber, VendorEmail, VendorCreatedOn, IsActive");

        //        foreach (var items in VendorList)
        //        {
        //            wr.WriteLine($"{items.VendorId},{items.VendorLongName},{items.VendorCode},{items.VendorPhoneNumber},{items.VendorEmail},{items.VendorCreatedOn},{items.IsActive}");
        //        }
        //        wr.Close();
        //        fs.Close();
        //        return ("Exported Successfully!");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
