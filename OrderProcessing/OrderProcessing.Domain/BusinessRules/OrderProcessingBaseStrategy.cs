using OrderProcessing.Models;

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
