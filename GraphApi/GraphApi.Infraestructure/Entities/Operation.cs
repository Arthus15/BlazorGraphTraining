using System;
using System.Collections.ObjectModel;

namespace GraphApi.Infraestructure.Entities
{
    public class Operation
    {
        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public string Number { get; set; }
        public Contract Contract { get; set; }
        public virtual Collection<Inspection> Inspections { get; set; }

    }
}
