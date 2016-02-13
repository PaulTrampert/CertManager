using System.Dynamic;
using System.Security.Cryptography;

namespace CertManager.Jws.SignatureProviders
{
    public class Hmac256Provider : ISignatureProvider
    {
        private readonly HMACSHA256 provider;

        public Hmac256Provider()
        {
            provider = new HMACSHA256();
        }

        public Hmac256Provider(byte[] key)
        {
            provider = new HMACSHA256(key);
        }

        public dynamic Header
        {
            get
            {
                dynamic header = new ExpandoObject();
                header.Alg = Algorithm;
                return header;
            }
        }

        public string Algorithm => "HS256";

        public byte[] ComputeSignature(byte[] data)
        {
            return provider.ComputeHash(data);
        }
    }
}
