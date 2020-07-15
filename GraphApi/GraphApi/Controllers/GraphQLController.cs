using GraphApi.GraphQLMiddleWare;
using GraphApi.GraphQLMiddleWare.Queries;
using GraphApi.Infraestructure;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GraphApi.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly TrainingContext _trainingContext;

        public GraphQLController(TrainingContext trainingContext)
        {
            _trainingContext = trainingContext;
        }

        // POST api/<GraphQLController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = new ContractQuery(_trainingContext)
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
