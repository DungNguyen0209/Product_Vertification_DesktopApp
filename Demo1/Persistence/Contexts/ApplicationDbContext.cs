using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Models;
using ProductVertificationDesktopApp.Domain.Models.Resource;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Persistence.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<TestingConfigurations> TestingConfigurations { get; set; }

        public DbSet<TestSheet> testSheetReliability { get; set; }
        //public DbSet<TestSheet> testSheetDeformation { get; set; }
        public ApplicationDbContext() : base("name = Connect")
        {
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.
                Entity<TestingConfigurations>().
                HasKey(t => t.TestID);

            modelBuilder.
                Entity<TestingConfigurations>().
                Property(t => t.NumberClosingSetting).
                IsOptional().
                HasColumnName("Số lần đóng nắp cài đặt ");

            modelBuilder.
               Entity<TestingConfigurations>().
               Property(t => t.NumberClosingCurrent).
               IsOptional().
               HasColumnName("Số lần đóng nắp hiện tại ");

            modelBuilder.
               Entity<TestingConfigurations>().
               Property(t => t.TimeHoldingCloseSP).
               IsOptional().
               HasColumnName("Thời gian giữ nắp đóng :SP ");

            modelBuilder
               .Entity<TestingConfigurations>()
               .Property(t => t.TimeHoldingOpenSP)
               .IsOptional()
               .HasColumnName("Số lần giữ nắp mở :SP");


            modelBuilder
                .Entity<TestSheet>()
                .HasKey(s => s.TestSheetID);
        }
    }
}
