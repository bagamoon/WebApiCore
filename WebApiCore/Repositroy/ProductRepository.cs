using Dapper;
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
        public Product GetProductById(QueryDto query)
        {
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
            using (var conn = new SqlConnection(WebConfig.NorthwindConnectionString))
            {
                var products = conn.Query<Product>("select top 5 * from Products");
                return products;
            }
        }
    }
}
