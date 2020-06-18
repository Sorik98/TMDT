
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Infrastructure.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        
        public Order Order { get ; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set;}

        [Required]
        public int Quantity { get; set; }
       
        [Required]
        public ICollection<ImageUrl> ImageUrls { get; set; }

       
    }
}
