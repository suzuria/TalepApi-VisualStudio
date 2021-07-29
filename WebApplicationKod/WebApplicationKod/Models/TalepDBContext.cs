using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplicationKod.Models
{
    public partial class TalepDBContext : DbContext
    {
        public TalepDBContext()
        {
        }

        public TalepDBContext(DbContextOptions<TalepDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Birim> Birim { get; set; }
        public virtual DbSet<Gonderi> Gonderi { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= DESKTOP-2CMD738;Database=TalepDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Birim>(entity =>
            {
                entity.HasKey(e => e.BirimKodu);

                entity.Property(e => e.BirimKodu).HasMaxLength(3);

                entity.Property(e => e.BirimAd)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gonderi>(entity =>
            {
                entity.HasKey(e => e.GonderiNo);

                entity.Property(e => e.GonderiNo).HasMaxLength(50);

                entity.Property(e => e.Tarih).HasColumnType("smalldatetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Gonderi)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gonderi_Kullanici");
            });

            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BirimKod)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Eposta)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RolKodu)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Sifre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Soyad).HasMaxLength(50);

                entity.HasOne(d => d.BirimKodNavigation)
                    .WithMany(p => p.Kullanici)
                    .HasForeignKey(d => d.BirimKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kullanici_Birim");

                entity.HasOne(d => d.RolKoduNavigation)
                    .WithMany(p => p.Kullanici)
                    .HasForeignKey(d => d.RolKodu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kullanici_Rol");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.RolKodu);

                entity.Property(e => e.RolKodu).HasMaxLength(3);

                entity.Property(e => e.RolAdı)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
