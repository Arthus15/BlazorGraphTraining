using GraphApi.GraphQLMiddleWare.Types;
using GraphApi.Infraestructure;
using GraphQL.Types;

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
                var contracts = db.Contracts;
                return contracts;
            });
        }
    }
}
