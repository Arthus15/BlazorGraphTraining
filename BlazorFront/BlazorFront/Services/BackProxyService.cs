using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class BackProxyService
    {
        private readonly GraphQLHttpClient _graphQLHttpClient;
        public BackProxyService()
        {
            var graphQLOptions = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("https://localhost:44310/graphql", UriKind.Absolute),
            };

            _graphQLHttpClient = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());
        }

        public async Task GetContractsAsync()
        {
            var result = await _graphQLHttpClient.SendQueryAsync<string>(Queries.Queries.ContractQuery);
        }
    }
}
