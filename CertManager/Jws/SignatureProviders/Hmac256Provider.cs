using System.Dynamic;
using System.Linq;
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

        public dynamic ProtectedHeader
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

        public bool VerifySignature(byte[] signature, byte[] data)
        {
            var hash = provider.ComputeHash(data);
            if (signature.Length != hash.Length) return false;

            return !hash.Where((t, i) => t != signature[i]).Any();
        }
    }
}
