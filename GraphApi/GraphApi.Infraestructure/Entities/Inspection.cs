using System;

namespace GraphApi.Infraestructure.Entities
{
    public class Inspection
    {
        public Guid Id { get; set; }
        public Guid OperationId { get; set; }
        public string Name { get; set; }
        public string InspectionPlace { get; set; }
        public DateTime InspectionDate { get; set; }
        public Operation Operation { get; set; }
    }
}
