using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Domain.Services
{
    public interface IOrderExecutionService
    {
        void CreatePackingSlip();
        void CreateDuplicateSlip();
        void ActivateMemberShip();
        void UpgradeMemberShip();
        void SendEmail(string message);
        void SendFreeVideo();
        void GenerateAgentCommission();
    }
    class OrderExecutionService : IOrderExecutionService
    {
        public void ActivateMemberShip()
        {
            Console.WriteLine("\n\t\t--> Membership has been activated. Thank you.\n");
        }

        public void CreateDuplicateSlip()
        {
            Console.WriteLine("\n\t\t--> Duplicate slip is generated for Royalty department.\n");
        }

        public void CreatePackingSlip()
        {
            Console.WriteLine("\n\t\t--> Packing slip has been generated for Shipping.\n");
        }

        public void GenerateAgentCommission()
        {
            Console.WriteLine("\n\t\t--> Agent commission has been generated.\n");
        }

        public void SendEmail(string message)
        {
            Console.WriteLine("\n\t\t--> **Email sent. Below are the email contents.**\n");
            Console.WriteLine("\t\t\t\t" + message);
        }

        public void SendFreeVideo()
        {
            Console.WriteLine("\n\t\t--> Free 'First Aid' video has been added.\n");
        }

        public void UpgradeMemberShip()
        {
            Console.WriteLine("\n\t\t-->Membership has been upgraded. Thank you.\n");
        }
    }
}
