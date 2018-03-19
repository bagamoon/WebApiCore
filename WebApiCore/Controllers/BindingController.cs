using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiCore.Models;
using WebApiCore.Repositroy;

namespace WebApiCore.Controllers
{    
    [Produces("application/json")]
    [Route("api/bind/[action]")]
    public class BindingController : Controller
    {
        private readonly IProductRepository _productRepository;

        public BindingController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("hello world");
        }        

        [Authorize]
        [HttpPost]
        public Product QueryProducts([FromBody]QueryDto query)
        {
            return _productRepository.GetProductById(query);
        }

        [HttpPost]
        public IEnumerable<QueryDto> PassListParam([FromBody]QueryCollection collection)
        {
            return collection.Queries;
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