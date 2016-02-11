using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CertManager.Jws
{
    public class JwsHandler
    {
        private JsonSerializerSettings JsonSettings { get; }

        public JwsHandler()
        {
            JsonSettings = new JsonSerializerSettings();
            JsonSettings.NullValueHandling = NullValueHandling.Ignore;
            JsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            JsonSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
        }

        public Jws CreateJws<T>(T obj)
        {
            var result = new Jws();
            var jsonPayload = JsonConvert.SerializeObject(obj);
            result.Payload = Base64Url.ToBase64UrlString(jsonPayload);
            var header = new JwsHeader();
            header.Alg = "HS256";
            var hmacsha256 = new HMACSHA256();
            header.Jwk = Base64Url.ToBase64UrlString(hmacsha256.Key);
            result.Protected = Base64Url.ToBase64UrlString(JsonConvert.SerializeObject(header));
            result.Signature = Base64Url.ToBase64UrlString(hmacsha256.ComputeHash(Encoding.UTF8.GetBytes($"{result.Protected}.{result.Payload}")));
            return result;
        }
    }
}
