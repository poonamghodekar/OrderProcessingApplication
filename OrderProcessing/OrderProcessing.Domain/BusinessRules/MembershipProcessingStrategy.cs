using OrderProcessing.Domain.Services;
using OrderProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Domain.BusinessRules
{
    public class MembershipProcessingStrategy : IOrderProcessingBaseStrategy
    {
        private readonly IOrderExecutionService _orderExecutionService;
        public MembershipProcessingStrategy(IOrderExecutionService orderExecutionService)
        {
            _orderExecutionService = orderExecutionService;
        }
        public void ProcessOrder(IOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
