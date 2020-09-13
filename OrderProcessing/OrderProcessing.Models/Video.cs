using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Models
{
    public class Video : IOrder, IVideoType
    {
        public Guid OrderId { get; set; }
        public VideoType VideoType { get; set; }
        public VideoDetails VideoDetails { get; set; }
    }
}
