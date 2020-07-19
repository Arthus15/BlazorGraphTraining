using GraphApi.Infraestructure.Entities;

namespace GraphApi.Infraestructure.IRepositories
{
    public interface IContractRepository
    {
        Contract Create(Contract contract);
        Contract Delete(Contract contract);
        Contract Update(Contract contract);
    }
}
