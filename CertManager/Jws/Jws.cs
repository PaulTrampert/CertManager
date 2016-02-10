using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertManager.Jws
{
    public class Jws<T>
    {
        public JwsHeader Protected { get; set; }
        public dynamic Header { get; set; }
        public T Payload { get; set; }
        public string Signature { get; set; }
    }
}
