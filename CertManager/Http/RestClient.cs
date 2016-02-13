using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CertManager.Http
{
    public class RestClient : IRestClient
    {
        public async Task<HttpResponseMessage> RequestJson(string uri, HttpMethod method, object body = null,
            IDictionary<string, string> headers = null)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(method, uri);
                foreach (var header in headers ?? new Dictionary<string, string>())
                {
                    request.Headers.Add(header.Key, header.Value);
                }
                if (body != null)
                {
                    var content = JsonConvert.SerializeObject(body);
                    request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                }
                return await client.SendAsync(request);
            }
        }
    }

    public interface IRestClient
    {
        Task<HttpResponseMessage> RequestJson(string uri, HttpMethod method, object body = null,
            IDictionary<string, string> headers = null);
    }
}
