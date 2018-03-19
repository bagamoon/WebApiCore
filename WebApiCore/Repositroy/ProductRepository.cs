using Dapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Controllers;
using WebApiCore.DTO;
using WebApiCore.Models;

namespace WebApiCore.Repositroy
{
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ILogger<ProductRepository> logger)
        {
            _logger = logger;
        }

        public Product GetProductById(QueryDto query)
        {
            _logger.LogDebug($"GetProductById: {JsonConvert.SerializeObject(query)}");

            using (var conn = new SqlConnection(WebConfig.NorthwindConnectionString))
            {
                var product = conn.QueryFirstOrDefault<Product>(
                    "select * from products where ProductId = @productId",
                    new { ProductId = query.ProductId });

                return product;
            }
        }

        public IEnumerable<Product> GetTopFiveProducts()
        {
            _logger.LogDebug("GetTopFiveProducts");

            using (var conn = new SqlConnection(WebConfig.NorthwindConnectionString))
            {
                var products = conn.Query<Product>("select top 5 * from Products");
                return products;
            }
        }
    }
}
