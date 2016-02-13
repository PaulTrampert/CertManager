using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CertManager.Test.AcmeTests
{
    [TestFixture]
    public class WhenInitializing : WithAcmeClient
    {
        public override async Task BecauseOf()
        {
            await ClassUnderTest.Initialize();
        }

        [Test]
        public void DirectoryShouldBePopulated()
        {
            Assert.That(ClassUnderTest.Directory, Is.Not.Null);
        }

        [Test]
        public void NewRegIsPopulated()
        {
            Assert.That(ClassUnderTest.Directory.NewReg, Is.Not.Null);
        }

        [Test]
        public void NewCertIsPopulated()
        {
            Assert.That(ClassUnderTest.Directory.NewCert, Is.Not.Null);
        }

        [Test]
        public void NewAuthzIsPopulated()
        {
            Assert.That(ClassUnderTest.Directory.NewAuthz, Is.Not.Null);
        }

        [Test]
        public void RecoverRegIsPopulated()
        {
            Assert.That(ClassUnderTest.Directory.RecoverReg, Is.Not.Null);
        }

        [Test]
        public void RevokeCertIsNotNull()
        {
            Assert.That(ClassUnderTest.Directory.RevokeCert, Is.Not.Null);
        }
    }
}
