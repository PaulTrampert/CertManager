using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CertManager.Acme.Models
{
    public class Directory
    {
        [JsonProperty("new-reg")]
        public string NewReg { get; set; }

        [JsonProperty("recover-reg")]
        public string RecoverReg { get; set; }

        [JsonProperty("new-authz")]
        public string NewAuthz { get; set; }

        [JsonProperty("new-cert")]
        public string NewCert { get; set; }

        [JsonProperty("revoke-cert")]
        public string RevokeCert { get; set; }
    }
}
