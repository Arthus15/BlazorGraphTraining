using GraphApi.GraphQLMiddleWare.Types;
using GraphApi.Infraestructure;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GraphApi.GraphQLMiddleWare.Queries
{
    public class ContractQuery : ObjectGraphType
    {
        public ContractQuery(TrainingContext db)
        {
            Field<ListGraphType<ContractType>>(
            "Contracts",
            resolve: context =>
            {
                var contracts = db.Contracts.Include(x => x.Operations).ThenInclude(x => x.Inspections);
                return contracts;
            });

            Field<ContractType>(
            "Contract",
            arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "Id", Description = "The Id of the Contract." }),
            resolve: context =>
            {
                var id = context.GetArgument<Guid>("Id");
                var contract = db.Contracts.Include(x => x.Operations).ThenInclude(x => x.Inspections).FirstOrDefault(x => x.Id == id);
                return contract;
            });
        }
    }
}
