using AutoMapper;
using Discount.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discount.Grpc.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
 