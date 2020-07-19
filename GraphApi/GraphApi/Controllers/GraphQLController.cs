using GraphApi.GraphQLMiddleWare;
using GraphApi.GraphQLMiddleWare.Mutations;
using GraphApi.GraphQLMiddleWare.Queries;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GraphApi.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public GraphQLController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // POST api/<GraphQLController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (string.IsNullOrEmpty(query.OperationName))
                return BadRequest("Please, try to add the operation name: query OperationName {...}");

            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = (IObjectGraphType)_serviceProvider.GetService(GetQueryType(query.OperationName)),
                Mutation = (IObjectGraphType)_serviceProvider.GetService(GetMutationType(query.OperationName))
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }

        #region Private Methods

        private Type GetQueryType(string operationName)
        {
            if (operationName.Contains("contract", StringComparison.InvariantCultureIgnoreCase))
                return typeof(ContractQuery);
            else if (operationName.Contains("operation", StringComparison.InvariantCultureIgnoreCase))
                return typeof(OperationQuery);
            else if (operationName.Contains("inspection", StringComparison.InvariantCultureIgnoreCase))
                return typeof(InspectionQuery);
            else
                throw new Exception("You should add and operation name");
        }

        private Type GetMutationType(string operationName)
        {
            if (operationName.Contains("contract", StringComparison.InvariantCultureIgnoreCase))
                return typeof(ContractMutation);
            else if (operationName.Contains("operation", StringComparison.InvariantCultureIgnoreCase))
                return typeof(OperationMutation);
            else if (operationName.Contains("inspection", StringComparison.InvariantCultureIgnoreCase))
                return typeof(InspectionMutation);
            else
                throw new Exception("You should add and operation name");
        }
        #endregion
    }
}
