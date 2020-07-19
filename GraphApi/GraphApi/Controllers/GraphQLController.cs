using GraphApi.GraphQLMiddleWare;
using GraphApi.GraphQLMiddleWare.Mutations;
using GraphApi.GraphQLMiddleWare.Queries;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = _serviceProvider.GetService<ContractQuery>(),
                Mutation = _serviceProvider.GetService<ContractMutation>()
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
                return BadRequest();
            }

            return Ok(result.Data);
        }
    }
}
