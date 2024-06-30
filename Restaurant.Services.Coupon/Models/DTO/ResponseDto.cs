namespace Restaurant.Services.CouponAPI.Models.DTO
{
    public class ResponseDto
    {
        public Object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Messqge { get; set; }
    }
}
