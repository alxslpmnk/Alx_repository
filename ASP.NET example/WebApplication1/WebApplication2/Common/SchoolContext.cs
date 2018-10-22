using System.Data.Entity;
using WebApplication2.Models.School;

namespace WebApplication2.Common
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("DefaultConnection")
        {
        }
        
        public DbSet<Student> Students { get; set; }
    }
}