﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GraphApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        // GET: api/<GraphQLController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GraphQLController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GraphQLController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GraphQLController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GraphQLController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
