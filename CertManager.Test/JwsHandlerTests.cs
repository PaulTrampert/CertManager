using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CertManager.Jws;
using CertManager.Jws.SignatureProviders;
using NUnit.Framework;

namespace CertManager.Test
{
    [TestFixture]
    public class WhenCreatingJws : TestBase
    {
        protected object TestObject { get; set; }

        protected JwsHandler Handler { get; set; }

        protected Jws.Jws Result { get; set; }

        protected const string HmacKey = "key";

        [Test]
        public void DoesNotExplodeWhenCreatingJws()
        {
            Assert.That(Result, Is.Not.Null);
        }

        public override void Context()
        {
            TestObject = new
            {
                Field1 = "stuff",
                Field2 = 42,
                What = new { Field5 = "where'd 1 go?" }
            };

            Handler = new JwsHandler(new Hmac256Provider(Encoding.UTF8.GetBytes("key")));
        }

        public override void BecauseOf()
        {
            Result = Handler.CreateJws(TestObject);
        }
    }
}
