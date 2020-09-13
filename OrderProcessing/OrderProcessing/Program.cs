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
            OrderBuilder orderBuilder = new OrderBuilder();
            IDictionary<Guid, IOrder> orders = new Dictionary<Guid, IOrder>();
            do
            {
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
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                Console.WriteLine("Order has been placed for Physical Product\n ");
                                orders.Add(Guid.NewGuid(), orderBuilder.GetProduct(ProductType.PHYSICAL));
                                break;

                            case 2:
                                Console.WriteLine("Order has been placed for Book\n");
                                orders.Add(Guid.NewGuid(), orderBuilder.GetProduct(ProductType.BOOK));
                                break;

                            default: break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Order has been placed for " + OrderType.MEMBERSHIP + "\n");
                        Console.WriteLine("Please choose which type of order you want to place :\n");
                        Console.WriteLine("1: Activate \n" +
                                  "2: Upgrade\n");
                        Console.WriteLine("Enter your choice :");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                Console.WriteLine("Order placed for Activation of Membership \n");
                                orders.Add(Guid.NewGuid(), orderBuilder.GetMembership(MembershipType.ACTIVATE));
                                break;

                            case 2:
                                Console.WriteLine("Order placed for Upgradation of Membership\n");
                                orders.Add(Guid.NewGuid(), orderBuilder.GetMembership(MembershipType.UPGRADE));
                                break;

                            default: break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Order has been placed for " + OrderType.VIDEO + "\n");
                        Console.WriteLine("Please choose which type of order you want to place :\n");
                        Console.WriteLine("1: Learning \n" +
                                  "2: Entertainment\n");
                        Console.WriteLine("Enter your choice :");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                Console.WriteLine("Order placed for Learning to Ski video ");
                                orders.Add(Guid.NewGuid(), orderBuilder.GetVideo(VideoType.LEARNING));
                                break;

                            case 2:
                                Console.WriteLine("Order placed for Entertainment video");
                                orders.Add(Guid.NewGuid(), orderBuilder.GetVideo(VideoType.ENTERTAINMENT));
                                break;

                            default: break;
                        }
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
            } while ((option > 0 && option <= 4) || option != 5);
        }

        private static void ProcessAllOrders()
        { 
            
        }
    }
}
