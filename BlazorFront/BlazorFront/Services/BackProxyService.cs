using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class BackProxyService
    {
        private Uri GraphUri = new Uri("https://localhost:44310/graphql", UriKind.Absolute);

        private readonly HttpClient _graphQLHttpClient;
        public BackProxyService()
        {
            _graphQLHttpClient = new HttpClient();
        }

        public async Task<T> PostQueryAsync<T>(string content, string operationName)
        {
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _graphQLHttpClient.PostAsync(GraphUri, httpContent);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsStringAsync().Result);

            var data = response.Content.ReadAsStringAsync().Result;
            var dataJObject = JObject.Parse(data).GetValue(char.ToLower(operationName[0]) + operationName.Substring(1));
            var objects = JsonConvert.DeserializeObject<T>(dataJObject.ToString());

            return objects;
        }

        public async Task<T> PostMutationAsync<T>(string content, string mutationName)
        {
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _graphQLHttpClient.PostAsync(GraphUri, httpContent);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsStringAsync().Result);

            var data = response.Content.ReadAsStringAsync().Result;
            var dataJObject = JObject.Parse(data).GetValue(char.ToLower(mutationName[0]) + mutationName.Substring(1));
            var resultObject = JsonConvert.DeserializeObject<T>(dataJObject.ToString());

            return resultObject;
        }
    }
}
