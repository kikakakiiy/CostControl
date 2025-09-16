using CostControl.Models;
using Microsoft.EntityFrameworkCore;
using CostControl.Models;

namespace CostControl.Data
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions<DashboardContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }   // Class = Project, Tabel = Projects

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // kalau tabel di SQL Server bernama "Projects", mapping opsional
            modelBuilder.Entity<Project>().ToTable("Projects");
        }
    }
}
