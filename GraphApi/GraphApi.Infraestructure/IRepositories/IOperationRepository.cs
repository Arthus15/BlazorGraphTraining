using GraphApi.Infraestructure.Entities;

namespace GraphApi.Infraestructure.IRepositories
{
    public interface IOperationRepository
    {
        Operation Create(Operation operation);
        Operation Update(Operation operation);
        Operation Delete(Operation operation);
    }
}
