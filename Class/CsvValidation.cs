using System.Text.RegularExpressions;

namespace ReadCsvConsoleApp.Class
{
    public static class CsvValidation
    {
        public static bool IsValidEmail(string email)
        {
            // Simple email validation using regular expression
            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsValidPhone(string phone)
        {
            // Simple phone validation by checking for exactly 10 digits
            return !string.IsNullOrEmpty(phone) && Regex.IsMatch(phone, @"^\d{10}$");
        }

    }
}
