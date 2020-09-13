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
    public class ProductOrderProcessingStrategyTests
    {
        private readonly NSubstituteAutoMocker<ProductOrderProcessingStrategy> _autoMocker =
            new NSubstituteAutoMocker<ProductOrderProcessingStrategy>();
        private ProductOrderProcessingStrategy _sut;
        private IOrder _order;
        private IOrderExecutionService _orderExecutionService;
        private const string EXCEPTION_MESSAGE = "Order is null";

        [TestInitialize]
        public void Setup()
        {
            _sut = _autoMocker.ClassUnderTest;
            _order = Builder<Product>.CreateNew()
                                .With(o => o.ProductType = ProductType.BOOK)
                                .With(o => o.ProductDetails = Builder<ProductDetails>.CreateNew().Build())
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
        public void OrderPlaced_NullOrder_ThrowsException()
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
