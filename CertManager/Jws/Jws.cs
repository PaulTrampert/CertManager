using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertManager.Jws
{
    public class Jws
    {
        public string Protected { get; set; }
        public dynamic Header { get; set; }
        public string Payload { get; set; }
        public string Signature { get; set; }
    }
}
