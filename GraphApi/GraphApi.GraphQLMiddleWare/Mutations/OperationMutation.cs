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
                new QueryArgument<NonNullGraphType<OperationInputType>> { Name = "newOperation", Description = "New operation to be added" }),
            resolve: context =>
            {
                var operation = context.GetArgument<Operation>("newOperation");
                return operationRepository.Create(operation);
            });
        }
    }
}
