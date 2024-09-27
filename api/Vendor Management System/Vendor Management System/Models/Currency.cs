using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vendor_Management_System.Models
{
    [Table("Currencies")]
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Currency name is required.")]
        [StringLength(10, ErrorMessage = "Currency name cannot exceed 10 characters.")]
        public string CurrencyName { get; set; }

        [Required(ErrorMessage = "Currency code is required.")]
        [StringLength(3, ErrorMessage = "Currency code must be exactly 3 characters long.")]
        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Currency code must be in uppercase and exactly 3 letters.")]
        public string CurrencyCode { get; set; }

        //static int Id { get; set; }

        //public static List<Currency> CurrencyList = new List<Currency>
        //{
        //    new Currency(){CurrencyId = 1, CurrencyName = "rupee", CurrencyCode = "INR"},
        //    new Currency(){CurrencyId = 2, CurrencyName = "dollar", CurrencyCode = "USD"},
        //    new Currency(){CurrencyId = 3, CurrencyName = "euro", CurrencyCode = "EUR"},
        //    new Currency(){CurrencyId = 4, CurrencyName = "pound", CurrencyCode = "GBP"},
        //    new Currency(){CurrencyId = 5, CurrencyName = "yen", CurrencyCode = "JPY"},
        //    new Currency(){CurrencyId = 6, CurrencyName = "franc", CurrencyCode = "CHF"},
        //    new Currency(){CurrencyId = 7, CurrencyName = "rupee", CurrencyCode = "PKR"},
        //    new Currency(){CurrencyId = 8, CurrencyName = "dinar", CurrencyCode = "KWD"},
        //    new Currency(){CurrencyId = 9, CurrencyName = "peso", CurrencyCode = "MXN"},
        //    new Currency(){CurrencyId = 10, CurrencyName = "won", CurrencyCode = "KRW"},
        //    new Currency(){CurrencyId = 11, CurrencyName = "real", CurrencyCode = "BRL"},

        //};

        //public string CreateCurrency(Currency currency)
        //{
        //    Id = CurrencyList.Max(v => v.CurrencyId) + 1;
        //    currency.CurrencyId = Id;

        //    currency.CurrencyCode = currency.CurrencyCode.ToUpper();

        //    if (Validation.ValidationString(currency.CurrencyName) == false)
        //    {
        //        throw new Exception("Invalid currency name!");
        //    }

        //    if (Validation.ValidationCurrencyCode(currency.CurrencyCode) == false)
        //    {
        //        throw new Exception("Invalid Curency Code!");
        //    }

        //    else
        //    {
        //        CurrencyList.Add(currency);
        //        return "Currency added successfully!";
        //    }
        //}

        //public List<Currency> ReadCurrency()
        //{
        //    return CurrencyList;
        //}

        ////public string DeleteCurrency(string code)
        ////{
        ////    var v = (from a in CurrencyList
        ////             where a.CurrencyCode == code
        ////             select a).Single();
        ////    if (v != null)
        ////    {
        ////        if (Invoice.InvoiceList.Any(f => f.InvoiceCurrencyCode == v.CurrencyCode))
        ////        {
        ////            throw new Exception("Invoice is present with this Currency Id! \n Delete Invoice first!");
        ////        }
        ////        CurrencyList.Remove(v);
        ////        return "Currency removed successfully!";
        ////    }
        ////    throw new Exception("Currency with " + code + " not found!");
        ////}

        //public Currency GetCurrencyByCode(string code)
        //{
        //    var v = (from a in CurrencyList
        //             where a.CurrencyCode == code
        //             select a).Single();
        //    if (v != null)
        //    {
        //        return v;
        //    }
        //    else
        //    {
        //        throw new Exception("Invalid code!");
        //    }
        //}

        //public string UpdateCurrency(Currency cObj)
        //{
        //    var c = (from a in CurrencyList
        //             where a.CurrencyCode == cObj.CurrencyCode
        //             select a).Single();

        //    if( c != null)
        //    {
        //        c.CurrencyName = cObj.CurrencyName;
        //        c.CurrencyCode = cObj.CurrencyCode;
        //        return "Currency updated successfully!";
        //    }
        //    else
        //    {
        //        throw new Exception("Please enter valid field!");
        //    }
        //}
    }
}
