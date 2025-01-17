﻿using GraphApi.Infraestructure.Entities;
using GraphQL.Types;

namespace GraphApi.GraphQLMiddleWare.Types
{
    public class OperationType : ObjectGraphType<Operation>
    {
        public OperationType()
        {
            Name = "Operation";
            Field(x => x.Id).Description("Internal id operation");
            Field(x => x.Number).Description("Autogenerated comdiv operation name");
            Field(x => x.ContractId).Description("Parent contractId");
            Field(x => x.Contract, type: typeof(ContractType)).Description("Parent contract");
            Field(x => x.Inspections, type: typeof(ListGraphType<InspectionType>)).Description("Operations' inspections");
        }
    }

    public class OperationInputType : InputObjectGraphType<Operation>
    {
        public OperationInputType()
        {
            Name = "InputOperation";            
            Field(x => x.ContractId).Description("Parent contract");
            Field(x => x.Number).Description("Autogenerated comdiv operation name");
        }
    }
}
