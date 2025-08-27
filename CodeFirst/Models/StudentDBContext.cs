using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class StudentDBContext : DbContext //migration - It is used to manage database connection and is used to save and reretrieve data in db.
    {
        public StudentDBContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<Student> Students { get; set; } // Creation of DbSet for Student entity
    }
}