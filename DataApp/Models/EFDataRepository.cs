using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public class EFDataRepository : IDataRepository
    {
        private EFDatabaseContext context;
        public EFDataRepository(EFDatabaseContext ctx) { context = ctx; }
        //public IQueryable<Product> Products => context.Products;
        //public IEnumerable<Product> GetProductsByPrice(decimal minPrice) => context.Products.Where(p => p.Price >= minPrice).ToArray(); 
        public Product GetProduct(long id)
        {
            Console.WriteLine("GetProduct: " + id);
            return new Product();
        }
        public IEnumerable<Product> GetAllProducts()
        {
            Console.WriteLine("GetAllProducts");
            return context.Products;
        }
        public void CreateProduct(Product newProduct)
        {
            Console.WriteLine("CreateProduct: " + JsonConvert.SerializeObject(newProduct));
        }
        public void UpdateProduct(Product changedProduct)
        {
            Console.WriteLine("UpdateProduct : " + JsonConvert.SerializeObject(changedProduct));
        }
        public void DeleteProduct(long id)
        {
            Console.WriteLine("DeleteProduct: " + id);
        }
    }
}
