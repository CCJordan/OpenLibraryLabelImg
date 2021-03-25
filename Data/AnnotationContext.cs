using OpenLibraryLabelImg.Model;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.EntityFramework;

namespace OpenLibraryLabelImg.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AnnotationContext : DbContext
    {
        public AnnotationContext():base(new MySqlConnection(ConfigurationManager.ConnectionStrings["AnnotationContext"].ConnectionString), true)
        {
            Database.Connection.Open();
            this.Database.CreateIfNotExists();
            this.Database.Initialize(true);
            this.SaveChanges();

            if (!this.Database.CompatibleWithModel(false)) {
                MessageBox.Show("DB Model Error.");
            }
            
        }

        public DbSet<AnnotationImage> Images { get; set; }
        public DbSet<AnnotationCollection> Collections { get; set; }
        public DbSet<AnnotationClass> Classes { get; set; }
        public DbSet<YoloNet> Nets { get; set; }
        public DbSet<AnnotationBox> Boxes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnnotationClass>()
                .HasIndex(c => c.Title).IsUnique();

            modelBuilder.Entity<ClassMap>().HasKey(cm => new { cm.AnnotationClassId, cm.MappedId });
        }
    }
}
