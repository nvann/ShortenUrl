namespace ShortenUrlService.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShortenUrlContext : DbContext
    {
        public ShortenUrlContext()
            : base("name=ShortenUrlContext")
        {
        }

        public virtual DbSet<ShortenUrl> ShortenUrls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenUrl>()
                .Property(e => e.Hash)
                .IsUnicode(false);

            modelBuilder.Entity<ShortenUrl>()
                .Property(e => e.OriginUrl)
                .IsUnicode(false);
        }
    }
}
