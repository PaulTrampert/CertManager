using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CertManager.Jws;
using CertManager.Jws.SignatureProviders;
using CertManager.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace CertManager.Test
{
    [TestFixture]
    public class WhenCreatingJws : TestBase
    {
        protected object TestObject { get; set; }

        public JsonSerializerSettings SerializationSettings { get; set; }

        protected JwsHandler Handler { get; set; }

        protected dynamic DeserializedHeader { get; set; }

        protected Jws.Jws Result { get; set; }

        public Dictionary<string, string> AdditionalHeaders { get; set; }

        protected const string HmacKey = "key";

        [Test]
        public void DoesNotExplodeWhenCreatingJws()
        {
            Assert.That(Result, Is.Not.Null);
        }

        [Test]
        public void HeaderIsNotNull()
        {
            Assert.That(Result.Protected, Is.Not.Null);
        }

        [Test]
        public void HeaderSuccessfullyDeserializes()
        {
            Assert.That(DeserializedHeader, Is.Not.Null);
            Assert.That(DeserializedHeader.Alg, Is.EqualTo("HS256"));
        }

        [Test]
        public void HeaderContainsAdditionalHeaders()
        {
            Assert.That(DeserializedHeader.Nonce, Is.EqualTo("asdfasdf"));
        }

        [Test]
        public void HeadersCritFieldListsAdditionalHeaders()
        {
            Assert.That(DeserializedHeader.Crit[0], Is.EqualTo("nonce"));
        }

        public override void Context()
        {
            TestObject = new
            {
                Field1 = "stuff",
                Field2 = 42,
                What = new { Field5 = "where'd 1 go?" }
            };

            SerializationSettings = new JsonSerializerSettings();
            SerializationSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            SerializationSettings.NullValueHandling = NullValueHandling.Ignore;

            AdditionalHeaders = new Dictionary<string, string> { {"nonce", "asdfasdf"} };

            Handler = new JwsHandler(new Hmac256Provider(Encoding.UTF8.GetBytes("key")));
        }

        public override void BecauseOf()
        {
            Result = Handler.CreateJws(TestObject, AdditionalHeaders);
            DeserializedHeader = JsonConvert.DeserializeAnonymousType(Base64Url.DeserializeAsUtf8String(Result.Protected), new {Alg = "", Crit = new string[0], Nonce = ""}, SerializationSettings);
        }
    }
}
