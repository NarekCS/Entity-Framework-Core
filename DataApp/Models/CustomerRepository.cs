using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
    }
    public class EFCustomerRepository : ICustomerRepository
    {
        private EFCustomerContext context;
        public EFCustomerRepository(EFCustomerContext ctx) => context = ctx; 
        public IEnumerable<Customer> GetAllCustomers() => context.Customers; 
    }
}
