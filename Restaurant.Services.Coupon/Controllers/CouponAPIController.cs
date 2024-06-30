using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.CouponAPI.Data;
using Restaurant.Services.CouponAPI.Models;
using Restaurant.Services.CouponAPI.Models.DTO;

namespace Restaurant.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public CouponAPIController(AppDbContext db, IMapper mapper) { 
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get() {

            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch (Exception ex) { 
                _response.IsSuccess = false;
                _response.Messqge = ex.Message;
            
            }
            return _response;

        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {

            try
            {
                Coupon coupon = _db.Coupons.First(x => x.Id == id);
                
                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Messqge = ex.Message;

            }
            return _response;

        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {

            try
            {
                Coupon coupon = _db.Coupons.First(x => x.Code.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Messqge = ex.Message;

            }
            return _response;

        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {

            try
            {
                
                Coupon coupon = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(coupon);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Messqge = ex.Message;

            }
            return _response;

        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {

            try
            {

                Coupon coupon = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(coupon);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Messqge = ex.Message;

            }
            return _response;

        }

        [HttpDelete]
        public ResponseDto Delete(int id)
        {

            try
            {

                Coupon coupon = _db.Coupons.First(x=> x.Id == id);
                _db.Coupons.Remove(coupon);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Messqge = ex.Message;

            }
            return _response;

        }
    }
}
