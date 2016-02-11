using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CertManager.Jws;
using NUnit.Framework;

namespace CertManager.Test
{
    [TestFixture]
    public class JwsHandlerTests
    {
        [Test]
        public void DoesNotExplodeWhenCreatingJws()
        {
            var obj = new
            {
                Field1 = "stuff",
                Field2 = 42,
                What = new {Field5 = "where'd 1 go?"}
            };
            var jwsHandler = new JwsHandler();
            var result = jwsHandler.CreateJws(obj);
            Assert.That(result, Is.Not.Null);
        }
    }
}
