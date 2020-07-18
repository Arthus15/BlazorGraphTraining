using GraphApi.Infraestructure.Entities;

namespace GraphApi.Infraestructure.IRepositories
{
    public interface IInspectionRepository
    {
        Inspection Create(Inspection inspection);
        Inspection Update(Inspection inspection);
        Inspection Delete(Inspection inspection);
    }
}
