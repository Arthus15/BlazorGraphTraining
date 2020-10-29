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

        public async Task<Contract> UpdateContractAsync(Contract contract)
        {
            var mutation = string.Format(Mutations.Mutations.UPDATE_CONTRACT, contract.Id, contract.Name, contract.ContractType);
            var content = JsonConvert.SerializeObject(MutationGenerator.GenerateMutation(mutation, Mutations.Mutations.UPDATE_CONTRACT_OPERATION_NAME));

            return await _proxyService.PostMutationAsync<Contract>(content, Mutations.Mutations.UPDATE_CONTRACT_OPERATION_NAME);
        }

        public async Task<Contract> DeleteContractAsync(Contract contract)
        {
            var mutation = string.Format(Mutations.Mutations.DELETE_CONTRACT, contract.Id);
            var content = JsonConvert.SerializeObject(MutationGenerator.GenerateMutation(mutation, Mutations.Mutations.DELETE_CONTRACT_OPERATION_NAME));

            return await _proxyService.PostMutationAsync<Contract>(content, Mutations.Mutations.DELETE_CONTRACT_OPERATION_NAME);
        }

        public async Task<Operation> CreateOperationAsync(Operation operation)
        {
            var mutation = string.Format(Mutations.Mutations.CREATE_OPERATION, operation.Number, operation.ContractId);

            var content = JsonConvert.SerializeObject(MutationGenerator.GenerateMutation(mutation, Mutations.Mutations.CREATE_OPERATION_OPERATION_NAME));

            return await _proxyService.PostMutationAsync<Operation>(content, Mutations.Mutations.CREATE_OPERATION_OPERATION_NAME);
        }
    }
}
