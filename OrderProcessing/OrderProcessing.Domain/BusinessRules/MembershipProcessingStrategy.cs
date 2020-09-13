using OrderProcessing.Domain.Services;
using OrderProcessing.Models;

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
            Membership membership = (Membership)order;
            if (membership.MembershipType.Equals(MembershipType.ACTIVATE))
            {
                _orderExecutionService.ActivateMemberShip();
                _orderExecutionService.SendEmail("Hi, your membership has been activated. Please find attached details. Thank you.\n");
            }
            else
            {
                _orderExecutionService.UpgradeMemberShip();
                _orderExecutionService.SendEmail("Your membership has been upgraded.Please find attached details.Thank you.\n");
            }
        }

        private void PrintMembershipDetails() { }
    }
}
