using System;

namespace WebApi.Infrastructure.DTOs{
    public class CartItemDTO{
         public int? Id { get; set; }

 
        public string UserId { get; set; }


        public ProductDTO Product { get; set;}


        public int? Quantity { get; set; }

    }
}