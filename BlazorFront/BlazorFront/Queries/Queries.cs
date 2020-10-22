using GraphQL;

namespace BlazorFront.Queries
{
    public class Queries
    {
        public static GraphQLRequest ContractsQuery = new GraphQLRequest { Query = "query Contracts{ contracts{id name contractType }}", OperationName = "Contracts" };
    }
}
