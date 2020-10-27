using BlazorFront.Models;
using BlazorFront.Mutations;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class MutationService
    {
        private BackProxyService _proxyService;

        public MutationService(BackProxyService proxyService)
        {
            _proxyService = proxyService;
        }

        public async Task<Contract> CreateContractAsync(Contract contract)
        {
            var mutation = string.Format(Mutations.Mutations.CREATE_CONTRACT, contract.Name, contract.ContractType);
            var content = JsonConvert.SerializeObject(MutationGenerator.GenerateMutation(mutation, Mutations.Mutations.CREATE_CONTRACT_OPERATION_NAME));

            return await _proxyService.PostMutationAsync<Contract>(content, Mutations.Mutations.CREATE_CONTRACT_OPERATION_NAME);
        }
    }
}
