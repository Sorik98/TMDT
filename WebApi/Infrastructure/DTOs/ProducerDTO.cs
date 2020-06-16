

using System;
using System.Collections.Generic;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.DTOs
{
    public class ProducerDTO : AuditableDTO
    {
        public int? ProducerId { get; set; }
        
        public string Name { get; set; }

        public string Desc { get; set; }
        
        public List<ProductDTO> Products { get; set; }

    }
}
