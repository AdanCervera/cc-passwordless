using CC.Passwordless.Utils.Constants;
using System.Text.RegularExpressions;

namespace CC.Passwordless.Utils.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            return Regex.IsMatch(input, RegularExpressions.EmailValidator);
        }
    }
}