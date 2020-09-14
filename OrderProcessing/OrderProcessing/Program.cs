using OrderProcessing.Domain.BusinessRules;
using OrderProcessing.Domain.Services;
using OrderProcessing.Models;
using System;
using System.Collections.Generic;

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
                        ProcessAllOrders(orders);
                        break;
                    case 5:
                        Console.WriteLine("You have pressed Exit");
                        break;
                    default:
                        break;
                }
            } while (option != 5);
        }

        private static void ProcessAllOrders(IDictionary<Guid, IOrder> orders)
        {
            OrderProcessingService orderProcessingService = new OrderProcessingService();
            IOrderExecutionService orderExecutionService = new OrderExecutionService();
            MembershipProcessingStrategy membershipProcessingStrategy = new MembershipProcessingStrategy(orderExecutionService);
            ProductOrderProcessingStrategy productOrderProcessingStrategy = new ProductOrderProcessingStrategy(orderExecutionService);
            VideoRequestProcessingStrategy videoRquestProcessingStrategy = new VideoRequestProcessingStrategy(orderExecutionService);

            Console.WriteLine("\n\t\t---------------------------------------------\n");
            Console.WriteLine("\n\t\t*********************************************\n");
            Console.WriteLine("\n\t\t* PROCESSING ALL THE PLACED ORDERS *\n");
            try
            {
                foreach (KeyValuePair<Guid, IOrder> kvp in orders)
                {
                    string name = kvp.Value.GetType().Name.ToUpper();
                    switch ((OrderType)Enum.Parse(typeof(OrderType), name))
                    {
                        case OrderType.MEMBERSHIP:
                            orderProcessingService.SetOrderProcessingStrategy(membershipProcessingStrategy);
                            orderProcessingService.ProcessOrder(kvp.Value);
                            break;
                        case OrderType.PRODUCT:
                            orderProcessingService.SetOrderProcessingStrategy(productOrderProcessingStrategy);
                            orderProcessingService.ProcessOrder(kvp.Value);
                            break;
                        case OrderType.VIDEO:
                            orderProcessingService.SetOrderProcessingStrategy(videoRquestProcessingStrategy);
                            orderProcessingService.ProcessOrder(kvp.Value);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n\t\t*********************************************\n");
            Console.WriteLine("\n\t\t---------------------------------------------\n");
            Console.WriteLine("\n\t\t* ALL ORDERS HAS BEEN PROCESSED *\n");
        }
    }
}
