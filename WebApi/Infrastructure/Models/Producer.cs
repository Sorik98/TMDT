using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Infrastructure.Models
{
    public class Producer : Auditable
    {
        [Key]
        public int ProducerId { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Desc { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}