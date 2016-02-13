using System.Collections.Generic;

namespace CertManager.Acme.Models
{
    public class Registration
    {
        public string Resource { get; set; }

        public IEnumerable<string> Contacts { get; set; }

        public string Agreement { get; set; }

        public string Authorizations { get; set; }

        public string Certificates { get; set; }
    }
}
