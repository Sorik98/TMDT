using System;
using System.Collections.Generic;


namespace WebApi.Infrastructure.DTOs{
    public class OrderDetailDTO{
      
        public int? Id { get; set; }

        public int? OrderId { get; set; }
        

        public int? ProductId { get; set; }

        public ProductDTO Product { get; set;}

        public string ProductName {get;set;}

        public ImageUrlDTO Image {get;set;}



        public int? Quantity { get; set; }
       

       
    }
}
