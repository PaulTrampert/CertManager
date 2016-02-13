namespace CertManager.Acme.Models
{
    public class Identifier
    {
        public const string DnsType = "dns";

        public string Type { get; set; }
        public string Value { get; set; }
    }
}