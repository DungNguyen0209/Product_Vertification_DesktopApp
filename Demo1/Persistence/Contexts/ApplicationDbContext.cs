using ProductVertificationDesktopApp.Domain;
using ProductVertificationDesktopApp.Domain.Models;
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
        public DbSet<TestingMachine> testingMachines { get; set; }

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
                .Entity<TestingMachine>()
                .HasKey(s => s.ID);

            modelBuilder
                .Entity<TestingMachine>()
                .Property(p => p.Target)
                .HasColumnName("Mục đích kiểm tra");

            modelBuilder
              .Entity<TestingMachine>()
              .Property(p=> p.NumberTesting)
              .HasColumnName("Số lần thử ");

            modelBuilder
              .Entity<TestingMachine>()
              .Property(p => p.StatusLidResult)
              .IsOptional()
              .HasColumnName("Kết quả đánh giá Nắp ");

            modelBuilder
              .Entity<TestingMachine>()
              .Property(p => p.StatusPlinthResult)
              .IsOptional()
              .HasColumnName("Kết quả đánh giá Đế ");

            modelBuilder
              .Entity<TestingMachine>()
              .Property(p => p.TotalMistake)
              .IsOptional()
              .HasColumnName("Tổng lỗi");

            modelBuilder
              .Entity<TestingMachine>()
              .Property(p => p.Note)
              .IsOptional()
              .HasColumnName("Ghi Chú ");

            modelBuilder
              .Entity<TestingMachine>()
              .Property(p => p.StaffCheck)
              .IsOptional()
              .HasColumnName("Nhân viên kiểm tra");
        }
    }
}
