using Microsoft.EntityFrameworkCore;

namespace api_aurora.Models
{
    public class StudentDetailContext : DbContext
    {
        public StudentDetailContext(DbContextOptions<StudentDetailContext> options) : base(options)
        {

        }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        //Table Name StudentDetails
    }
}
