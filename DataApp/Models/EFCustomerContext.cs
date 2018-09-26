using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public class EFCustomerContext : DbContext
    {
        public EFCustomerContext(DbContextOptions<EFCustomerContext> opts) : base(opts) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
