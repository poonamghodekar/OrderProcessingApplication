using OrderProcessing.Domain.Services;
using OrderProcessing.Models;
using System;

namespace OrderProcessing.Domain.BusinessRules
{
    /// <summary>
    /// VideoRequestProcessingStrategy - for Video requests
    /// </summary>
    public class VideoRequestProcessingStrategy : IOrderProcessingBaseStrategy
    {
        private readonly IOrderExecutionService _orderExecutionService;
        /// <summary>
        /// Injecting dependency through constructor
        /// </summary>
        /// <param name="orderExecutionService"></param>
        public VideoRequestProcessingStrategy(IOrderExecutionService orderExecutionService)
        {
            _orderExecutionService = orderExecutionService;
        }

        /// <summary>
        /// Process video request order
        /// </summary>
        /// <param name="order"></param>
        public void ProcessOrder(IOrder order)
        {
            try
            {
                if (order == null)
                    throw new Exception("Order is null");

                Video video = (Video)order;

                Console.WriteLine("\n\t\t** PROCESSING ORDER ID : {0}\n", video.OrderId);
                Console.WriteLine("\n\t\t** PROCESSING order placed for {0} video : ", video.VideoType);
                if (video.VideoType.Equals(VideoType.LEARNING))
                    _orderExecutionService.SendFreeVideo();

                PrintVideoDetails(video.VideoDetails);
                _orderExecutionService.CreatePackingSlip();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            Console.WriteLine("\n\t\t*********************************************\n");
        }

        /// <summary>
        /// Prints video details
        /// </summary>
        /// <param name="videoDetails"></param>
        private void PrintVideoDetails(VideoDetails videoDetails)
        {
            Console.WriteLine("\t\t*Below are the Video details : \n");
            Console.WriteLine("\t\t\t\t**Name : {0} \n", videoDetails.VideoName);
        }
    }
}
