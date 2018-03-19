using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.DTO;
using WebApiCore.Models;

namespace WebApiCore.Repositroy
{
    public interface IProductRepository
    {
        Product GetProductById(QueryDto query);

        IEnumerable<Product> GetTopFiveProducts();
    }
}
