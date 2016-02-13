using System;

namespace CertManager.Acme.Models
{
    public class Challenge
    {
        public const string SimpleHttpType = "simpleHttp";

        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime Validated { get; set; }
        public string Token { get; set; }
    }
}