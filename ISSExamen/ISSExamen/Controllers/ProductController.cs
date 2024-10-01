using ISSExamen.Database;
using ISSExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSExamen.Controllers
{
    public class ProductController
    {
        private readonly OrderDbContext _dbContext;
        public ProductController(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public decimal GetProductPrice(int productId)
        {
            Product product = new Product();
            try
            {
                product = _dbContext.Products.First(p => p.ProductId == productId);
            }
            catch(Exception ex)
            {
                if (Environment.GetEnvironmentVariable("LOGGING") == "file")
                {
                    File.AppendAllText("log.txt", ex.Message);
                }
            }
            return product.Price;
        }
    }
}
