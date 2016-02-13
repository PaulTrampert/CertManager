using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CertManager.Jws.SignatureProviders;
using CertManager.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CertManager.Jws
{
    public class JwsHandler
    {
        private readonly ISignatureProvider signatureProvider;
        private JsonSerializerSettings JsonSettings { get; }

        public JwsHandler(ISignatureProvider signatureProvider = null)
        {
            JsonSettings = new JsonSerializerSettings();
            JsonSettings.NullValueHandling = NullValueHandling.Ignore;
            JsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            JsonSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            if (signatureProvider == null)
                this.signatureProvider = new Hmac256Provider();
            else
                this.signatureProvider = signatureProvider;
        }

        public Jws CreateJws<T>(T obj, IDictionary<string, string> additionalHeaderProperties = null)
        {
            var result = new Jws();
            var jsonPayload = JsonConvert.SerializeObject(obj, JsonSettings);
            result.Payload = Base64Url.Serialize(jsonPayload);
            var header = signatureProvider.Header;
            if (additionalHeaderProperties != null && additionalHeaderProperties.Any())
            {
                header.Crit = additionalHeaderProperties.Keys;
                IDictionary<string, object> headerDict = header;
                foreach (var kvp in additionalHeaderProperties)
                {
                    headerDict[kvp.Key] = kvp.Value;
                }
            }
            result.Protected = Base64Url.Serialize((string) JsonConvert.SerializeObject(header, JsonSettings));
            result.Signature = Base64Url.Serialize(signatureProvider.ComputeSignature(Encoding.UTF8.GetBytes($"{result.Protected}.{result.Payload}")));
            return result;
        }
    }
}
