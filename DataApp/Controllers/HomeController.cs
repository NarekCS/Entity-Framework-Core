using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataApp.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository repository;

        public HomeController(IDataRepository repo) { repository = repo; }
        //public IActionResult Index()
        //{
        //    // var products = repository.Products.Where(p => p.Price > 25).ToArray();
        //    //var products = repository.GetProductsByPrice(25);
        //    //ViewBag.ProductCount = products.Count();
        //    return View(repository.GetAllProducts());
        //}

        public IActionResult Index(string category = null, decimal? price = null)
        {
            var products = repository.GetFilteredProducts(category, price);
            ViewBag.category = category;
            ViewBag.price = price;
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.CreateMode = true;
            return View("Editor", new Product());
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            repository.CreateProduct(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(long id)
        {
            ViewBag.CreateMode = false;
            return View("Editor", repository.GetProduct(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product, Product original)
        {
            repository.UpdateProduct(product, original);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            repository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
