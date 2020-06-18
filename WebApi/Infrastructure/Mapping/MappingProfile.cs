
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
            model.CreateDate = DateTime.Now;
            model.AuthStatus = AuthStatus.Submitted;
        }
        public static void SetAuditForUpdate(this Auditable model,AuditableDTO dto){
            model.CreateBy = dto.CreateBy;
            model.CreateDate = dto.CreateDate.Value;
            model.AuthBy = dto.AuthBy;
            model.AuthDate = dto.AuthDate.HasValue?dto.AuthDate.Value : (DateTime?) null;
            model.AuthStatus = AuthStatus.Submitted;
            model.LastUpdateDate = DateTime.Now;
            model.LastUpdateBy = dto.LastUpdateBy;
        }
        public static void SetAuditForApprove(this Auditable model,AuditableDTO dto){
            model.CreateBy = dto.CreateBy;
            model.CreateDate = dto.CreateDate.Value;
            model.LastUpdateDate = dto.LastUpdateDate.HasValue?dto.LastUpdateDate.Value : (DateTime?) null;
            model.LastUpdateBy = dto.LastUpdateBy;
            model.AuthBy = dto.AuthBy;
            model.AuthDate = DateTime.Now;
            model.AuthStatus = AuthStatus.Approved;
        }
        public static void SetAuditForReject(this Auditable model,AuditableDTO dto){
            model.CreateBy = dto.CreateBy;
            model.CreateDate = dto.CreateDate.Value;
            model.LastUpdateDate = dto.LastUpdateDate.HasValue?dto.LastUpdateDate.Value : (DateTime?) null;
            model.LastUpdateBy = dto.LastUpdateBy;
            model.AuthBy = dto.AuthBy;
            model.AuthDate = DateTime.Now;
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
                ShortDesc = product.ShortDesc,
                Desc = product.Desc,
                ImageUrls = new Func<List<ImageUrlDTO>>(() => { 
                    var urls = new List<ImageUrlDTO>();
                    if(product.ImageUrls != null)
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
                ProducerName = product.Producer.Name,
                OriginalPrice = product.OriginalPrice,
                Sale = product.Sale,
                Stock = product.Stock,
                Sold = product.Sold
            };
        }

        public static Product ToProduct(this ProductDTO dto)
        {
            return new Product{
                Id = dto.Id.HasValue ? dto.Id.Value : 0,
                ShortDesc = dto.ShortDesc,
                Desc = dto.Desc,
                Name= dto.Name,
                ProducerId = dto.ProducerId.Value,
                ImageUrls = new Func<List<ImageUrl>>(() => { 
                    var urls = new List<ImageUrl>();
                    if(dto.ImageUrls != null)
                    foreach(ImageUrlDTO url in dto.ImageUrls)
                    {
                        urls.Add(url.ToImage());
                    }
                    return urls;
                 })(),
                Type = dto.Type,
                OriginalPrice = dto.OriginalPrice.Value,
                Price = Math.Round(dto.OriginalPrice.Value - (dto.OriginalPrice.Value * dto.Sale.Value / 100)),
                Sale = dto.Sale.Value,
                Stock = dto.Stock.Value
            };
        }
        /* #endregion */
       
       /* #region  Producer */
        public static ProducerDTO ToDTO(this Producer producer)
        {
            return new ProducerDTO
            {
                ProducerId = producer.ProducerId,
                
                Desc = producer.Desc,
                Products = new Func<List<ProductDTO>>(() => { 
                    var list = new List<ProductDTO>();
                    if(producer.Products != null)
                    foreach(Product product in producer.Products)
                    {
                        list.Add(product.ToDTO());
                    }
                    return list;
                 })(),
                Name = producer.Name,
            };
        }

         public static Producer ToProducer(this ProducerDTO dto)
        {
            return new Producer
            {
                ProducerId = dto.ProducerId.HasValue? dto.ProducerId.Value : 0,
                
                Desc = dto.Desc,
               // ImageUrls = new List<ImageUrlDTO>(),
                Products = new Func<List<Product>>(() => { 
                    var list = new List<Product>();
                    if(dto.Products != null)
                    foreach(ProductDTO product in dto.Products)
                    {
                        list.Add(product.ToProduct());
                    }
                    return list;
                 })(),
                Name = dto.Name,
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