using ISSExamen.Controllers;
using ISSExamen.Database;
using ISSExamen.Models;
using ISSExamen.View;

namespace ISSExamen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderDbContext orderDbContext = new OrderDbContext();
            OrderController orderController = new OrderController(orderDbContext);
            ProductController productController = new ProductController(orderDbContext);

            Console.WriteLine("Order Processing System");

            while(true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Process Order");
                Console.WriteLine("2. Get Orders");
                Console.WriteLine("3. Exit");
                string choice = Console.ReadLine();

                try
                {
                    if (choice == "1")
                    {
                        Order order = ProgramView.ReadOrder();
                        orderController.ProcessOrder(order);
                    }
                    else if (choice == "2")
                    {
                        List<Order> orders = orderController.GetAllOrders();
                        ProgramView.DisplayOrders(orders);
                    }
                    else if (choice == "3")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
