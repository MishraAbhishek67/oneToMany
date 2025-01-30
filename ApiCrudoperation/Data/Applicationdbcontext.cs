using ApiCrudoperation.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ApiCrudoperation.Data
{
    public class Applicationdbcontext:DbContext
    {
        public Applicationdbcontext(DbContextOptions<Applicationdbcontext>options):base(options)
        {
            
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        //one to one
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Address)
                .WithOne()
                .HasForeignKey<Employee>(x => x.AddressId);


       
        }

    }
}


