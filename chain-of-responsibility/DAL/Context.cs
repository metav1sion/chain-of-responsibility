using Microsoft.EntityFrameworkCore;

namespace chain_of_responsibility.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-JTNUQFE\\SQLEXPRESS;initial Catalog=ChainOfDb;integrated security=true");
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
