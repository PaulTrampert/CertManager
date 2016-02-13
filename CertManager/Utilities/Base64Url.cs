using System;
using System.Text;

namespace CertManager.Utilities
{
    public class Base64Url
    {
        public static string Serialize(string toEncode)
        {
            return Serialize(Encoding.UTF8.GetBytes(toEncode));
        }

        public static string Serialize(byte[] toEncode)
        {
            return Convert.ToBase64String(toEncode).Replace("=", "").Replace('+', '-').Replace('/', '_');
        }

        public static byte[] DeserializeToByteArray(string encoded)
        {
            var standardBase64 = encoded.Replace('-', '+').Replace('_', '/');
            standardBase64 = standardBase64.PadRight(standardBase64.Length + standardBase64.Length%4, '=');
            return Convert.FromBase64String(standardBase64);
        }

        public static string DeserializeAsUtf8String(string encoded)
        {
            var bytes = DeserializeToByteArray(encoded);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}