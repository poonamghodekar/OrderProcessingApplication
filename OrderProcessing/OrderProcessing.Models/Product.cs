using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Models
{
    public class Product : IOrder, IProductType
    {
        public Guid OrderId { get; set; }
        public ProductType ProductType { get; set; }
        public ProductDetails ProductDetails { get; set; }
    }
}
