using BlazorFront.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

        public async Task<List<Contract>> GetContractsAsync()
        {
            var body = JsonConvert.SerializeObject(Queries.Queries.ContractsQuery);
            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _graphQLHttpClient.PostAsync(GraphUri, httpContent);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsStringAsync().Result);

            var data = response.Content.ReadAsStringAsync().Result;
            var dataJObject = JObject.Parse(data).GetValue("contracts");
            var contracts = JsonConvert.DeserializeObject<List<Contract>>(dataJObject.ToString());

            return contracts;
        }
    }
}
