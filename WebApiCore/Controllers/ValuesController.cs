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
using WebApiCore.Repositroy;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ValuesController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetTopFiveProducts();
        }        
    }
}
