using GraphApi.Infraestructure.Entities;
using GraphApi.Infraestructure.IRepositories;
using System;

namespace GraphApi.Infraestructure.Repositories
{
    public class InspectionRepository : IInspectionRepository
    {
        private readonly TrainingContext _context;

        public InspectionRepository(TrainingContext context)
        {
            _context = context;
        }

        public Inspection Create(Inspection inspection)
        {
            inspection.Id = Guid.NewGuid();
            _context.Add(inspection);
            _context.SaveChanges();
            return inspection;
        }

        public Inspection Delete(Inspection inspection)
        {
            _context.Remove(inspection);
            _context.SaveChanges();
            return inspection;
        }

        public Inspection Update(Inspection inspection)
        {
            _context.Update(inspection);
            _context.SaveChanges();
            return inspection;
        }
    }
}
