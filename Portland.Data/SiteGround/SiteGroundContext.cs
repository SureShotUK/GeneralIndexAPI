using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PortlandCredentials;

namespace Portland.Data.SiteGround
{
    public partial class SiteGroundContext : DbContext
    {
        public SiteGroundContext()
        {
        }

        public SiteGroundContext(DbContextOptions<SiteGroundContext> options)
            : base(options)
        {
        }


        public virtual DbSet<YGimid> YGimids { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var efclString = new EFCLConnectionString(EfclDatabases.Siteground).GetSitegroundEfclConnectionString();
                optionsBuilder.UseNpgsql(efclString);

               // optionsBuilder.UseNpgsql("Server=35.214.23.143;Database=mikej223_prices;User Id=mikej223_postgres;Password=B0r00v3rL33d5;Port=5432");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<YGimid>(entity =>
            {
                entity.HasKey(e => e.PublishedDate)
                    .HasName("y_gimid_pkey");

                entity.ToTable("y_gimid");

                entity.Property(e => e.PublishedDate).HasColumnName("published_date");

                entity.Property(e => e.Gx0000006).HasColumnName("gx0000006");

                entity.Property(e => e.Gx0000010).HasColumnName("gx0000010");

                entity.Property(e => e.Gx0000015).HasColumnName("gx0000015");

                entity.Property(e => e.Gx0000016).HasColumnName("gx0000016");

                entity.Property(e => e.Gx0000082).HasColumnName("gx0000082");

                entity.Property(e => e.Gx0000084).HasColumnName("gx0000084");

                entity.Property(e => e.Gx0000093).HasColumnName("gx0000093");

                entity.Property(e => e.Gx0000257).HasColumnName("gx0000257");

                entity.Property(e => e.Gx0000258).HasColumnName("gx0000258");

                entity.Property(e => e.Gx0000686).HasColumnName("gx0000686");
            });

            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
