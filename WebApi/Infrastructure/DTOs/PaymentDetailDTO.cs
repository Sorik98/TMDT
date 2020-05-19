

namespace WebApi.Infrastructure.DTOs
{
    public class PaymentDetailDTO
    {
        public int PaymentId { get; set; }
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
    }
}
