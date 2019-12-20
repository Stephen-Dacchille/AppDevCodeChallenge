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
        private readonly string _connectionString;

        public virtual DbSet<City> City { get; set; }

        public virtual DbSet<Country> Country { get; set; }

        public virtual DbSet<CountryLanguage> CountryLanguage { get; set; }

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }/**/

        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        static ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(_connectionString);
            }/**/
        }

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
                    .HasColumnName("Name")
                    .HasColumnType("char(35)")
                    .HasMaxLength(35)
                    .IsUnicode(true)
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("CountryCode")
                    .HasColumnType("char(3)")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasColumnName("District")
                    .HasColumnType("char(20)")
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
                    .HasColumnName("Code")
                    .HasColumnType("char(3)")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasColumnType("char(52)")
                    .HasMaxLength(52)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Continent)
                    .IsRequired()
                    .HasColumnName("Continent")
                    .HasColumnType("ENUM('Asia','Europe','North America', 'Africa', 'Oceania', 'Antarcita', 'South America')")
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnName("Region")
                    .HasColumnType("char(26)")
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SurfaceArea)
                    .IsRequired()
                    .HasColumnName("SurfaceArea")
                    .HasColumnType("float(10,2)");

                entity.Property(e => e.IndepYear)
                    .HasColumnName("IndepYear")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Population)
                    .IsRequired()
                    .HasColumnName("Population")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LifeExpectancy)
                    .HasColumnName("LifeExpectancy")
                    .HasColumnType("float(3,1)");

                entity.Property(e => e.GNP)
                    .HasColumnName("GNP")
                    .HasColumnType("float(10,2)");

                entity.Property(e => e.GNPOld)
                    .HasColumnName("GNPOld")
                    .HasColumnType("float(10,2)");

                entity.Property(e => e.LocalName)
                    .HasColumnName("LocalName")
                    .IsRequired()
                    .HasColumnType("char(45)")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.GovernmentForm)
                    .HasColumnName("GovernmentForm")
                    .IsRequired()
                    .HasColumnType("char(45)")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.HeadOfState)
                    .HasColumnName("HeadOfState")
                    .HasColumnType("char(60)")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Capital)
                    .HasColumnName("Capital")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code2)
                    .IsRequired()
                    .HasColumnName("Code2")
                    .HasColumnType("char(2)")
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
                    .HasColumnType("char(3)")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasColumnType("char(30)")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IsOfficial)
                    .IsRequired()
                    .HasColumnType("enum('T','F')")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Percentage)
                    .IsRequired()
                    .HasColumnType("float(4,1)");
            });
            
            //base.OnModelCreating(modelBuilder);
        }

    }
}
