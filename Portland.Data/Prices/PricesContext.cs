using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PortlandCredentials;

namespace Portland.Data.Prices
{
    public partial class PricesContext : DbContext
    {
        public PricesContext()
        {
        }

        public PricesContext(DbContextOptions<PricesContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<YGimid> YGimids { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var efclString = new PortlandCredentials.EFCLConnectionString().GetEfclConnectionString();
                //optionsBuilder.UseNpgsql("Server=81.143.215.110;Database=prices;User Id=it;Password=Th1s1s4R34llyL0ngP4ssw0rdT0Mk3Th!5R34llyH4rdF0rS0m30n3T0H4ck;Port=59734");
                optionsBuilder.UseNpgsql(efclString);
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
