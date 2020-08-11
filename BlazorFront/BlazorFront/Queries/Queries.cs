using GraphQL;

namespace BlazorFront.Queries
{
    public class Queries
    {
        public static GraphQLRequest ContractQuery = new GraphQLRequest { Query = "query Contracts{ contracts{id name }}", OperationName = "Contracts" };
    }
}
