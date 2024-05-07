using Microsoft.EntityFrameworkCore;

namespace ReactAspCrud.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Student { get;set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ReactAspCrud;Integrated Security=true;TrustServerCertificate=True;");
        }
    }
}
