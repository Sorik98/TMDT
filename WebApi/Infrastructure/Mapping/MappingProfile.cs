
using System;
using System.Collections.Generic;
using WebApi.Const;
using WebApi.Infrastructure.DTOs;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.Mapping
{
    public static class MappingProfile
    {
        public static void SetAuditForDTO(this AuditableDTO dto,Auditable model ){
            dto.CreateBy = model.CreateBy;
            dto.CreateDate = model.CreateDate;
            dto.AuthBy = model.AuthBy;
            dto.AuthDate = model.AuthDate;
            dto.AuthStatus = model.AuthStatus;
            dto.LastUpdateDate = model.LastUpdateDate;
            dto.LastUpdateBy = model.LastUpdateBy;
        }
        public static void SetAuditForCreate(this Auditable model,AuditableDTO dto){
            model.CreateBy = dto.CreateBy;
            model.CreateDate = dto.CreateDate;
            model.AuthStatus = AuthStatus.Submitted;
        }
        public static void SetAuditForUpdate(this Auditable model,AuditableDTO dto){
            model.AuthStatus = AuthStatus.Submitted;
            model.LastUpdateDate = dto.LastUpdateDate;
            model.LastUpdateBy = dto.LastUpdateBy;
        }
        public static void SetAuditForApprove(this Auditable model,AuditableDTO dto){
            model.AuthBy = dto.AuthBy;
            model.AuthDate = dto.AuthDate;
            model.AuthStatus = AuthStatus.Approved;
        }
        public static void SetAuditForReject(this Auditable model,AuditableDTO dto){
            model.AuthBy = dto.AuthBy;
            model.AuthDate = dto.AuthDate;
            model.AuthStatus = AuthStatus.Rejected;
        }
        /* #region  PaymentDetail */
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
        /* #endregion */


        /* #region  Product */
        public static ProductDTO ToDTO(this Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Desc = product.Desc,
               // ImageUrls = new List<ImageUrlDTO>(),
                ImageUrls = new Func<List<ImageUrlDTO>>(() => { 
                    var urls = new List<ImageUrlDTO>();
                    foreach(ImageUrl url in product.ImageUrls)
                    {
                        urls.Add(url.ToDto());
                    }
                    return urls;
                 })(),
                Name = product.Name,
                Price = product.Price,
                ProducerId = product.ProducerId,
                Type = product.Type,
                ProducerName = product.Producer.Name
            };
        }

        public static Product ToProduct(this ProductDTO dto)
        {
            return new Product{
                Id = dto.Id.Value,
                Desc = dto.Desc,
                Name = dto.Name,
                Price = dto.Price,
                ProducerId = dto.ProducerId,
                ImageUrls = new Func<List<ImageUrl>>(() => { 
                    var urls = new List<ImageUrl>();
                    foreach(ImageUrlDTO url in dto.ImageUrls)
                    {
                        urls.Add(url.ToImage());
                    }
                    return urls;
                 })(),
                Type = dto.Type,
            };
        }
        /* #endregion */
       

        public static ImageUrlDTO ToDto(this ImageUrl image)
        {
            return new ImageUrlDTO{
                Url = image.Url
            };
        }
        public static ImageUrl ToImage(this ImageUrlDTO dto){
            return new ImageUrl{
                Url = dto.Url
            };
        }
    }
}