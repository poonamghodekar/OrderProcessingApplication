using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Models
{
    public class Membership : IOrder, IMembershipType
    {
        public Guid OrderId { get; set; }
        public MembershipDetails MembershipDetails { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}
