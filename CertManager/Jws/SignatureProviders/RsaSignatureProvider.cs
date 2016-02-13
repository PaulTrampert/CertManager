using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CertManager.Utilities;

namespace CertManager.Jws.SignatureProviders
{
    public class RsaSignatureProvider : ISignatureProvider
    {
        private RSACryptoServiceProvider rsa;

        public dynamic Header
        {
            get
            {
                dynamic result = new ExpandoObject();
                result.Alg = Algorithm;
                var rsaParams = rsa.ExportParameters(false);
                result.Jwk = new
                {
                    Kty = "RSA",
                    N = Base64Url.Serialize(rsaParams.Modulus),
                    E = Base64Url.Serialize(rsaParams.Exponent),
                    Alg = Algorithm
                };
                return result;
            }
        }

        public string Algorithm => "RS512";

        public RsaSignatureProvider(RSACryptoServiceProvider rsa = null)
        {
            this.rsa = rsa ?? new RSACryptoServiceProvider(2048);
        }

        public byte[] ComputeSignature(byte[] data)
        {
            return rsa.SignData(data, HashAlgorithmName.SHA512, RSASignaturePadding.Pkcs1);
        }

        public bool VerifySignature(byte[] signature, byte[] data)
        {
            return rsa.VerifyData(data, signature, HashAlgorithmName.SHA512, RSASignaturePadding.Pkcs1);
        }
    }
}
