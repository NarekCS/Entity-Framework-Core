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
    public class SuppliersController : Controller
    {
        private ISupplierRepository supplierRepository;
        private EFDatabaseContext dbContext;

        public SuppliersController(ISupplierRepository supplierRepo, EFDatabaseContext context)
        {
            supplierRepository = supplierRepo;
            dbContext = context;
        }
        public IActionResult Index()
        {
            ViewBag.SupplierEditId = TempData["SupplierEditId"];
            ViewBag.SupplierCreateId = TempData["SupplierCreateId"];
            ViewBag.SupplierRelationshipId = TempData["SupplierRelationshipId"];
            return View(supplierRepository.GetAll());
        }
        public IActionResult Edit(long id)
        {
            TempData["SupplierEditId"] = id;
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Update(Supplier supplier)
        {
            supplierRepository.Update(supplier);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create(long id)
        {
            TempData["SupplierCreateId"] = id;
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Change(long id)
        {
            TempData["SupplierRelationshipId"] = id;
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //public IActionResult Change(Supplier supplier)
        //{
        //    IEnumerable<Product> changed = supplier.Products.Where(p => p.SupplierId != supplier.Id);
        //    //if (changed.Count() > 0)
        //    //{
        //    //    IEnumerable<Supplier> allSuppliers = supplierRepository.GetAll().ToArray();
        //    //    Supplier currentSupplier = allSuppliers.First(s => s.Id == supplier.Id);
        //    //    foreach (Product p in changed)
        //    //    {
        //    //        Supplier newSupplier = allSuppliers.First(s => s.Id == p.SupplierId);
        //    //        newSupplier.Products = newSupplier.Products.Append(currentSupplier.Products.First(op => op.Id == p.Id)).ToArray();
        //    //        supplierRepository.Update(newSupplier);
        //    //    }
        //    //}
        //    IEnumerable<long> targetSupplierIds = changed.Select(p => p.SupplierId).Distinct();
        //    if (changed.Count() > 0)
        //    {
        //        IEnumerable<Supplier> targetSuppliers = dbContext.Suppliers.Where(s => targetSupplierIds.Contains(s.Id)).AsNoTracking().ToArray();
        //        foreach (Product p in changed)
        //        { 
        //            Supplier newSupplier = targetSuppliers.First(s => s.Id == p.SupplierId);
        //            newSupplier.Products = newSupplier.Products == null ? new Product[] { p } : newSupplier.Products.Append(p).ToArray();
        //        }
        //        dbContext.Suppliers.UpdateRange(targetSuppliers);
        //        dbContext.SaveChanges();
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
        [HttpPost]
        public IActionResult Change(long Id, Product[] products)
        {
            dbContext.Products.UpdateRange(products.Where(p => p.SupplierId != Id));
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
