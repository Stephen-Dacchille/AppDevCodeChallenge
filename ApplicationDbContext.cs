using AppDevCodeChallange1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDevCodeChallange1
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        static ApplicationDbContext()
        {

        }

        public virtual DbSet<City> City { get; set; }

        public virtual DbSet<Country> Country { get; set; }

        public virtual DbSet<CountryLanguage> CountryLanguage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("city", "world");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Population)
                    .IsRequired()
                    .HasColumnName("Population")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("country", "world");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(52)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Continent)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SurfaceArea)
                    .IsRequired()
                    .HasColumnType("float(10,2)");

                entity.Property(e => e.IndepYear)
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Population)
                    .IsRequired()
                    .HasColumnName("Population")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LifeExpectancy)
                    .HasColumnType("float(3,1)");

                entity.Property(e => e.GNP)
                    .HasColumnType("float(10,2)");

                entity.Property(e => e.GNPOld)
                    .HasColumnType("float(10,2)");

                entity.Property(e => e.LocalName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.GovernmentForm)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.HeadOfState)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Capitial)
                    .HasColumnName("Capitial")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code2)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<CountryLanguage>(entity =>
            {
                entity.HasKey(e => e.CountryCode);

                entity.HasKey(e => e.Language);

                entity.ToTable("countrylanguage", "world");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsOfficial)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Percentage)
                    .IsRequired()
                    .HasColumnType("float(4,1)").IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
