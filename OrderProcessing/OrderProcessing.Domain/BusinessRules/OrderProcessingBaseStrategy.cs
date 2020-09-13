using OrderProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Domain.BusinessRules
{
    /// <summary>
    /// Strategy pattern
    /// </summary>
    public interface IOrderProcessingBaseStrategy
    {
        void ProcessOrder(IOrder order);
    }
}
