using JWT_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT_P2.SchoolDatabaseContext
{
    public class SchoolMessageDatabaseContext : DbContext
    {

        public SchoolMessageDatabaseContext(DbContextOptions<SchoolMessageDatabaseContext> options) : base(options) { }
        
        public DbSet<Parents> Parents { get; set; }
        public DbSet<ParentDetails> ParentDetails { get; set; }
        public DbSet<Students> Students { get; set; }  
        public DbSet<Schools> Schools { get; set; }
        public DbSet<Messages> Messages { get; set; }

    }
}
