using OrderProcessing.Domain.Services;
using OrderProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Domain.BusinessRules
{
    public class VideoRquestProcessingStrategy : IOrderProcessingBaseStrategy
    {
        private readonly IOrderExecutionService _orderExecutionService;
        public VideoRquestProcessingStrategy(IOrderExecutionService orderExecutionService)
        {
            _orderExecutionService = orderExecutionService;
        }
        public void ProcessOrder(IOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
