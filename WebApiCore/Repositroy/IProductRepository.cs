using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Models;
using static WebApiCore.Controllers.BindingController;

namespace WebApiCore.Repositroy
{
    public interface IProductRepository
    {
        Product GetProductById(QueryDto query);

        IEnumerable<Product> GetTopFiveProducts();
    }
}
