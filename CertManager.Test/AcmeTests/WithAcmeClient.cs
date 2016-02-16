using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CertManager.Acme;
using CertManager.Http;
using CertManager.Jws;
using FakeItEasy;

namespace CertManager.Test.AcmeTests
{
    public abstract class WithAcmeClient : AsyncTestBase
    {
        public AcmeClient ClassUnderTest { get; set; }
        public IRestClient RestClient { get; set; }

        public const string DirectoryJson = @"{
  ""new-reg"": ""https://example.com/acme/new-reg"",
  ""recover-reg"": ""https://example.com/acme/recover-reg"",
  ""new-authz"": ""https://example.com/acme/new-authz"",
  ""new-cert"": ""https://example.com/acme/new-cert"",
  ""revoke-cert"": ""https://example.com/acme/revoke-cert""
}";

        public override async Task Context()
        {
            RestClient = A.Fake<IRestClient>();
            A.CallTo(
                () =>
                    RestClient.RequestJson("https://acme-staging.api.letsencrypt.org/directory", HttpMethod.Get, null,
                        null))
                .Returns(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(DirectoryJson),
                    Headers = {{"Replay-Nonce", "noncey"}}
                });
            
            ClassUnderTest = new AcmeClient(RestClient, new JwsBuilder(),  "https://acme-staging.api.letsencrypt.org/directory");
        }
    }
}
