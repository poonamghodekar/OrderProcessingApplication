using FizzWare.NBuilder;
using OrderProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class OrderBuilder
    {
        public Membership GetMembership(MembershipType membershipType)
        {
            return Builder<Membership>.CreateNew()
                            .With(o => o.MembershipType = membershipType)
                            .With(o => o.MembershipDetails = Builder<MembershipDetails>.CreateNew().Build())
                            .With(o => o.OrderId = Guid.NewGuid())
                            .Build();
        }

        public Product GetProduct(ProductType productType)
        {
            return Builder<Product>.CreateNew()
                                .With(o => o.ProductType = productType)
                                .With(o => o.ProductDetails = Builder<ProductDetails>.CreateNew().Build())
                                .With(o => o.OrderId = Guid.NewGuid())
                                .Build();
        }

        public Video GetVideo(VideoType videoType)
        {
            return Builder<Video>.CreateNew()
                                .With(o => o.VideoType = videoType)
                                .With(o => o.VideoDetails = Builder<VideoDetails>.CreateNew().Build())
                                .With(o => o.VideoDetails.VideoName = "Learning to Ski")
                                .With(o => o.OrderId = Guid.NewGuid())
                                .Build();
        }
    }
}