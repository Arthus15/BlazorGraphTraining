using GraphQL;

namespace BlazorFront.Queries
{
    public class Queries
    {
        public static GraphQLRequest ContractsQuery = new GraphQLRequest { Query = "query Contracts{ contracts{id name contractType }}", OperationName = "Contracts" };
        public static GraphQLRequest OperationsQuery = new GraphQLRequest { Query = "query Operations{operations{id number contract{name}}}", OperationName = "Operations" };

    }
}
