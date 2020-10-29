using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Models
{
    public class Operation
    {
        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public string Number { get; set; }
        public Contract contract { get; set; }
    }
}
