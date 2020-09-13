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
            if (product.ProductType.Equals(ProductType.PHYSICAL))
                _orderExecutionService.CreatePackingSlip();
            else
                _orderExecutionService.CreateDuplicateSlip();

            PrintProductDetails();
            _orderExecutionService.GenerateAgentCommission();
        }

        private void PrintProductDetails() { }
    }
}
