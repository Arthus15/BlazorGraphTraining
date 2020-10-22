using BlazorFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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
            var body = JsonConvert.SerializeObject(Queries.Queries.ContractQuery);
            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await _graphQLHttpClient.PostAsync(GraphUri, httpContent);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            var responseContent = response.Content;

            if(responseContent != null)
            {
                try
                {
                    string data = "";
                    data = await responseContent.ReadAsStringAsync();
                }
                catch(Exception ex)
                {

                }
                
            }


            return null;
        }
    }
}
