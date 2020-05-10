
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TMĐT.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PM_ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CARD_OWNER_NAME { get; set; }

        [Required]
        [Column(TypeName = "varchar(16)")]
        public string CARD_NUMBER { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string EXPIRATION_DATE { get; set; }

        [Required]
        [Column(TypeName = "varchar(3)")]
        public string CVV { get; set; }
    }
}
