
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Infrastructure.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "varchar(32)")]
        public string Manufactory { get; set; }

        [Required]
        [Column(TypeName = "varchar(16)")]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public string Price { get; set; }

        [Required]
        [Column(TypeName = "varchar(32)")]
        public string ImageUrl { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string Describe { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string AuthStatus { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string ApprovedDate { get; set; }
    }
}
