
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Infrastructure.Models
{
    public class Product : Auditable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        public int ProducerId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal Price { get; set; }

        [Required]
        public ICollection<ImageUrl> ImageUrls { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Desc { get; set; }

        public Producer Producer { get; set; }
    }
}
