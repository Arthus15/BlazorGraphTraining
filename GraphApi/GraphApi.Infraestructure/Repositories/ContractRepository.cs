using GraphApi.Infraestructure.Entities;
using GraphApi.Infraestructure.IRepositories;
using System;

namespace GraphApi.Infraestructure.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly TrainingContext _context;

        public ContractRepository(TrainingContext context)
        {
            _context = context;
        }
        public Contract Create(Contract contract)
        {
            contract.Id = Guid.NewGuid();
            _context.Add(contract);
            _context.SaveChanges();

            return contract;
        }

        public Contract Delete(Contract contract)
        {
            _context.Remove(contract);
            _context.SaveChanges();
            return contract;
        }

        public Contract Update(Contract contract)
        {
            _context.Update(contract);
            _context.SaveChanges();
            return contract;
        }
    }
}
