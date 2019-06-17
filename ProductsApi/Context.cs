using Microsoft.EntityFrameworkCore;
using BandQ.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi
{
    public class Context: DbContext
    {
        private IServiceProvider _serviceProvider;


        public Context(DbContextOptions<Context> options, IServiceProvider serviceProvider): base(options)
        {
            _serviceProvider = serviceProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConfigureProvider
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
       public DbSet<Order> Orders { get; set; }
       public DbSet<Employee> Employees { get; set; }
    }
}
