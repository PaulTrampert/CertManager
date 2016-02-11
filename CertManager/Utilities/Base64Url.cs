using System;
using System.Text;

namespace CertManager.Utilities
{
    public class Base64Url
    {
        public static string ToBase64UrlString(string toEncode)
        {
            return ToBase64UrlString(Encoding.UTF8.GetBytes(toEncode));
        }

        public static string ToBase64UrlString(byte[] toEncode)
        {
            return Convert.ToBase64String(toEncode).Replace("=", "").Replace('+', '-').Replace('/', '_');
        }
    }
}