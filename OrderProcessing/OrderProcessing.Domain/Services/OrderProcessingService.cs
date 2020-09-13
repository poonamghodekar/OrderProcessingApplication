using OrderProcessing.Domain.BusinessRules;
using OrderProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Domain.Services
{
    public class OrderProcessingService
    {
        private IOrderProcessingBaseStrategy _orderProcessingBaseStrategy;
        public void SetOrderProcessingStrategy(IOrderProcessingBaseStrategy orderProcessingBaseStrategy)
        {
            _orderProcessingBaseStrategy = orderProcessingBaseStrategy;
        }

        public void ProcessOrder(IOrder order)
        {
            _orderProcessingBaseStrategy.ProcessOrder(order);
        }
    }
}
