using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Infrastructure.Models {

    public class ImageUrl{
        public int Id { get; set;}
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName="nvarchar(100)")]
        public string Url {get;set;}

        public Product Product { get ; set; }

    }
}