
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Infrastructure.Models
{
    public class Order 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime CreateDate { get; set; }  

        
        [Column(TypeName = "DateTime2")]
        public DateTime? CompleteDate { get; set; }  
        
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string ReceiverName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string ReceiverAddress { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string ReceiverPhone { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Status { get; set; }



        [Required]
        public ICollection<OrderDetail> OrderDetails { get; set; }

       
    }
}
