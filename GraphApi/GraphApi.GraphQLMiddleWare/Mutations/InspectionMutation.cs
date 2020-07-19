using GraphApi.GraphQLMiddleWare.Types;
using GraphApi.Infraestructure.Entities;
using GraphApi.Infraestructure.IRepositories;
using GraphQL;
using GraphQL.Types;

namespace GraphApi.GraphQLMiddleWare.Mutations
{
    public class InspectionMutation : ObjectGraphType
    {
        public InspectionMutation(IInspectionRepository inspectionRepository)
        {
            Field<InspectionType>(
            "CreateInspection",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<InspectionInputType>> { Name = "newInspection", Description = "New contract to be added" }),
            resolve: context =>
            {
                var contract = context.GetArgument<Inspection>("newInspection");
                return inspectionRepository.Create(contract);
            });
        }
    }
}
