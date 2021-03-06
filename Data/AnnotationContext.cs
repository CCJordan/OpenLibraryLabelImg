using Microsoft.EntityFrameworkCore;
using OpenLibraryLabelImg.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLibraryLabelImg.Data
{
    public class AnnotationContext : DbContext
    {
        public AnnotationContext() {
        }

        public AnnotationContext(DbContextOptions<AnnotationContext> options)
               : base(options)
        {

            // Server=DESKTOP-BGNCFKH\\MSSQLLAB;Database=OpenLibraryLabelImg;Trusted_Connection=True;MultipleActiveResultSets=true
        }

        public virtual DbSet<AnnotationImage> Images { get; set; }
        public virtual DbSet<AnnotationCollection> Collections { get; set; }
        public virtual DbSet<AnnotationClass> Classes { get; set; }
        public virtual DbSet<YoloNet> Nets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = $"Server=DESKTOP-BGNCFKH\\MSSQLLAB;Database=OpenLibraryLabelImg;Trusted_Connection=True;MultipleActiveResultSets=true";
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnnotationClass>()
                .HasIndex(c => c.ClassLabel).IsUnique();
        }
    }
}
