using System.Text.RegularExpressions;

namespace Dynamic_Application.Utility
{
    public class Validation
    {
        public static bool IsValidEmail(string email)
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'+/=?^_`{|}~-]+)@(?:[a-z0-9](?:[a-z0-9-][a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            bool isPhoneNo = Regex.IsMatch(phoneNumber, @"(\d{1,2})?\-?\d{10}", RegexOptions.IgnoreCase);
            return isPhoneNo;
        }

        public static bool IsValidNumber(string text)
        {
            bool isNumber = Regex.IsMatch(text, @"^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$", RegexOptions.IgnoreCase);
            return isNumber;
        }

    }
}
