using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Models
{
    public interface IProductType
    {
        ProductType ProductType { get; set; }
    }
    public enum ProductType
    {
        PHYSICAL = 1,
        BOOK = 2
    }
}
