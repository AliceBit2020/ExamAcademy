using ExamAcademy.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExamAcademy.Controller
{
    internal class ContextDb : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Facultys { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O6DMGPJ\\SQLEXPRESS;Database=EF_Academy;TrustServerCertificate=true;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            
          

            mb.ApplyConfiguration(new DepartmentConfig());
            mb.ApplyConfiguration(new FacultyConfig());

        }
    }
    public class FacultyConfig:IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> tb)
        {
            tb.Property(p => p.Name).IsRequired().HasColumnType("nvarchar(100)");
            tb.HasAlternateKey(p => p.Name);
            tb.HasKey(p => p.Id);
        }
    }
    public  class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> tb)
        {
            tb.HasKey(p => p.Id);//// clastered primary key
            tb.HasAlternateKey(p => p.Name);///// IsUnique  non clastered key
            tb.ToTable(t => t.HasCheckConstraint("CK_Building", "Building>=1 and Building<5"));
            tb.ToTable(t => t.HasCheckConstraint("CK_Financing", "Financing >=0"));

            tb.Property(p => p.Building).IsRequired();


            tb.Property(p=>p.Financing).IsRequired().HasColumnType("money").HasDefaultValue("0");
            tb.Property(p=>p.Name).IsRequired().HasColumnType("nvarchar(100)");

        }
    }
}
