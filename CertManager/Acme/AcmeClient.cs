using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CertManager.Acme.Models;
using CertManager.Http;
using Newtonsoft.Json;

namespace CertManager.Acme
{
    public class AcmeClient
    {
        private IRestClient restClient;
        private readonly string directoryUrl;
        public Directory Directory { get; private set; }
        public string LastNonce { get; private set; }

        public AcmeClient(IRestClient restClient, string directoryUrl)
        {
            this.restClient = restClient;
            this.directoryUrl = directoryUrl;
        }

        public async Task Initialize()
        {
            Directory = await MakeRequest<Directory>(directoryUrl, HttpMethod.Get);
        }

        private async Task<T> MakeRequest<T>(string url, HttpMethod method)
        {
            var response = await restClient.RequestJson(url, method);
            LastNonce = response.Headers.GetValues("Replay-Nonce").SingleOrDefault() ?? LastNonce;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
