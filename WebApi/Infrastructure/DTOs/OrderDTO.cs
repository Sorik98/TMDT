using System;
using System.Collections.Generic;


namespace WebApi.Infrastructure.DTOs{
    public class OrderDTO{
        
        public int? Id { get; set; }

        public string UserId { get; set; }

        
        public DateTime? CreateDate { get; set; }  

       
        public DateTime? CompleteDate { get; set; }  
        
        
        public string ReceiverName { get; set; }

       
        public string ReceiverAddress { get; set; }

        
        public string ReceiverPhone { get; set; }

        
        public string Status { get; set; }



        public List<OrderDetailDTO> OrderDetails { get; set; }

    }
}