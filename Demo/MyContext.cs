using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class MyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=KhaldiSchool;Trusted_Connection=True;");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Dorm> Dorm { get; set; }
    }
}
