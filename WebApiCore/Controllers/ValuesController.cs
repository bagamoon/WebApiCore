using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            using (var conn = new SqlConnection(WebConfig.NorthwindConnectionString))
            {
                var products = conn.Query<Products>("select top 5 * from Products");
                return products;
            }
        }      
    }
}
