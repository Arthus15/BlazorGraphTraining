using GraphApi.GraphQLMiddleWare.Types;
using GraphApi.Infraestructure;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApi.GraphQLMiddleWare.Queries
{
    public class OperationQuery: ObjectGraphType
    {
        public OperationQuery(TrainingContext db)
        {
            Field<ListGraphType<OperationType>>(
            "Operations",
            resolve: context =>
            {
                var operations = db.Operations.Include(x => x.Contract).Include(x => x.Inspections);
                return operations;
            });

            Field<OperationType>(
            "Operation",
            arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "Id", Description = "The Id of the Operation." }),
            resolve: context =>
            {
                var id = context.GetArgument<Guid>("Id");
                var operation = db.Operations.Include(x => x.Inspections).FirstOrDefault(x => x.Id == id);
                return operation;
            });
        }
    }
}
