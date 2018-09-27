using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataApp.Controllers
{
    public class RelatedDataController : Controller
    {
        private ISupplierRepository supplierRepo;
        private IGenericRepository<ContactDetails> detailsRepo;
        private IGenericRepository<ContactLocation> locsRepo;
        public RelatedDataController(ISupplierRepository sRepo, IGenericRepository<ContactDetails> dRepo, IGenericRepository<ContactLocation> lRepo)
        {
            supplierRepo = sRepo;
            detailsRepo = dRepo;
            locsRepo = lRepo;
        }

        public IActionResult Index() => View(supplierRepo.GetAll());
        public IActionResult Contacts() => View(detailsRepo.GetAll());
        public IActionResult Locations() => View(locsRepo.GetAll());
    }
}
