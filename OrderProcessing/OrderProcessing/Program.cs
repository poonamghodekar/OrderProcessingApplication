using OrderProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            Console.WriteLine("\n//////////////////////////////////////// \n");
            Console.WriteLine("Place your order for \n");
            Console.WriteLine("******************************** \n");
            Console.WriteLine("1: Product \n" +
                              "2: Membership\n" +
                              "3: Video \n" +
                              "4: Process Orders\n" +
                              "5: Exit\n");

            Console.WriteLine("********************************");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Order has been placed for " + OrderType.PRODUCT + "\n");
                    Console.WriteLine("Please choose which type of order you want to place :\n");
                    Console.WriteLine("1: Physical \n" +
                              "2: Book\n");
                    Console.WriteLine("Enter your choice :");
                    break;
                case 2:
                    Console.WriteLine("Order has been placed for " + OrderType.MEMBERSHIP + "\n");
                    Console.WriteLine("Please choose which type of order you want to place :\n");
                    Console.WriteLine("1: Activate \n" +
                              "2: Upgrade\n");
                    Console.WriteLine("Enter your choice :");
                    break;
                case 3:
                    Console.WriteLine("Order has been placed for " + OrderType.VIDEO + "\n");
                    Console.WriteLine("Please choose which type of order you want to place :\n");
                    Console.WriteLine("1: Learning \n" +
                              "2: Entertainment\n");
                    Console.WriteLine("Enter your choice :");
                    break;
                case 4:
                    ProcessAllOrders();
                    break;
                case 5:
                    Console.WriteLine("You have pressed Exit");
                    break;
                default:
                    break;
            }
        }

        private static void ProcessAllOrders()
        { 
            
        }
    }
}
