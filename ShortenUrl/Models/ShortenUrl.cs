namespace ShortenUrlService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShortenUrl")]
    public partial class ShortenUrl
    {
        public long Id { get; set; }

        [StringLength(6)]
        public string Hash { get; set; }

        [Required]
        [StringLength(1000)]
        public string OriginUrl { get; set; }

        public String LongHash { get; set; }
    }
}
