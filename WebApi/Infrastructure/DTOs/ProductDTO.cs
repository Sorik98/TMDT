

using System;
using System.Collections.Generic;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure.DTOs
{
    public class ProductDTO : AuditableDTO
    {
         public int? Id { get; set; }

        public string Name { get; set; }

        public int? ProducerId { get; set; }

        public string Type { get; set; }

        public decimal? Price { get; set; }

        public decimal? OriginalPrice { get; set; }

        public decimal? Sale { get; set; }

        public decimal? Stock { get; set; }

        public decimal? Sold { get; set; }
        public List<ImageUrlDTO> ImageUrls { get; set; }

        public string ShortDesc { get; set; }
        public string Desc { get; set; }

        public string ProducerName { get; set; }

    }
}
