using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Models
{
    public interface IVideoType
    {
        VideoType VideoType { get; set; }
    }
    public enum VideoType
    {
        LEARNING = 1,
        ENTERTAINMENT = 2
    }
}
