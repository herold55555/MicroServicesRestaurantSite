using AutoMapper;
using Restaurant.Services.CouponAPI.Models;
using Restaurant.Services.CouponAPI.Models.DTO;

namespace Restaurant.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();

            });
            return mappingConfig;
        
        
        }
    }
}
