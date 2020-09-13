using OrderProcessing.Domain.Services;
using OrderProcessing.Models;
using System;

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

            Console.WriteLine("\n\t\t** PROCESSING ORDER ID : {0}\n", video.OrderId);
            Console.WriteLine("\n\t\t** PROCESSING order placed for {0} video : ", video.VideoType);
            if (video.VideoType.Equals(VideoType.LEARNING))
                _orderExecutionService.SendFreeVideo();

            PrintVideoDetails(video.VideoDetails);
            _orderExecutionService.CreatePackingSlip();
        }

        private void PrintVideoDetails(VideoDetails videoDetails)
        {
            Console.WriteLine("\t\t*Below are the Video details : \n");
            Console.WriteLine("\t\t\t\t**Name : {0} \n", videoDetails.VideoName);
        }
    }
}
