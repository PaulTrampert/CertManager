using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CertManager.Acme.Models;
using CertManager.Http;
using CertManager.Jws;
using Newtonsoft.Json;

namespace CertManager.Acme
{
    public class AcmeClient
    {
        private readonly IRestClient restClient;
        private readonly JwsBuilder jwsBuilder;
        private readonly string directoryUrl;
        public Directory Directory { get; private set; }
        public string LastNonce { get; private set; }

        public AcmeClient(IRestClient restClient, JwsBuilder jwsBuilder, string directoryUrl)
        {
            this.restClient = restClient;
            this.jwsBuilder = jwsBuilder;
            this.directoryUrl = directoryUrl;
        }

        public async Task Initialize()
        {
            Directory = await MakeRequest<Directory>(directoryUrl, HttpMethod.Get);
        }

        private async Task<T> MakeRequest<T>(string url, HttpMethod method, object body = null)
        {
            var response = await restClient.RequestJson(url, method, body);
            LastNonce = response.Headers.GetValues("Replay-Nonce").SingleOrDefault() ?? LastNonce;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        private async Task<T> PostSignedRequest<T>(string url, object body)
        {
            var jws = jwsBuilder.CreateJws(body, new Dictionary<string, string> {{"nonce", LastNonce}});
            return await MakeRequest<T>(url, HttpMethod.Post, jws);
        }
    }
}
