using aspnet.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace aspnet.Data
{
    // DbContext can have one or more DbSet (We use LINQ to query this DbSet)
    // We use LINQ to query dbset , these LINQ is converted or transalater into SQL query at runtime 
    // After the process database returns the response to DbSet and These DbSet return  
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
            Employees = Set<Employee>();
        }
        
        // DbSet represent table in database
        // Employees - will be the table name 

        public DbSet<Employee> Employees { get; set; }  
    }
}
