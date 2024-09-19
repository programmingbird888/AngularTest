namespace Vendor_Management_System
{
    public class Validation
    {
        public static bool ValidationCode(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Null or white space!");
            }
            else if (input.Length != 8)
            {
                throw new Exception("Code length must be 8 digit only!");
            }
            else
            {
                return true;
            }
        }

        public static bool ValidationString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Null or white space!");
            }
            else if (input.Any(char.IsDigit))
            {
                throw new Exception("Please enter string!");
            }
            else
            {
                return true;
            }
        }

        public static bool ValidationPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new Exception("Null or white space!");
            }
            else if (phone.Length != 10)
            {
                throw new Exception("Please enter the 10 digit number!");
            }
            else if (!phone.All(char.IsDigit))
            {
                throw new Exception("Please enter number!");
            }
            else
            {
                return true;
            }
        }

        public static bool ValidationCurrencyCode(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Null or white space!");
            }
            else if (input.Length != 3)
            {
                throw new Exception("Currency code length must be 3!");
            }
            else if (input.Any(char.IsDigit))
            {
                throw new Exception("Please enter character only!");
            }
            else
            {
                return true;
            }
        }
    }
}
