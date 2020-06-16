using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Infrastructure.Models{
public class Auditable{

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string AuthStatus { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime CreateDate { get; set; }        

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CreateBy { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? AuthDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string AuthBy { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? LastUpdateDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string LastUpdateBy { get; set; }

}
}