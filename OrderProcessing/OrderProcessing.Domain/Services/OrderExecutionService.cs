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
            throw new NotImplementedException();
        }

        public void CreateDuplicateSlip()
        {
            throw new NotImplementedException();
        }

        public void CreatePackingSlip()
        {
            throw new NotImplementedException();
        }

        public void GenerateAgentCommission()
        {
            throw new NotImplementedException();
        }

        public void SendEmail(string message)
        {
            throw new NotImplementedException();
        }

        public void SendFreeVideo()
        {
            throw new NotImplementedException();
        }

        public void UpgradeMemberShip()
        {
            throw new NotImplementedException();
        }
    }
}
