using Microsoft.EntityFrameworkCore;
using OpenLibraryLabelImg.Model;
using System.Reflection;

namespace OpenLibraryLabelImg.Data
{
    public class AnnotationContext : DbContext
    {
        public AnnotationContext() {
        }

        public AnnotationContext(DbContextOptions<AnnotationContext> options)
               : base(options)
        {
        }

        public virtual DbSet<AnnotationImage> Images { get; set; }
        public virtual DbSet<AnnotationCollection> Collections { get; set; }
        public virtual DbSet<AnnotationClass> Classes { get; set; }
        public virtual DbSet<YoloNet> Nets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlite("Filename=OpenLibraryLabelImg.db", options =>
                {
                    options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnnotationClass>()
                .HasIndex(c => c.ClassLabel).IsUnique();

            modelBuilder.Entity<ClassMap>().HasKey(cm => new { cm.AnnotationClassId, cm.MappedId });
        }
    }
}
