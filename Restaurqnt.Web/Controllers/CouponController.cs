using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Service.IService;

namespace Restaurant.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }


        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? couponDtos = new();

            ResponseDto? response = await _couponService.GetAllCouponsAsync();

            if (response != null && response.IsSuccess) {
                couponDtos = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            
            }

            return View(couponDtos);
        }
    }
}
