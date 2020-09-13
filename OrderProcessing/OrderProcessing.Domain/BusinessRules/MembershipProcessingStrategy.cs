using OrderProcessing.Domain.Services;
using OrderProcessing.Models;
using System;

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
            Console.WriteLine("\n\t\t** PROCESSING ORDER ID : {0}\n", membership.OrderId);
            Console.WriteLine("\n\t\t** PROCESSING order placed for {0} membership : ", membership.MembershipType);
            if (membership.MembershipType.Equals(MembershipType.ACTIVATE))
            {
                _orderExecutionService.ActivateMemberShip();
                PrintMemberShipDetails(membership.MembershipDetails);
                _orderExecutionService.SendEmail("Hi, your membership has been activated. Please find attached details. Thank you.\n");
            }
            else
            {
                _orderExecutionService.UpgradeMemberShip();
                PrintMemberShipDetails(membership.MembershipDetails);
                _orderExecutionService.SendEmail("Your membership has been upgraded.Please find attached details.Thank you.\n");
            }
        }

        private void PrintMemberShipDetails(MembershipDetails membershipDetails)
        {
            Console.WriteLine("\t\t*Below are the Membership details : \n");
            Console.WriteLine("\t\t\t\t**MemberName : {0} \n", membershipDetails.MemberName);
            Console.WriteLine("\t\t\t\t**Membership start date : {0} \n", membershipDetails.StartDate.Date);
            Console.WriteLine("\t\t\t\t**Membership end date : {0} \n", membershipDetails.EndDate.Date);
        }
    }
}
