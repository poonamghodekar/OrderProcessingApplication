using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Models
{
    public interface IMembershipType
    {
        MembershipType MembershipType { get; set; }
    }
    public enum MembershipType
    {
        ACTIVATE = 1,
        UPGRADE = 2
    }
}
