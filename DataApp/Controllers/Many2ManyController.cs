using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataApp.Controllers
{
    public class Many2ManyController : Controller
    {
        private EFDatabaseContext context;
        public Many2ManyController(EFDatabaseContext ctx) => context = ctx;
        public IActionResult Index()
        {
            return View(new ProductShipmentViewModel {
                Products = context.Products.Include(p => p.ProductShipments).ThenInclude(ps => ps.Shipment).ToArray(),
                Shipments = context.Set<Shipment>().Include(s => s.ProductShipments).ThenInclude(ps => ps.Product).ToArray() });
        }
        public IActionResult EditShipment(long id)
        {
            ViewBag.Products = context.Products.Include(p => p.ProductShipments);
            return View("ShipmentEditor", context.Set<Shipment>().Find(id));
        }
        public IActionResult UpdateShipment(long id, long[] pids)
        {
            Shipment shipment = context.Set<Shipment>().Include(s => s.ProductShipments).First(s => s.Id == id);
            shipment.ProductShipments = pids.Select(pid => new ProductShipmentJunction { ShipmentId = id, ProductId = pid }).ToList();
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

    public class ProductShipmentViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Shipment> Shipments { get; set; }
    }
}
