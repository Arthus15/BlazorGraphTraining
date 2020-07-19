using GraphApi.GraphQLMiddleWare.Types;
using GraphApi.Infraestructure.Entities;
using GraphApi.Infraestructure.IRepositories;
using GraphQL;
using GraphQL.Types;

namespace GraphApi.GraphQLMiddleWare.Mutations
{
    public class OperationMutation : ObjectGraphType
    {
        public OperationMutation(IOperationRepository operationRepository)
        {
            Field<OperationType>(
            "CreateOperation",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<OperationInputType>> { Name = "InputInspection", Description = "New operation to be added" }),
            resolve: context =>
            {
                var contract = context.GetArgument<Operation>("inputInspection");
                return operationRepository.Create(contract);
            });
        }
    }
}
