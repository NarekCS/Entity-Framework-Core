using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public interface IDataRepository
    {
        // IQueryable<Product> Products { get; }
        //IEnumerable<Product> GetProductsByPrice(decimal minPrice);
        Product GetProduct(long id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetFilteredProducts(string category = null, decimal? price = null);

        void CreateProduct(Product newProduct);
        void UpdateProduct(Product changedProduct, Product originalProduct = null);
        void DeleteProduct(long id);
    }
}
