using GraphApi.Infraestructure.Entities;
using GraphApi.Infraestructure.IRepositories;
using System;

namespace GraphApi.Infraestructure.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly TrainingContext _context;

        public OperationRepository(TrainingContext context)
        {
            _context = context;
        }
        public Operation Create(Operation operation)
        {
            operation.Id = Guid.NewGuid();
            _context.Add(operation);
            _context.SaveChanges();
            return operation;
        }

        public Operation Delete(Operation operation)
        {
            _context.Remove(operation);
            _context.SaveChanges();
            return operation;
        }

        public Operation Update(Operation operation)
        {
            _context.Update(operation);
            _context.SaveChanges();
            return operation;
        }
    }
}
