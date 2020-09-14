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
    public class VideoRequestProcessingStrategyTests
    {
        private readonly NSubstituteAutoMocker<VideoRequestProcessingStrategy> _autoMocker =
           new NSubstituteAutoMocker<VideoRequestProcessingStrategy>();
        private VideoRequestProcessingStrategy _sut;
        private IOrder _order;
        private IOrderExecutionService _orderExecutionService;
        private const string EXCEPTION_MESSAGE = "Order is null";

        [TestInitialize]
        public void Setup()
        {
            _sut = _autoMocker.ClassUnderTest;
            _order = Builder<Video>.CreateNew()
                                .With(o => o.VideoType = VideoType.LEARNING)
                                .With(o => o.VideoDetails = Builder<VideoDetails>.CreateNew().Build())
                                .With(o => o.VideoDetails.VideoName = "Learning to Ski")
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
