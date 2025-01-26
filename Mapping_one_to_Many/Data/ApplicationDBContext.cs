using Mapping_one_to_Many.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Mapping_one_to_Many.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
       

      
    }
}

