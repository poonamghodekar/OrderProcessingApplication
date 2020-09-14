using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstituteAutoMocker;
using OrderProcessing.Domain.BusinessRules;
using OrderProcessing.Domain.Services;
using OrderProcessing.Models;
using System;

namespace OrderProcessing.UnitTests
{
    [TestClass]
    public class MembershipProcessingStrategyTests
    {
        private readonly NSubstituteAutoMocker<MembershipProcessingStrategy> _autoMocker =
           new NSubstituteAutoMocker<MembershipProcessingStrategy>();
        private MembershipProcessingStrategy _sut;
        private IOrder _order;
        private IOrderExecutionService _orderExecutionService;
        private const string EXCEPTION_MESSAGE = "Order is null";

        [TestInitialize]
        public void Setup()
        {
            _sut = _autoMocker.ClassUnderTest;
            _order = Builder<Membership>.CreateNew()
                            .With(o => o.MembershipType = MembershipType.ACTIVATE)
                            .With(o => o.MembershipDetails = Builder<MembershipDetails>.CreateNew().Build())
                            .With(o => o.OrderId = Guid.NewGuid())
                            .Build();
            _orderExecutionService = _autoMocker.Get<IOrderExecutionService>();
        }

        [TestMethod]
        public void OrderPlaced_BookType_OrderProcessedSuccessfully()
        {
            //arrange
            _sut.ProcessOrder(_order);

            //assert
            _orderExecutionService.Received(1);
        }

        [TestMethod]
        public void OrderPlaced_OrderIsNull_ThrowsException()
        {
            //arrange
            try
            {
                _order = null;
                _sut.ProcessOrder(_order);
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {
                //assert
                _orderExecutionService.Received(0);
                Assert.IsTrue(ex.Message is EXCEPTION_MESSAGE);
            }
        }
    }
}
