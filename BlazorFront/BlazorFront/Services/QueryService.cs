using BlazorFront.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class QueryService
    {
        private BackProxyService _proxyService;

        public QueryService(BackProxyService proxyService)
        {
            _proxyService = proxyService;
        }

        public async Task<List<Contract>> GetContractsAsync()
        {
            var content = JsonConvert.SerializeObject(Queries.Queries.ContractsQuery);

            return await _proxyService.PostQueryAsync<List<Contract>>(content, "contracts");
        }

        public async Task<List<Operation>> GetOperationsAsync()
        {
            var content = JsonConvert.SerializeObject(Queries.Queries.OperationsQuery);

            return await _proxyService.PostQueryAsync<List<Operation>>(content, "operations");
        }
    }
}
