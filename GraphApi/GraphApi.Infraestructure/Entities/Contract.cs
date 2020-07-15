using GraphQL.Types;
using System;
using System.Collections.ObjectModel;

namespace GraphApi.Infraestructure.Entities
{
    public class Contract
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContractType { get; set; }
        public virtual Collection<Operation> Operations { get; set; }

    }    
}
