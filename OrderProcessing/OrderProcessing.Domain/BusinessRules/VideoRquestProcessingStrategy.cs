using OrderProcessing.Domain.Services;
using OrderProcessing.Models;

namespace OrderProcessing.Domain.BusinessRules
{
    public class VideoRquestProcessingStrategy : IOrderProcessingBaseStrategy
    {
        private readonly IOrderExecutionService _orderExecutionService;
        public VideoRquestProcessingStrategy(IOrderExecutionService orderExecutionService)
        {
            _orderExecutionService = orderExecutionService;
        }
        public void ProcessOrder(IOrder order)
        {
            Video video = (Video)order;

            if (video.VideoType.Equals(VideoType.LEARNING))
                _orderExecutionService.SendFreeVideo();
            PrintVideoDetails();
            _orderExecutionService.CreatePackingSlip();
        }

        private void PrintVideoDetails() { }
    }
}
