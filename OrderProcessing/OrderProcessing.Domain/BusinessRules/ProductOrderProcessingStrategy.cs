using OrderProcessing.Domain.Services;
using OrderProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Domain.BusinessRules
{
    public class ProductOrderProcessingStrategy : IOrderProcessingBaseStrategy
    {
        private readonly IOrderExecutionService _orderExecutionService;
        public ProductOrderProcessingStrategy(IOrderExecutionService orderExecutionService)
        {
            _orderExecutionService = orderExecutionService;
        }
        public void ProcessOrder(IOrder order)
        {
            Product product = (Product)order;
            Console.WriteLine("\n\t\t** PROCESSING ORDER ID : {0}\n", product.OrderId);
            Console.WriteLine("\n\t\t** PROCESSING order placed for {0} product type : ", product.ProductType);
            if (product.ProductType.Equals(ProductType.PHYSICAL))
                _orderExecutionService.CreatePackingSlip();
            else
                _orderExecutionService.CreateDuplicateSlip();

            PrintProductDetails(product.ProductDetails);
            _orderExecutionService.GenerateAgentCommission();
        }

        private void PrintProductDetails(ProductDetails productDetails)
        {
            Console.WriteLine("\t\t*Below are the details : \n");
            Console.WriteLine("\t\t\t\t**Name : {0} \n", productDetails.Name);
            Console.WriteLine("\t\t\t\t**Price per unit : {0} \n", productDetails.Price);
            Console.WriteLine("\t\t\t\t**Quantity ordered : {0} \n", productDetails.Quantity);
        }
    }
}
