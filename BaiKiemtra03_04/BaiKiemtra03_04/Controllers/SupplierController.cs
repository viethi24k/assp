using BaiKiemtra03_04.Data;
using BaiKiemtra03_04.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BaiKiemtra03_04.Controllers
{
               
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _db;
        

        public SupplierController(ApplicationDbContext db)
        {
            _db = db ;
        }
       
        public IActionResult Index()
        {

            IEnumerable<Supplier> suppliers = _db.Suppliers.ToList(); // Assuming you have a DbSet<Supplier>
            return View(suppliers);
        }

        [HttpGet]
        public IActionResult Upsert(int id)
        {
            Supplier supplier = new Supplier();

            if (id == 0)
            {
                return View(supplier);
            }
            else
            {
                supplier = _db.Suppliers.FirstOrDefault(s => s.Id == id);
                if (supplier == null)
                {
                    return NotFound();
                }
                return View(supplier);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (supplier.Id == 0)
                {
                    _db.Suppliers.Add(supplier);
                }
                else
                {
                    _db.Suppliers.Update(supplier);
                }
                // Save changes
                _db.SaveChanges();
                // Redirect to index
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var supplier = _db.Supplier.FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }
            _db.Suppliers.Remove(supplier);
            _db.SaveChanges();
            return Json(new { success = true });
            
        }
    }
}
