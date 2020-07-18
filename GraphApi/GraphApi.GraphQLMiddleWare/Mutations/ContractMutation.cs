﻿using GraphApi.GraphQLMiddleWare.Types;
using GraphApi.Infraestructure.Entities;
using GraphApi.Infraestructure.IRepositories;
using GraphQL;
using GraphQL.Types;

namespace GraphApi.GraphQLMiddleWare.Mutations
{
    public class ContractMutation : ObjectGraphType
    {
        public ContractMutation(IContractRepository contractRepository)
        {
            Field<ContractType>(
            "CreateContract",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<ContractType>> { Name = "Contract", Description = "New contract to be added" }),
            resolve: context =>
            {
                var contract = context.GetArgument<Contract>("Contract");
                return contractRepository.Create(contract);
            });
        }
    }
}
