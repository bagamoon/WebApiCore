using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApiCore.Models;
using WebApiCore.Repositroy;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IProductRepository _productRepository;

        public ValuesController(ILogger<ValuesController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            _logger.LogInformation("Get was called");
            return _productRepository.GetTopFiveProducts();
        }        
    }
}
