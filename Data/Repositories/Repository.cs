using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class Repository : DbContext
    {
        public Repository(DbContextOptions<Repository> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Staff> Staffs { get; set; }
    }
}
