using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CertManager.Jws.SignatureProviders;
using NUnit.Framework;

namespace CertManager.Test.JwsTests.SignatureProviderTests
{
    [TestFixture]
    public class WhenSigningWithRsaSignatureProvider : TestBase
    {
        public RsaSignatureProvider Provider { get; set; }
        public byte[] DataToSign { get; set; }
        public byte[] Signature { get; set; }

        public override void Context()
        {
            Provider = new RsaSignatureProvider();
            DataToSign = new byte[] {5, 6, 7, 8, 9, 10};
        }

        public override void BecauseOf()
        {
            Signature = Provider.ComputeSignature(DataToSign);
        }

        [Test]
        public void SignatureVerifiesForUnmodifiedData()
        {
            Assert.That(Provider.VerifySignature(Signature, DataToSign), Is.True);
        }

        [Test]
        public void SignatureVerificationFailsForModifiedData()
        {
            DataToSign[0] = 0;
            Assert.That(Provider.VerifySignature(Signature, DataToSign), Is.False);
        }
    }
}
