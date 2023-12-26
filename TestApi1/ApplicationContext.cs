using Microsoft.EntityFrameworkCore;
using Option_1.Models;

namespace TestApi1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Member> member { get; set; }
        public DbSet<Assistance>  assistance { get; set; }
        public DbSet<Package>  package { get; set; }



        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions) 
        {
        }
    }
}
