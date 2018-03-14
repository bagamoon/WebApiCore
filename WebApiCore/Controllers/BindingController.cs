using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/bind/[action]")]
    public class BindingController : Controller
    {
        public IActionResult Index()
        {
            return Ok("hello world");
        }        

        [HttpPost]
        public Products QueryProducts([FromBody]QueryDto query)
        {
            using (var conn = new SqlConnection(WebConfig.NorthwindConnectionString))
            {                
                var product = conn.QueryFirstOrDefault<Products>(
                    "select * from products where ProductId = @productId", 
                    new { ProductId = query.ProductId });

                return product;
            }
        }

        public class QueryDto
        {
            public int ProductId { get; set; }

            public string ProductName { get; set; }
        }

        public class QueryCollection
        {
            public List<QueryDto> Queries { get; set; }
        }
    }
}