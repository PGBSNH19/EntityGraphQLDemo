using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EntityGraphQL;
using EntityGraphQL.Schema;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{

    [Route("api/[controller]")]
    public class QueryController : Controller
    {
        private readonly MyDbContext _dbContext;
        private readonly SchemaProvider<MyDbContext> _schemaProvider;

        public QueryController(MyDbContext dbContext, SchemaProvider<MyDbContext> schemaProvider)
        {
            this._dbContext = dbContext;
            this._schemaProvider = schemaProvider;
            _dbContext.Database.EnsureCreated();
        }

        [HttpPost]
        public object Post([FromBody]QueryRequest query)
        {
            try
            {
                var results = _schemaProvider.ExecuteQuery(query, _dbContext, null, null);
                // gql compile errors show up in results.Errors
                return results;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}