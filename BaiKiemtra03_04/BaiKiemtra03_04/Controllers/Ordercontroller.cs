using BaiKiemtra03_04.Data;
using BaiKiemtra03_04.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemtra03_04.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> orders = _db.Orders.Include(o => o.Supplier).ToList(); // Fixed the naming to 'Orders'
            return View(orders);
        }

        [HttpGet]
        public IActionResult Upsert(int id)
        {
            Order order = new Order();
            IEnumerable<SelectListItem> suppliers = _db.Suppliers.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                }
            );
            ViewBag.SupplierList = suppliers;

            if (id == 0)
            {
                return View(order);
            }
            else
            {
                order = _db.Orders.Include(o => o.Supplier).FirstOrDefault(o => o.Id == id); // Fixed naming to 'Orders'
                if (order == null)
                {
                    return NotFound();
                }
                return View(order);
            }
        }

        [HttpPost]
        public IActionResult Upsert (Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.Id == 0)
                {
                    _db.Order.Add(order);
                }
                else
                {
                    _db.Order.Update(order);
                }
                // Save changes
                _db.SaveChanges();
                // Redirect to index
                return RedirectToAction("Index");
            }
            // If model state is invalid, reload the supplier list
            ViewBag.SupplierList = _db.Supplier.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                }
            );
        }

    }
}



