using BaiKiemtra03_04.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemtra03_04.Data
{
   
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Supplier> Suppliers { get; set; }  // Add this line

            public DbSet<Order> Orders { get; set; }        // Assuming you also have an Order DbSet

        // Add other DbSets as needed for your application
      

        public DbSet<Supplier> Supplier { get; set; }  // Existing DbSet for Suppliers
        public DbSet<Order> Order { get; set; }        // Add this line for Orders

        // Add other DbSets as needed for your application
    }
}

    


