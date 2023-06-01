using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Context
{
    public class ProjectParticipatingDbContext : DbContext
    {
        public ProjectParticipatingDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ProjectParticipatingManagementDB"));
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<CompanyProject> CompanyProjects { get; set; }
        public virtual DbSet<ParticipatingProject> ParticipatingProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<Employee>().HasIndex(e => e.EmailAddress).IsUnique();
            optionsBuilder.Entity<ParticipatingProject>(entity =>
            {
                entity.HasKey(p => new { p.EmployeeID, p.CompanyProjectID });
                entity.HasOne(p => p.Employee).WithMany(e => e.ParticipatingProjects).HasForeignKey(p => p.EmployeeID);
                entity.HasOne(p => p.CompanyProject).WithMany(e => e.ParticipatingProjects).HasForeignKey(p => p.CompanyProjectID);
            }
            );
            
        }

    }
}
