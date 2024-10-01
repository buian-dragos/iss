using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSExamen.Models;
using ISSExamen.Database;
using Microsoft.EntityFrameworkCore;

namespace ISSExamen.Controllers
{
    public class OrderController
    {
        private readonly OrderDbContext _dbContext;
        public OrderController(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Order> GetAllOrders()
        {
            return _dbContext.Orders.ToList();
        }
        public void ProcessOrder(Order order)
        {
            try
            {
                order.TotalAmount = CalculateTotalAmount(order);
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();

                if(Environment.GetEnvironmentVariable("LOGGING") == "file")
                {
                    File.AppendAllText("log.txt", "Order processed");
                }
                else
                {
                    throw new Exception("Order processed and added to the database");
                }
            }
            catch(Exception ex)
            {
                if (Environment.GetEnvironmentVariable("LOGGING") == "file")
                {
                    File.AppendAllText("log.txt", "Error");
                }
                else
                {
                    throw ex;
                }
            }
        }
        private decimal CalculateTotalAmount(Order order)
        {
            ProductController productController = new ProductController(_dbContext);
            decimal productPrice = productController.GetProductPrice(order.ProductID);
            decimal discount = 0;
            if(order.Quantity > 10)
            {
                discount = 0.1m * productPrice * order.Quantity;
            }
            decimal tax = 0.05m * productPrice * order.Quantity;

            return (productPrice * order.Quantity) - discount + tax;
        }
    }
}
