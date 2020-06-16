using System;

namespace WebApi.Infrastructure.DTOs{
    public class AuditableDTO{
         public string AuthStatus { get; set; }

        public DateTime CreateDate { get; set; }        
 
        public string CreateBy { get; set; }

        public DateTime? AuthDate { get; set; }

        public string AuthBy { get; set; }
        
        public DateTime? LastUpdateDate { get; set; }

        public string LastUpdateBy { get; set; }

    }
}