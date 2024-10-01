using ISSExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISSExamen.View
{
    public class ProgramView
    {
        public static Order ReadOrder()
        {
            Console.WriteLine("Enter customer ID:");
            string customerId = Console.ReadLine();
            if(!Regex.IsMatch(customerId, "[0-9]"))
            {
                throw new Exception("Invalid customer ID");
            }
            Console.WriteLine("Enter product ID:");
            if(!int.TryParse(Console.ReadLine(), out int productId))
            {
                throw new Exception("Invalid product ID");
            }
            Console.WriteLine("Enter quantity:");
            if(!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0 || quantity > 100)
            {
                throw new Exception("Invalid quantity");
            }
            Order order = new Order { CustomerID = customerId, ProductID = productId, Quantity = quantity};
            return order;
        }
        public static void DisplayOrders(List<Order> orders)
        {
            foreach(var order in orders)
            {
                Console.WriteLine($"{order.OrderID} {order.CustomerID} {order.ProductID} {order.Quantity} {order.TotalAmount}");
            }
        }
    }
}
