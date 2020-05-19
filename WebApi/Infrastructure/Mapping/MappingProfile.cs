
using WebApi.Infrastructure.DTOs;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Mapping
{
    public static class MappingProfile
    {
        public static PaymentDetailDTO ToDTO(this PaymentDetail PaymentDetail)
        {
            return new PaymentDetailDTO
            {
                PaymentId = PaymentDetail.PaymentId,
                CardOwnerName = PaymentDetail.CardOwnerName,
                CardNumber = PaymentDetail.CardNumber,
                ExpirationDate = PaymentDetail.ExpirationDate,
                CVV = PaymentDetail.CVV
            };
        }

        public static PaymentDetail ToPaymentDetail(this PaymentDetailDTO PaymentDetailDTO)
        {
            return new PaymentDetail
            {
                PaymentId = PaymentDetailDTO.PaymentId,
                CardOwnerName = PaymentDetailDTO.CardOwnerName,
                CardNumber = PaymentDetailDTO.CardNumber,
                ExpirationDate = PaymentDetailDTO.ExpirationDate,
                CVV = PaymentDetailDTO.CVV
            };
        }

        public static void MapTo(this PaymentDetailDTO PaymentDetailDTO, PaymentDetail PaymentDetail)
        {
                PaymentDetail.PaymentId = PaymentDetailDTO.PaymentId;
                PaymentDetail.CardOwnerName = PaymentDetailDTO.CardOwnerName;
                PaymentDetail.CardNumber = PaymentDetailDTO.CardNumber;
                PaymentDetail.ExpirationDate = PaymentDetailDTO.ExpirationDate;
                PaymentDetail.CVV = PaymentDetailDTO.CVV;
        }
    }
}