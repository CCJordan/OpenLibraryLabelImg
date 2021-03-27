using OpenLibraryLabelImg.Model;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.EntityFramework;
using System;

namespace OpenLibraryLabelImg.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AnnotationContext : DbContext
    {
        public AnnotationContext()
            :base(new MySqlConnection(ConfigurationManager.ConnectionStrings["AnnotationContext"].ConnectionString), true)
        {
            try
            {
                Database.Connection.Open();
                Database.CreateIfNotExists();
                Database.Initialize(true);
                SaveChanges();
            }
            catch (Exception ex)
            {
                string exMessage = "";
                do {
                    exMessage += ex.Message + "\n";
                    ex = ex.InnerException;
                }
                while (ex != null);

                MessageBox.Show("DB Error:\n" + exMessage);
                throw;
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
