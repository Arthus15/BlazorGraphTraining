using GraphApi.GraphQLMiddleWare.Types;
using GraphApi.Infraestructure;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApi.GraphQLMiddleWare.Queries
{
    public class InspectionQuery: ObjectGraphType
    {
        public InspectionQuery(TrainingContext db)
        {
            Field<ListGraphType<InspectionType>>(
            "Inspections",
            resolve: context =>
            {
                var inspections = db.Inspections;
                return inspections;
            });

            Field<InspectionType>(
            "Contract",
            arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "Id", Description = "The Id of the Inspection." }),
            resolve: context =>
            {
                var id = context.GetArgument<Guid>("Id");
                var inspection = db.Inspections;
                return inspection;
            });
        }
    }
}
