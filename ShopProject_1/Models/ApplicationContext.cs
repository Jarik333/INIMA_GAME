using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace ShopProject_1.Models
{
    public class ApplicationContext : DbContext
    {
      
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        public DbSet<Order> Order { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
           
            Database.EnsureCreated();
        }
    }
}