﻿using System;
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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApiCore.DTO;
using WebApiCore.Models;
using WebApiCore.Repositroy;

namespace WebApiCore.Controllers
{    
    [Produces("application/json")]
    [Route("api/bind/[action]")]
    public class BindingController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IProductRepository _productRepository;

        public BindingController(ILogger<AuthController> logger ,IProductRepository productRepository)
        {
            _logger = logger;
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
    }
}