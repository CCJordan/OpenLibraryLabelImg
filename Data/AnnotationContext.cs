using OpenLibraryLabelImg.Model;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SQLite;
using System.Data.SQLite.EF6.Migrations;
using System.Reflection;
using System.Windows.Forms;

namespace OpenLibraryLabelImg.Data
{
    public class AnnotationContext : DbContext
    {
        

        public AnnotationContext():base(new SQLiteConnection() { ConnectionString = "Data Source=.\\OpenLibraryLabelImg.db" }, true) {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AnnotationContext, ContextMigrationConfiguration>(true));

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnnotationClass>()
                .HasIndex(c => c.Title).IsUnique();

            modelBuilder.Entity<ClassMap>().HasKey(cm => new { cm.AnnotationClassId, cm.MappedId });
        }
    }

    internal sealed class ContextMigrationConfiguration : DbMigrationsConfiguration<AnnotationContext>
    {
        public ContextMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }
    }
}
