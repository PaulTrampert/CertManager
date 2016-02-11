using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CertManager.Jws.Crypto
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

        public byte[] VerificationKey => provider.Key;

        public byte[] ComputeSignature(byte[] data)
        {
            return provider.ComputeHash(data);
        }
    }
}
