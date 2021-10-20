using Microsoft.EntityFrameworkCore;

namespace app.Models.Contexts
{  
    public class ApplicationDbContext : DbContext  
    {  
  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  
        {  
  
        }
        
        public DbSet<Person> Persons { get; set; }  
    }  
}