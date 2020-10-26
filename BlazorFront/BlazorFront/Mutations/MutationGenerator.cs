using GraphQL;

namespace BlazorFront.Mutations
{
    public static class MutationGenerator
    {
        public static GraphQLRequest GenerateMutation(string mutation, string operationName)
        {
            return new GraphQLRequest() { Query = mutation, OperationName = operationName };
        }
    }
}
